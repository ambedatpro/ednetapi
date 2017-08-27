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
                Connection.CreateTableIfNotExists<StatisticsEntry>();
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

        public void InsertOrUpdateStatisticsEntry(StatisticsEntry statisticsEntry)
        {
            lock (_lockObjecct)
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
        }

        public bool SelectFeedbackExists(string message)
        {
            lock (_lockObjecct)
            {
                return Connection.Select<Feedback>(f => f.Message == message).Any();
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

        public List<StatisticsData> SelectStatistics(StatisticsData statisticsFilter)
        {
            lock (_lockObjecct)
            {
                var query = Connection.From<StatisticsEntry>().OrderByDescending(se => se.Count);
                query.WhereExpression = GetStatisticsWhereClause(statisticsFilter, false);
                var statisticEntries = Connection.Select(query);
                var statisticDatas = statisticEntries.Select(ConvertToData).ToList();
                return statisticDatas;
            }
        }

        public int SelectStatisticsSum(StatisticsData statisticsFilter)
        {
            lock (_lockObjecct)
            {
                var query = Connection.From<StatisticsEntry>().Select(Sql.Sum(nameof(StatisticsData.Count)));
                query.WhereExpression = GetStatisticsWhereClause(statisticsFilter, false);
                var sum = Connection.Scalar<int>(query);
                return sum;
            }
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