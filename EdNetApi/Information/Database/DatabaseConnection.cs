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

    using JetBrains.Annotations;

    using Newtonsoft.Json;

    using ServiceStack.Data;
    using ServiceStack.OrmLite;

    internal class DatabaseConnection : DelayedCommitDatabaseConnection
    {
        public DatabaseConnection(IDbConnectionFactory factory, int commitDelay)
            : base(factory, commitDelay)
        {
        }

        public void CreateTablesIfNotExists()
        {
            Connection.CreateTableIfNotExists<SettingsEntry>();
            Connection.CreateTableIfNotExists<JournalEntrySource>();
            Connection.CreateTableIfNotExists<LatestEvent>();
            Connection.CreateTableIfNotExists<StatisticsEntry>();
            Connection.CreateTableIfNotExists<Feedback>();
        }

        public void InsertFeedback(Feedback feedback)
        {
            Connection.Insert(feedback);
        }

        public void InsertJournalEntrySource(JournalEntrySource source)
        {
            Connection.Insert(source);
        }

        public void InsertOrUpdateLatestEvent(LatestEvent latestEvent)
        {
            DatabaseManager<DatabaseConnection>.InsertOrUpdate(
                Connection,
                latestEvent,
                le => le.EventType == latestEvent.EventType,
                le => new { le.JournalEntryJson });
        }

        public void InsertOrUpdateSettingsEntry<T>(SettingType type, T value)
        {
            var json = typeof(T) == typeof(string) ? (string)(object)value : JsonConvert.SerializeObject(value);
            var settingsEntry = new SettingsEntry { Type = type, Value = json };
            DatabaseManager<DatabaseConnection>.InsertOrUpdate(Connection, settingsEntry, se => se.Type == type);
        }

        public void InsertOrUpdateStatisticsEntry(StatisticsEntry statisticsEntry)
        {
            var whereClause = GetStatisticsWhereClause(statisticsEntry, true);
            var query = Connection.From<StatisticsEntry>().WithSqlFilter(sql => sql + whereClause);
            var existingStatisticsEntry = Connection.Select(query).SingleOrDefault();

            if (existingStatisticsEntry != null)
            {
                existingStatisticsEntry.Count++;
                Connection.Update(existingStatisticsEntry);
            }
            else
            {
                Connection.Insert(statisticsEntry);
            }
        }

        public bool SelectFeedbackExists(string message)
        {
            return Connection.Select<Feedback>(f => f.Message == message).Any();
        }

        ////public Dictionary<JournalEventType, JournalEntry> SelectLatestEvents()
        ////{
        ////    var latestEvents = Connection.Select<LatestEvent>();
        ////    return latestEvents.ToDictionary(
        ////        latestEvent => latestEvent.EventType,
        ////        latestEvent => JournalManager.ParseJournalEntry(latestEvent.JournalEntryJson));
        ////}
        [CanBeNull]
        public T SelectSetting<T>(SettingType type)
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

        public List<StatisticsData> SelectStatistics(StatisticsData statisticsFilter)
        {
            var whereClause = GetStatisticsWhereClause(statisticsFilter, false);
            var query = Connection.From<StatisticsEntry>().OrderByDescending(se => se.Count);
            query.WhereExpression = whereClause;
            var statisticEntries = Connection.Select(query);
            var statisticDatas = statisticEntries.Select(ConvertToData).ToList();
            return statisticDatas;
        }

        private static StatisticsData ConvertToData(StatisticsEntry statisticsEntry)
        {
            var statisticsData = new StatisticsData();
            var dataType = typeof(StatisticsData);

            foreach (var property in typeof(IStatistics).GetProperties())
            {
                var value = property.GetValue(statisticsEntry, null);
                var dataProperty = dataType.GetProperty(property.Name);
                dataProperty?.SetValue(statisticsData, value, null);
            }

            statisticsData.Count = statisticsEntry.Count;

            return statisticsData;
        }

        private static string GetStatisticsWhereClause(IStatistics statistics, bool includeNulls)
        {
            var whereItems = new List<string>();
            foreach (var property in typeof(IStatistics).GetProperties())
            {
                var value = property.GetValue(statistics, null)?.ToString();
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