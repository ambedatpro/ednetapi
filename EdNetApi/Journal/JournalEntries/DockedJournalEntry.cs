// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DockedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("name of station")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        [Description("type of station")]
        public string StationType { get; internal set; }

        [JsonProperty("StarSystem")]
        [Description("name of system")]
        public string StarSystem { get; internal set; }

        [JsonProperty("StationFaction")]
        [Description("station’s controlling faction")]
        public string StationFaction { get; internal set; }

        [JsonProperty("FactionState")]
        [Description("")]
        public string FactionState { get; internal set; }

        [JsonProperty("StationGovernment")]
        [Description("")]
        public string StationGovernmentId { get; internal set; }

        [JsonProperty("StationGovernment_Localised")]
        [Description("")]
        public string StationGovernment { get; internal set; }

        [JsonProperty("StationAllegiance")]
        [Description("")]
        public string StationAllegiance { get; internal set; }

        [JsonProperty("StationEconomy")]
        [Description("")]
        public string StationEconomyId { get; internal set; }

        [JsonProperty("StationEconomy_Localised")]
        [Description("")]
        public string StationEconomy { get; internal set; }

        [JsonProperty("DistFromStarLS")]
        [Description("")]
        public double DistFromStarLs { get; internal set; }

        [JsonProperty("CockpitBreach")]
        [Description("true (only if landing with breached cockpit)")]
        public bool CockpitBreach { get; internal set; }
    }
}