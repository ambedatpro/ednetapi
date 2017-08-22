// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    using EdNetApi.Journal;

    using ServiceStack.DataAnnotations;

    public class StatisticsEntry : IStatistics
    {
        [AutoIncrement]
        public int Id { get; internal set; }

        [Index(Unique = false)]
        public JournalEventType Event { get; internal set; }

        public string Commander { get; internal set; }

        public string StarSystem { get; internal set; }

        public string StationName { get; internal set; }

        public string Name { get; internal set; }

        public string Faction { get; internal set; }

        public string BodyType { get; internal set; }

        public string Body { get; internal set; }

        public string BodyName { get; internal set; }

        public string Ship { get; internal set; }

        public string Interdictor { get; internal set; }

        public string Interdicted { get; internal set; }

        public string KillerName { get; internal set; }

        public string KillerShip { get; internal set; }

        public string Victim { get; internal set; }

        public int Count { get; internal set; }
    }
}