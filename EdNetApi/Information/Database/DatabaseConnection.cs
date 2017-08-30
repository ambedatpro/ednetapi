// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseConnection.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EdNetApi.Common;
    using EdNetApi.Common.Database;
    using EdNetApi.Information.Datas;
    using EdNetApi.Journal;
    using EdNetApi.Journal.JournalEntries;

    using JetBrains.Annotations;

    using Newtonsoft.Json;

    using ServiceStack.Data;
    using ServiceStack.OrmLite;

    internal class DatabaseConnection : DelayedCommitDatabaseConnection
    {
        private readonly object _lockObjecct = new object();

        public DatabaseConnection(IDbConnectionFactory factory, int commitDelay)
            : base(factory, commitDelay)
        {
        }

        public void CreateTablesIfNotExists()
        {
            lock (_lockObjecct)
            {
                Connection.CreateTableIfNotExists<SettingsEntry>();
                Connection.CreateTableIfNotExists<JournalEntrySource>();
                Connection.CreateTableIfNotExists<EventStatisticsEntry>();
                Connection.CreateTableIfNotExists<Feedback>();
            }
        }

        public void InsertFeedback(Feedback feedback)
        {
            lock (_lockObjecct)
            {
                Connection.Insert(feedback);
            }
        }

        public void InsertJournalEntrySource(JournalEntrySource source)
        {
            lock (_lockObjecct)
            {
                Connection.Insert(source);
            }
        }

        public void InsertOrUpdateSettingsEntry<T>(SettingType type, T value)
        {
            lock (_lockObjecct)
            {
                var json = typeof(T) == typeof(string) ? (string)(object)value : JsonConvert.SerializeObject(value);
                var settingsEntry = new SettingsEntry { Type = type, Value = json };
                DatabaseManager<DatabaseConnection>.InsertOrUpdate(Connection, settingsEntry, se => se.Type == type);
            }
        }

        public void InsertOrUpdateStatisticsEntry(EventStatisticsEntry eventStatisticsEntry)
        {
            lock (_lockObjecct)
            {
                var whereClause = GetStatisticsWhereClause(eventStatisticsEntry, true);
                var query = Connection.From<EventStatisticsEntry>().WithSqlFilter(sql => sql + whereClause);
                var existingStatisticsEntry = Connection.Select(query).SingleOrDefault();

                if (existingStatisticsEntry != null)
                {
                    existingStatisticsEntry.Count++;
                    Connection.Update(existingStatisticsEntry);
                }
                else
                {
                    Connection.Insert(eventStatisticsEntry);
                }
            }
        }

        public bool SelectFeedbackExists(string message)
        {
            lock (_lockObjecct)
            {
                return Connection.Select<Feedback>(f => f.Message == message).Any();
            }
        }

        public GameStatistics SelectGamePlayedStatistics()
        {
            var gamePlayedData = SelectSetting<GamePlayedData>(SettingType.GamePlayed) ?? new GamePlayedData();

            var entrySources = Connection.SelectLazy<JournalEntrySource>()
                .Where(jes => jes.Id >= gamePlayedData.SessionStartedId).OrderBy(jes => jes.Filename)
                .ThenBy(jes => jes.LineNumber);

            DateTime? lastEntryTimestamp = null;
            var currentFilename = string.Empty;
            DateTime? gameStarted = null;

            var endGameAction = new Action<DateTime?, DateTime?>(
                (gameStarted2, gameEnded2) =>
                    {
                        if (!gameStarted2.HasValue || !gameEnded2.HasValue)
                        {
                            return;
                        }

                        var gameTime = gameEnded2.Value - gameStarted2.Value;
                        gamePlayedData.SessionsPlayed++;
                        gamePlayedData.TotalTimePlayed = gamePlayedData.TotalTimePlayed.Add(gameTime);
                    });

            foreach (var entrySource in entrySources)
            {
                if (!entrySource.Parsed)
                {
                    continue;
                }

                var entry = JournalManager.ParseJournalEntry(entrySource.Json);

                if (entrySource.Filename != currentFilename)
                {
                    var fileHeader = entry as FileheaderJournalEntry;
                    if (fileHeader?.Part == 1)
                    {
                        endGameAction(gameStarted, lastEntryTimestamp);
                        gameStarted = null;
                    }
                }

                currentFilename = entrySource.Filename;

                switch (entry.Event)
                {
                    case JournalEventType.LoadGame:
                        endGameAction(gameStarted, lastEntryTimestamp);
                        gamePlayedData.SessionStartedId = entrySource.Id;
                        gameStarted = entry.Timestamp;
                        break;
                }

                lastEntryTimestamp = entry.Timestamp != lastEntryTimestamp ? entry.Timestamp : lastEntryTimestamp;
            }

            InsertOrUpdateSettingsEntry(SettingType.GamePlayed, gamePlayedData);

            if (!gameStarted.HasValue)
            {
                return new GameStatistics
                           {
                               SessionsPlayed = gamePlayedData.SessionsPlayed,
                               TotalTimePlayed = gamePlayedData.TotalTimePlayed
                           };
            }

            var sessionTimePlayed = lastEntryTimestamp.Value - gameStarted.Value;
            return new GameStatistics
                       {
                           SessionsPlayed = gamePlayedData.SessionsPlayed + 1,
                           TotalTimePlayed = gamePlayedData.TotalTimePlayed.Add(sessionTimePlayed),
                           CurrentSessionPlayed = sessionTimePlayed
                       };
        }

        public LastProcessedJournal SelectLastProcessedJournal()
        {
            lock (_lockObjecct)
            {
                var lastJournalEntrySource = Connection.Select<JournalEntrySource>()
                    .OrderByDescending(jes => jes.Filename).ThenByDescending(jes => jes.LineNumber).Take(1)
                    .FirstOrDefault();
                return lastJournalEntrySource != null
                           ? new LastProcessedJournal
                           {
                               Filename = lastJournalEntrySource.Filename,
                               LineNumber = lastJournalEntrySource.LineNumber
                           }
                           : null;
            }
        }

        [CanBeNull]
        public T SelectSetting<T>(SettingType type)
        {
            lock (_lockObjecct)
            {
                var settingsEntry = Connection.Select<SettingsEntry>(se => se.Type == type).SingleOrDefault();
                if (settingsEntry == null)
                {
                    return default(T);
                }

                return typeof(T) == typeof(string)
                           ? (T)(object)settingsEntry.Value
                           : settingsEntry.Value.DeserializeJson<T>();
            }
        }

        public List<EventStatisticsData> SelectStatistics(EventStatisticsData statisticsFilter)
        {
            lock (_lockObjecct)
            {
                var query = Connection.From<EventStatisticsEntry>().OrderByDescending(se => se.Count);
                query.WhereExpression = GetStatisticsWhereClause(statisticsFilter, false);
                var statisticEntries = Connection.Select(query);
                var statisticDatas = statisticEntries.Select(ConvertToData).ToList();
                return statisticDatas;
            }
        }

        public int SelectStatisticsSum(EventStatisticsData statisticsFilter)
        {
            lock (_lockObjecct)
            {
                var query = Connection.From<EventStatisticsEntry>().Select(Sql.Sum(nameof(EventStatisticsData.Count)));
                query.WhereExpression = GetStatisticsWhereClause(statisticsFilter, false);
                var sum = Connection.Scalar<int>(query);
                return sum;
            }
        }

        private static EventStatisticsData ConvertToData(EventStatisticsEntry eventStatisticsEntry)
        {
            var statisticsData = new EventStatisticsData();
            var dataType = typeof(EventStatisticsData);

            foreach (var property in typeof(IEventStatistics).GetProperties())
            {
                var value = property.GetValue(eventStatisticsEntry, null);
                var dataProperty = dataType.GetProperty(property.Name);
                dataProperty?.SetValue(statisticsData, value, null);
            }

            statisticsData.Count = eventStatisticsEntry.Count;

            return statisticsData;
        }

        private static string GetStatisticsWhereClause(IEventStatistics eventStatistics, bool includeNulls)
        {
            var whereItems = new List<string>();
            foreach (var property in typeof(IEventStatistics).GetProperties())
            {
                var value = property.GetValue(eventStatistics, null)?.ToString();
                if (value == null && !includeNulls)
                {
                    continue;
                }

                var valueString = value != null ? $@"= ""{value}""" : "IS NULL";

                whereItems.Add($@"""{property.Name}"" {valueString}");
            }

            var whereClause = Environment.NewLine + "WHERE " + string.Join(" AND ", whereItems);
            return whereClause;
        }
    }
}