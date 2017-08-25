// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InformationManager.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;

    using EdNetApi.Common;
    using EdNetApi.Common.Database;
    using EdNetApi.Information.Database;
    using EdNetApi.Information.Datas;
    using EdNetApi.Journal;
    using EdNetApi.Journal.Enums;
    using EdNetApi.Journal.JournalEntries;

    using JetBrains.Annotations;

    using ServiceStack.DataAnnotations;

    public class InformationManager : DisposableBase, INotifyPropertyChanged
    {
        private readonly JournalManager _journalManager;
        private readonly DatabaseManager<DatabaseConnection> _databaseManager;
        private readonly string _version;

        private LastProcessedJournal _lastProcessedJournal;
        private CommanderData _currentCommander;
        private ShipData _currentShip;
        private LocationData _currentLocation;
        private MissionAcceptedJournalEntry[] _currentMissions;

        ////private Dictionary<JournalEventType, JournalEntry> _latestEvents;
        public InformationManager(string databaseFolderPath, bool allowAnonymousErrorFeedback)
        {
            _version = Assembly.GetExecutingAssembly().GetName().Version.ToString(4);

            _databaseManager = new DatabaseManager<DatabaseConnection>(databaseFolderPath);
            ResetDatabaseIfOutOfDate();
            ReadInitialData();

            _journalManager = new JournalManager(allowAnonymousErrorFeedback);
            _journalManager.JournalEntryRead += OnJournalEntryRead;
            _journalManager.JournalEntryException += OnJournalEntryException;

            FeedbackManager.PreviewFeedback += OnPreviewFeedback;
            FeedbackManager.FeedbackSent += OnFeedbackSent;
        }

        public event EventHandler<ThreadExceptionEventArgs> JournalEntryException;

        public event EventHandler<JournalEntryEventArgs> JournalEntryRead;

        public event PropertyChangedEventHandler PropertyChanged;

        public CommanderData CurrentCommander
        {
            get => _currentCommander;

            private set
            {
                _currentCommander = value;
                OnPropertyChanged();
            }
        }

        public ShipData CurrentShip
        {
            get => _currentShip;

            private set
            {
                _currentShip = value;
                OnPropertyChanged();
            }
        }

        public LocationData CurrentLocation
        {
            get => _currentLocation;

            private set
            {
                _currentLocation = value;
                OnPropertyChanged();
            }
        }

        public MissionAcceptedJournalEntry[] CurrentMissions
        {
            get => _currentMissions;

            private set
            {
                _currentMissions = value;
                OnPropertyChanged();
            }
        }

        public List<StatisticsData> GetEventStatistics(StatisticsData filter)
        {
            var connection = _databaseManager.GetOrCreateConnection();
            {
                var statistics = connection.SelectStatistics(filter);
                return statistics;
            }
        }

        public int GetEventStatisticsSum(StatisticsData filter)
        {
            var connection = _databaseManager.GetOrCreateConnection();
            {
                var statistics = connection.SelectStatistics(filter);
                return statistics.Sum(stat => stat.Count);
            }
        }

        ////[CanBeNull]
        ////public T GetLatestEvent<T>()
        ////    where T : JournalEntry
        ////{
        ////    var eventType = GetEventType(typeof(T));
        ////    return _latestEvents.ContainsKey(eventType) ? (T)_latestEvents[eventType] : default(T);
        ////}
        public void Start()
        {
            Stop();

            if (_lastProcessedJournal != null)
            {
                _journalManager.Start(true, _lastProcessedJournal.Filename, _lastProcessedJournal.LineNumber);
            }
            else
            {
                _journalManager.Start(true);
            }
        }

        public void Stop()
        {
            _journalManager.Stop();
            _databaseManager.ForceCommit();
        }

        protected override void Dispose(bool disposeManagedResources)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposeManagedResources)
            {
                _journalManager.Stop();
                _journalManager.JournalEntryRead -= OnJournalEntryRead;
                _journalManager.JournalEntryException -= OnJournalEntryException;
            }

            base.Dispose(disposeManagedResources);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static void CopyNonNullValuesIfNull<TSource, TTarget>(TSource source, TTarget target)
        {
            if (source == null || target == null)
            {
                return;
            }

            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = target.GetType().GetProperties();
            foreach (var sourceProperty in sourceProperties)
            {
                var ignore = sourceProperty.GetCustomAttributes<IgnoreAttribute>(false).Any();
                if (ignore)
                {
                    continue;
                }

                var targetProperty = targetProperties.Single(pi => pi.Name == sourceProperty.Name);
                var targetValue = targetProperty.GetValue(target);
                if (targetValue != null)
                {
                    continue;
                }

                var sourceValue = sourceProperty.GetValue(source);
                if (sourceValue != null)
                {
                    targetProperty.SetValue(target, sourceValue.ToString());
                }
            }
        }

        ////private static JournalEventType GetEventType(Type journalEntryType)
        ////{
        ////    var eventType = (JournalEventType)journalEntryType.GetField("EventConst").GetValue(null);
        ////    return eventType;
        ////}
        [CanBeNull]
        private StatisticsEntry CreateStatisticsEntry(JournalEntry journalEntry)
        {
            var type = typeof(StatisticsEntry);
            var statisticsEntryProperties = type.GetProperties().Where(
                pi =>
                    {
                        switch (pi.Name)
                        {
                            case nameof(StatisticsEntry.Id):
                            case nameof(StatisticsEntry.Event):
                            case nameof(StatisticsEntry.Count):
                                return false;
                            default:
                                return true;
                        }
                    }).ToList();

            type = journalEntry.GetType();
            var journalEntryProperties = type.GetProperties().Where(
                pi =>
                    {
                        switch (pi.Name)
                        {
                            case nameof(JournalEntry.Event):
                            case nameof(JournalEntry.Timestamp):
                            case nameof(JournalEntry.SourceJson):
                                return false;
                            default:
                                return true;
                        }
                    }).ToList();

            var matchingProperties = journalEntryProperties
                .Where(pi => statisticsEntryProperties.Any(spi => spi.Name == pi.Name)).ToDictionary(
                    pi => statisticsEntryProperties.Single(spi => spi.Name == pi.Name),
                    pi => pi);
            if (matchingProperties.Count == 0)
            {
                return null;
            }

            var statisticsEntry = new StatisticsEntry { Event = journalEntry.Event, Count = 1 };
            foreach (var matchingProperty in matchingProperties)
            {
                var value = matchingProperty.Value.GetValue(journalEntry);
                matchingProperty.Key.SetValue(statisticsEntry, value?.ToString(), null);
            }

            statisticsEntry.Commander = CurrentCommander.Commander;
            CopyNonNullValuesIfNull(CurrentShip, statisticsEntry);
            CopyNonNullValuesIfNull(CurrentLocation, statisticsEntry);

            return statisticsEntry;
        }

        private void OnFeedbackSent(object sender, StringEventArgs eventArgs)
        {
            var feedback = new Feedback { Timestamp = DateTime.UtcNow, Message = eventArgs.Value };
            using (var connection = _databaseManager.CreateNonDelayConnection())
            {
                connection.InsertFeedback(feedback);
                connection.ForceCommitAndDispose();
            }
        }

        private void OnJournalEntryException(object sender, ThreadExceptionEventArgs eventArgs)
        {
            JournalEntryException.Raise(sender, eventArgs);
        }

        private void OnJournalEntryRead(object sender, JournalEntryEventArgs eventArgs)
        {
            ProcessJournalEntry(eventArgs.Filename, eventArgs.LineNumber, true, eventArgs.JournalEntry);

            if (_journalManager.IsLive)
            {
                JournalEntryRead.Raise(sender, eventArgs);
            }
        }

        private void OnPreviewFeedback(object sender, FeedbackPreviewEventArgs eventArgs)
        {
            using (var connection = _databaseManager.CreateNonDelayConnection())
            {
                if (connection.SelectFeedbackExists(eventArgs.Value))
                {
                    eventArgs.Handled = true;
                }

                connection.RollbackAndDispose();
            }
        }

        private void ProcessJournalEntry(string filename, int lineNumber, bool parsed, JournalEntry journalEntry)
        {
            var connection = _databaseManager.GetOrCreateConnection();
            {
                connection.InsertOrUpdateSettingsEntry(
                    SettingType.LastProcessedJournal,
                    new LastProcessedJournal { Filename = filename, LineNumber = lineNumber });

                connection.InsertJournalEntrySource(
                    new JournalEntrySource
                    {
                        Filename = filename,
                        LineNumber = lineNumber,
                        Parsed = parsed,
                        Json = journalEntry.SourceJson
                    });

                UpdateCurrentCommander(connection, journalEntry);
                UpdateCurrentShip(connection, journalEntry);
                UpdateCurrentLocation(connection, journalEntry);
                UpdateCurrentMissions(connection, journalEntry);

                ////_latestEvents[journalEntry.Event] = journalEntry;
                connection.InsertOrUpdateLatestEvent(
                    new LatestEvent { EventType = journalEntry.Event, JournalEntryJson = journalEntry.SourceJson });

                var statisticsEntry = CreateStatisticsEntry(journalEntry);
                if (statisticsEntry != null)
                {
                    connection.InsertOrUpdateStatisticsEntry(statisticsEntry);
                }

                connection.DelayedCommitAndDispose();
            }
        }

        private void ReadInitialData()
        {
            var connection = _databaseManager.GetOrCreateConnection();
            {
                _lastProcessedJournal =
                    connection.SelectSetting<LastProcessedJournal>(SettingType.LastProcessedJournal);
                CurrentCommander = connection.SelectSetting<CommanderData>(SettingType.Commander);
                CurrentShip = connection.SelectSetting<ShipData>(SettingType.Ship);
                CurrentLocation = connection.SelectSetting<LocationData>(SettingType.Location);
                CurrentMissions = connection.SelectSetting<MissionAcceptedJournalEntry[]>(SettingType.ActiveMissions);

                //// _currentLoadout = connection.SelectSetting<LocationData>(SettingType.CurrentLoadout);
                ////_latestEvents = connection.SelectLatestEvents();
            }
        }

        private void ResetDatabaseIfOutOfDate()
        {
            var connection = _databaseManager.GetOrCreateConnection();
            {
                connection.CreateTablesIfNotExists();
                var databaseVersion = connection.SelectSetting<string>(SettingType.SchemaVersion);
                if (databaseVersion == _version)
                {
                    return;
                }

                connection.RollbackAndDispose();
            }

            File.Delete(_databaseManager.DatabaseFilePath);

            connection = _databaseManager.GetOrCreateConnection();
            {
                connection.CreateTablesIfNotExists();
                connection.InsertOrUpdateSettingsEntry(SettingType.SchemaVersion, _version);
                connection.DelayedCommitAndDispose();
            }
        }

        private void UpdateCurrentCommander(DatabaseConnection connection, JournalEntry journalEntry)
        {
            string name;
            switch (journalEntry.Event)
            {
                case JournalEventType.NewCommander:
                    var newCommander = (NewCommanderJournalEntry)journalEntry;
                    name = newCommander.Name;
                    break;
                case JournalEventType.LoadGame:
                    var loadGame = (LoadGameJournalEntry)journalEntry;
                    name = loadGame.Commander;
                    break;
                default:
                    return;
            }

            CurrentCommander = new CommanderData { Commander = name };
            connection.InsertOrUpdateSettingsEntry(SettingType.Commander, CurrentCommander);
        }

        private void UpdateCurrentLoadout(DatabaseConnection connection, JournalEntry journalEntry)
        {
        }

        private void UpdateCurrentLocation(DatabaseConnection connection, JournalEntry journalEntry)
        {
            string starSystem;
            string stationName = null;
            string body = null;
            string bodyType = null;

            switch (journalEntry.Event)
            {
                case JournalEventType.Location:
                    var locationEntry = (LocationJournalEntry)journalEntry;
                    starSystem = locationEntry.StarSystem;
                    stationName = locationEntry.StationName;
                    body = locationEntry.Body;
                    bodyType = locationEntry.BodyType;
                    break;
                case JournalEventType.Docked:
                    var docked = (DockedJournalEntry)journalEntry;
                    starSystem = docked.StarSystem;
                    stationName = docked.StationName;
                    break;
                case JournalEventType.FsdJump:
                    var fsdJump = (FsdJumpJournalEntry)journalEntry;
                    starSystem = fsdJump.StarSystem;
                    break;
                case JournalEventType.SupercruiseEntry:
                    var supercruiseEntry = (SupercruiseEntryJournalEntry)journalEntry;
                    starSystem = supercruiseEntry.StarSystem;
                    break;
                case JournalEventType.SupercruiseExit:
                    var supercruiseExit = (SupercruiseExitJournalEntry)journalEntry;
                    starSystem = supercruiseExit.StarSystem;
                    body = supercruiseExit.Body;
                    bodyType = supercruiseExit.BodyType;
                    break;
                case JournalEventType.Undocked:
                    starSystem = CurrentLocation?.StarSystem;
                    break;
                default:
                    return;
            }

            CurrentLocation = new LocationData
            {
                StarSystem = starSystem,
                StationName = stationName,
                Body = body,
                BodyType = bodyType
            };
            connection.InsertOrUpdateSettingsEntry(SettingType.Location, CurrentLocation);
        }

        private void UpdateCurrentMissions(DatabaseConnection connection, JournalEntry journalEntry)
        {
            var missionId = 0;
            var addMission = false;
            switch (journalEntry.Event)
            {
                case JournalEventType.MissionAbandoned:
                    var abandoned = (MissionAbandonedJournalEntry)journalEntry;
                    missionId = abandoned.MissionId;
                    break;
                case JournalEventType.MissionAccepted:
                    addMission = true;
                    break;
                case JournalEventType.MissionCompleted:
                    var completed = (MissionCompletedJournalEntry)journalEntry;
                    missionId = completed.MissionId;
                    break;
                case JournalEventType.MissionFailed:
                    var failed = (MissionFailedJournalEntry)journalEntry;
                    missionId = failed.MissionId;
                    break;
                default:
                    return;
            }

            var missions = (CurrentMissions ?? new MissionAcceptedJournalEntry[0]).ToList();
            if (addMission)
            {
                missions.Add((MissionAcceptedJournalEntry)journalEntry);
                CurrentMissions = missions.ToArray();
            }
            else
            {
                CurrentMissions = missions.Where(mission => mission.MissionId != missionId).ToArray();
            }

            connection.InsertOrUpdateSettingsEntry(SettingType.ActiveMissions, CurrentMissions);
        }

        private void UpdateCurrentShip(DatabaseConnection connection, JournalEntry journalEntry)
        {
            ShipType ship;
            string shipName = null;
            string shipIdent = null;
            switch (journalEntry.Event)
            {
                case JournalEventType.LoadGame:
                    var loadGame = (LoadGameJournalEntry)journalEntry;
                    ship = loadGame.Ship;
                    shipName = loadGame.ShipName;
                    shipIdent = loadGame.ShipIdent;
                    break;
                case JournalEventType.Loadout:
                    var loadout = (LoadoutJournalEntry)journalEntry;
                    ship = loadout.Ship;
                    shipName = loadout.ShipName;
                    shipIdent = loadout.ShipIdent;
                    break;
                case JournalEventType.ShipyardNew:
                    var shipyardNew = (ShipyardNewJournalEntry)journalEntry;
                    ship = shipyardNew.ShipType;
                    break;
                case JournalEventType.SetUserShipName:
                    var setUserShipName = (SetUserShipNameJournalEntry)journalEntry;
                    ship = setUserShipName.Ship;
                    shipName = setUserShipName.UserShipName;
                    shipIdent = setUserShipName.UserShipId;
                    break;
                default:
                    return;
            }

            CurrentShip = new ShipData { Ship = ship, ShipName = shipName, ShipIdent = shipIdent };
            connection.InsertOrUpdateSettingsEntry(SettingType.Ship, CurrentShip);
        }
    }
}