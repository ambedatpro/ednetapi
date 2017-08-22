// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DockedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class DockedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Docked;

        internal DockedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("StationFaction")]
        public string StationFaction { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernmentId { get; internal set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernment { get; internal set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; internal set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomyId { get; internal set; }

        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomy { get; internal set; }

        [JsonProperty("DistFromStarLS")]
        public double DistFromStarLs { get; internal set; }

        [JsonProperty("CockpitBreach")]
        public bool CockpitBreach { get; internal set; }
    }
}