﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalManager.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    using EdNetApi.Common;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class JournalManager : DisposableBase
    {
        private static Guid savedGamesKnownFolderGuid = new Guid("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4");

        private readonly ManualResetEventSlim _isLiveEvent;
        private readonly ManualResetEventSlim _proceedReadingJournalEvent;
        private readonly ManualResetEventSlim _proceedToNextJournalEvent;

        private FileSystemWatcher _journalFolderWatcher;
        private CancellationTokenSource _journalCancellationTokenSource;
        private Task _processJournalsTask;

        public JournalManager(bool allowAnonymousErrorFeedback)
        {
            JournalFolderPath = GetJournalFolderPath();

            _proceedReadingJournalEvent = new ManualResetEventSlim();
            _proceedToNextJournalEvent = new ManualResetEventSlim();
            _isLiveEvent = new ManualResetEventSlim();

            FeedbackManager.Initialize(allowAnonymousErrorFeedback);
        }

        public event EventHandler<ThreadExceptionEventArgs> JournalEntryException;

        public event EventHandler<JournalEntryEventArgs> JournalEntryRead;

        public string JournalFolderPath { get; }

        private bool IsLive => _isLiveEvent.IsSet;

        public void Start(bool waitForLiveEntries, string lastJournalFilename, int lastJournalLineNumber)
        {
            Stop();

            _journalFolderWatcher = new FileSystemWatcher();
            _journalFolderWatcher.NotifyFilter |= NotifyFilters.CreationTime | NotifyFilters.LastAccess
                                                  | NotifyFilters.LastWrite | NotifyFilters.Size
                                                  | NotifyFilters.FileName;
            _journalFolderWatcher.IncludeSubdirectories = false;
            _journalFolderWatcher.Path = JournalFolderPath;
            _journalFolderWatcher.Filter = "*.log";
            _journalFolderWatcher.Created += OnJournalFolderFileCreated;
            _journalFolderWatcher.Changed += OnJournalFolderFileChanged;
            _journalFolderWatcher.EnableRaisingEvents = true;

            _journalCancellationTokenSource = new CancellationTokenSource();
            _processJournalsTask = Task.Factory.StartNew(
                o => ProcessJournals(_journalCancellationTokenSource.Token, lastJournalFilename, lastJournalLineNumber),
                _journalCancellationTokenSource.Token,
                TaskCreationOptions.LongRunning);

            if (waitForLiveEntries)
            {
                _isLiveEvent.Wait();
            }
        }

        public void Start(bool waitForLiveEntries)
        {
            Start(waitForLiveEntries, null, 0);
        }

        public void Stop()
        {
            if (_journalFolderWatcher != null)
            {
                _journalFolderWatcher.EnableRaisingEvents = false;
                _journalFolderWatcher.Created -= OnJournalFolderFileCreated;
                _journalFolderWatcher.Changed -= OnJournalFolderFileChanged;
                _journalFolderWatcher.Dispose();
                _journalFolderWatcher = null;
            }

            _journalCancellationTokenSource?.Cancel();
            _processJournalsTask?.Wait();

            _processJournalsTask?.Dispose();
            _processJournalsTask = null;

            _journalCancellationTokenSource?.Dispose();
            _journalCancellationTokenSource = null;

            _isLiveEvent.Reset();
        }

        internal static JournalEntry ParseJournalEntry(
            string journalEntryJson,
            string filename = null,
            int? lineNumber = null)
        {
            try
            {
                var entry = JObject.Parse(journalEntryJson);
                var journalEntryEvent = entry["event"]?.Value<string>().ToPascalCase();
                if (string.IsNullOrWhiteSpace(journalEntryEvent)
                    || !Enum.IsDefined(typeof(JournalEventType), journalEntryEvent))
                {
                    var filenameInfo = filename != null ? $" in file {filename}" : null;
                    var lineNumberInfo = lineNumber != null ? $" on line {lineNumber}" : null;
                    throw new ApplicationException($"Unknown journal entry event{filenameInfo}{lineNumberInfo}");
                }

                var journalEntryTypeName =
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.Journal.JournalEntries.{journalEntryEvent}JournalEntry";
                var journalEntryType = Type.GetType(journalEntryTypeName);
                if (journalEntryType == null)
                {
                    throw new ApplicationException($"Not implemented journal entry event: {journalEntryEvent}");
                }

                var journalEntry = (JournalEntry)entry.ToObject(journalEntryType);
                journalEntry.SourceJson = journalEntryJson;
                return journalEntry;
            }
            catch (Exception exception)
            {
                FeedbackManager.SendFeedback(
                    () =>
                        $"Error in ParseJournalEntry: {exception.Message}{Environment.NewLine}journalEntryJson: {AnonymizeJson(journalEntryJson)}");
                var journalEntry =
                    new UnknownJournalEntry { ParseError = exception.Message, SourceJson = journalEntryJson };
                return journalEntry;
            }
        }

        protected override void Dispose(bool disposeManagedResources)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposeManagedResources)
            {
                Stop();
            }

            base.Dispose(disposeManagedResources);
        }

        private static string AnonymizeJson(string json)
        {
            try
            {
                var item = JObject.Parse(json);
                item.Children().ToList().ForEach(AnonymizeToken);
                var anonymizedJson = JsonConvert.SerializeObject(item);
                return anonymizedJson;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        private static void AnonymizeToken(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    token.Value<JObject>().Children().ToList().ForEach(AnonymizeToken);
                    break;
                case JTokenType.Array:
                    token.Value<JArray>().Children().ToList().ForEach(AnonymizeToken);
                    break;
                case JTokenType.Property:
                    if (((JProperty)token).Name != "event")
                    {
                        AnonymizeToken(token.Value<JProperty>().Value);
                    }

                    break;
                case JTokenType.Integer:
                    ((JValue)token).Value = 123;
                    break;
                case JTokenType.Float:
                    ((JValue)token).Value = 123.456f;
                    break;
                case JTokenType.String:
                    ((JValue)token).Value = "Abc";
                    break;
                case JTokenType.Boolean:
                    ((JValue)token).Value = false;
                    break;
                case JTokenType.Date:
                    ((JValue)token).Value = new DateTime(2017, 1, 2, 3, 4, 5, DateTimeKind.Utc);
                    break;

                ////case JTokenType.Bytes:
                ////case JTokenType.Guid:
                ////case JTokenType.Uri:
                ////case JTokenType.None:
                ////case JTokenType.Constructor:
                ////case JTokenType.Comment:
                ////case JTokenType.Null:
                ////case JTokenType.Undefined:
                ////case JTokenType.Raw:
                ////case JTokenType.TimeSpan:
                default:
                    throw new ArgumentOutOfRangeException($"JTokenType.{token.Type} is not supported");
            }
        }

        private static string GetJournalFolderPath()
        {
            string savedGamesFolderPath;
            if (SHGetKnownFolderPath(ref savedGamesKnownFolderGuid, 0, IntPtr.Zero, out IntPtr pathPtr) == 0)
            {
                savedGamesFolderPath = Marshal.PtrToStringUni(pathPtr);
                Marshal.FreeCoTaskMem(pathPtr);
            }
            else
            {
                var userProfileFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                savedGamesFolderPath = Path.Combine(userProfileFolderPath, "Saved Games");
            }

            if (string.IsNullOrWhiteSpace(savedGamesFolderPath))
            {
                throw new ApplicationException("Failed to get user saved games folder path");
            }

            var journalFolderPath = Path.Combine(savedGamesFolderPath, @"Frontier Developments\Elite Dangerous");
            return journalFolderPath;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(
            ref Guid knownFolderGuid,
            int flags,
            IntPtr token,
            out IntPtr path);

        private void OnJournalFolderFileChanged(object sender, FileSystemEventArgs eventArgs)
        {
            _proceedReadingJournalEvent.Set();
        }

        private void OnJournalFolderFileCreated(object sender, FileSystemEventArgs eventArgs)
        {
            _proceedToNextJournalEvent.Set();
        }

        private bool ProcessAllExistingLines(
            string filename,
            StreamReader journalStreamReader,
            int lineNumberToStartAt,
            CancellationToken cancellationToken,
            out int lineNumber)
        {
            lineNumber = 0;
            string journalJson;
            while ((journalJson = journalStreamReader.ReadLine()) != null)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return false;
                }

                if (lineNumber < lineNumberToStartAt)
                {
                    lineNumber++;
                    continue;
                }

                var journalEntry = ParseJournalEntry(journalJson, filename, ++lineNumber);
                RaiseJournalEntryRead(new JournalEntryEventArgs(filename, lineNumber, journalEntry, IsLive));
            }

            return true;
        }

        private void ProcessJournals(
            CancellationToken cancellationToken,
            string filenameToProcess,
            int lineNumberToStartAt)
        {
            var skipFirstFile = false;

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                StreamReader journalStreamReader = null;
                try
                {
                    _proceedToNextJournalEvent.Reset();

                    var firstFilenameToProcess = filenameToProcess;
                    var filePathsToProcess = Directory
                        .EnumerateFiles(JournalFolderPath, "*.log", SearchOption.TopDirectoryOnly).Where(
                            path =>
                                {
                                    var name = Path.GetFileName(path);
                                    var filenameIsNew = string.CompareOrdinal(name, firstFilenameToProcess) >= 0;
                                    return filenameIsNew;
                                }).OrderBy(path => path).ToList();

                    if (skipFirstFile && filePathsToProcess.Any())
                    {
                        filePathsToProcess.RemoveAt(0);
                    }

                    if (!filePathsToProcess.Any())
                    {
                        _proceedToNextJournalEvent.Wait(cancellationToken);
                        continue;
                    }

                    var filePath = filePathsToProcess.First();
                    var journalFileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    journalStreamReader = new StreamReader(journalFileStream);

                    var filename = Path.GetFileName(filePath);
                    if (lineNumberToStartAt > 0
                        && !filename.Equals(filenameToProcess, StringComparison.OrdinalIgnoreCase))
                    {
                        lineNumberToStartAt = 0;
                    }

                    filenameToProcess = filename;

                    int lineNumber;
                    if (!ProcessAllExistingLines(
                            filenameToProcess,
                            journalStreamReader,
                            lineNumberToStartAt,
                            cancellationToken,
                            out lineNumber))
                    {
                        return;
                    }

                    lineNumberToStartAt = 0;
                    skipFirstFile = true;

                    if (filePathsToProcess.Count == 1)
                    {
                        // If this is the only new file, then all historical entries have now been read
                        _isLiveEvent.Set();
                    }
                    else
                    {
                        // There are more files to process
                        continue;
                    }

                    // This is the only new file, wait for new entries
                    if (!ProcessNewLines(filenameToProcess, lineNumber, journalStreamReader, cancellationToken))
                    {
                        return;
                    }
                }
                catch (ExternalException externalException)
                {
                    // Do no send error feedback for external exceptions
                    JournalEntryException.Raise(this, new ThreadExceptionEventArgs(externalException.InnerException));
                }
                catch (Exception exception)
                {
                    var lastEdNetApiStackFrame = exception.StackTrace.Split('\n')
                        .First(stackFrame => stackFrame.Contains("EdNetApi"));
                    FeedbackManager.SendFeedback(
                        () =>
                            $"Error in ProcessJournals: {exception.Message}{Environment.NewLine}{lastEdNetApiStackFrame}");
                    JournalEntryException.Raise(this, new ThreadExceptionEventArgs(exception));
                }
                finally
                {
                    journalStreamReader?.Close();
                    journalStreamReader?.Dispose();
                }
            }
        }

        private bool ProcessNewLines(
            string lastJournalFilename,
            int lineNumber,
            StreamReader journalStreamReader,
            CancellationToken cancellationToken)
        {
            while (true)
            {
                _proceedReadingJournalEvent.Reset();

                var proceedToNextJournalAfterRead = _proceedToNextJournalEvent.IsSet;

                string journalJson;
                while ((journalJson = journalStreamReader.ReadLine()) != null)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    var journalEntry = ParseJournalEntry(journalJson, lastJournalFilename, ++lineNumber);
                    RaiseJournalEntryRead(
                        new JournalEntryEventArgs(lastJournalFilename, lineNumber, journalEntry, IsLive));
                }

                if (proceedToNextJournalAfterRead)
                {
                    return true;
                }

                while (true)
                {
                    var waitResult = WaitHandle.WaitAny(
                        new[]
                            {
                                _proceedReadingJournalEvent.WaitHandle, _proceedToNextJournalEvent.WaitHandle,
                                cancellationToken.WaitHandle
                            },
                        1000);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    if (waitResult != WaitHandle.WaitTimeout || !journalStreamReader.EndOfStream)
                    {
                        break;
                    }
                }
            }
        }

        private void RaiseJournalEntryRead(JournalEntryEventArgs eventArgs)
        {
            try
            {
                JournalEntryRead.Raise(this, eventArgs);
            }
            catch (Exception exception)
            {
                throw new ExternalException(exception);
            }
        }
    }
}