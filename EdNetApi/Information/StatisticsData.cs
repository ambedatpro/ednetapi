// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsData.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information
{
    using EdNetApi.Journal;

    public class StatisticsData : IStatistics
    {
        public JournalEventType Event { get; set; }

        public string Commander { get; set; }

        public string StarSystem { get; set; }

        public string StationName { get; set; }

        public string Name { get; set; }

        public string Faction { get; set; }

        public string BodyType { get; set; }

        public string Body { get; set; }

        public string Ship { get; set; }

        public string Interdictor { get; set; }

        public string Interdicted { get; set; }

        public string KillerName { get; set; }

        public string KillerShip { get; set; }

        public string Victim { get; set; }

        public int Count { get; set; }
    }
}