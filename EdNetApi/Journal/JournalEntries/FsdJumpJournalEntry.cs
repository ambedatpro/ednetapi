// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsdJumpJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class FsdJumpJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.FsdJump;

        internal FsdJumpJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("StarPos")]
        public List<double> StarPosList { get; internal set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; internal set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomyId { get; internal set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomy { get; internal set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernmentId { get; internal set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernment { get; internal set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurityId { get; internal set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurity { get; internal set; }

        [JsonProperty("JumpDist")]
        public double JumpDist { get; internal set; }

        [JsonProperty("FuelUsed")]
        public double FuelUsed { get; internal set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("Factions")]
        public List<FsdJumpFaction> FactionsList { get; internal set; }

        [JsonProperty("SystemFaction")]
        public string SystemFaction { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }

        [JsonProperty("Powers")]
        public List<string> PowersList { get; internal set; }

        [JsonProperty("PowerplayState")]
        public string PowerplayStateRaw { get; internal set; }

        [JsonIgnore]
        public PowerplayState PowerplayState => PowerplayStateRaw.GetEnumValue<PowerplayState>();
    }
}