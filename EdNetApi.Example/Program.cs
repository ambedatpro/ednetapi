// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using EdNetApi.Common;
    using EdNetApi.Information;
    using EdNetApi.Journal;
    using EdNetApi.Journal.JournalEntries;

    internal class Program
    {
        private static InformationManager informationManager;
        private static List<string> journalFilenames;
        private static string currentFilename;

        public static void Main(string[] args)
        {
            var appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appFolderPath = Path.Combine(appDataFolderPath, Assembly.GetEntryAssembly().GetName().Name);
            if (!Directory.Exists(appFolderPath))
            {
                Directory.CreateDirectory(appFolderPath);
            }

            using (informationManager = new InformationManager(appFolderPath, allowAnonymousErrorFeedback: true))
            {
                informationManager.JournalEntryRead += OnJournalEntryRead;
                informationManager.JournalEntryException += OnJournalEntryException;

                journalFilenames = informationManager.ListJournalFiles();
                currentFilename = string.Empty;

                // Start will read and cache all historical events and then return
                // If this is the first time then it might take a few minutes
                informationManager.Start();

                Console.WriteLine($"Hello Cmdr {informationManager.CurrentCommander?.Commander}!");
                Console.WriteLine($"Current ship:        {informationManager.CurrentShip?.Ship}");
                Console.WriteLine($"Current star system: {informationManager.CurrentLocation?.StarSystem}");

                var filter = new EventStatisticsData { Event = JournalEventType.Docked };
                var statistics = informationManager.GetEventStatistics(filter);
                var stat = statistics.FirstOrDefault();
                Console.WriteLine();
                Console.WriteLine(
                    $"Most docked station: {stat?.StationName} in {stat?.StarSystem} ({stat?.Count} times)");

                filter = new EventStatisticsData { Event = JournalEventType.FsdJump, StarSystem = "Sol" };
                statistics = informationManager.GetEventStatistics(filter);
                Console.WriteLine();
                Console.WriteLine("Ships used to visit Sol system:");
                foreach (var statistic in statistics)
                {
                    Console.WriteLine($"{statistic.Ship} ({statistic.Count} times)");
                }

                Console.WriteLine();
                Console.WriteLine("Waiting for new entries to be written...");
                Console.WriteLine("Press ENTER at any time to exit");
                Console.ReadLine();

                informationManager.Stop();
            }
        }

        private static void OnJournalEntryRead(object sender, JournalEntryEventArgs eventArgs)
        {
            if (!eventArgs.IsLive)
            {
                if (eventArgs.Filename == currentFilename)
                {
                    return;
                }

                currentFilename = eventArgs.Filename;

                // Do not react on historical events. There may be thousands of them.
                var index = journalFilenames.IndexOf(eventArgs.Filename);
                if (index >= 0)
                {
                    var percentCompleted = (int)(index * 100 / (float)journalFilenames.Count);
                    Console.WriteLine($"{percentCompleted}% completed");
                }

                return;
            }

            switch (eventArgs.JournalEntry.Event)
            {
                case JournalEventType.Docked:
                    var dockedEntry = (DockedJournalEntry)eventArgs.JournalEntry;
                    var filter = new EventStatisticsData
                    {
                        Commander = informationManager.CurrentCommander.Commander,
                        Event = JournalEventType.Docked,
                        StarSystem = dockedEntry.StarSystem,
                        StationName = dockedEntry.StationName
                    };
                    var statistics = informationManager.GetEventStatistics(filter);
                    Console.WriteLine(
                        $"Welcome to {dockedEntry.StationName}, Cmdr {informationManager.CurrentCommander.Commander}!");

                    var totalVisits = statistics.Sum(stat => stat.Count);
                    var shipVisits = statistics
                        .Where(stat => stat.Ship == informationManager.CurrentShip.Ship.ToString())
                        .Sum(stat => stat.Count);
                    Console.WriteLine($"This is your visit #{totalVisits} (visit #{shipVisits} in current ship).");
                    break;

                default:
                    Console.WriteLine($"{eventArgs.JournalEntry.Event} ({eventArgs.JournalEntry.Event.Description()})");
                    break;
            }
        }

        private static void OnJournalEntryException(object sender, ThreadExceptionEventArgs eventArgs)
        {
            // Any exceptions that were thrown in the OnJournalEntryRead will end up here
        }
    }
}