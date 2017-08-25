// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsdJumpJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;
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
        [Description("name of destination starsystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("StarPos")]
        [Description("star position, as a Json array [x, y, z], in light years")]
        public List<double> StarPosList { get; internal set; }

        [JsonProperty("SystemAllegiance")]
        [Description("")]
        public string SystemAllegiance { get; internal set; }

        [JsonProperty("SystemEconomy")]
        [Description("")]
        public string SystemEconomyId { get; internal set; }

        [JsonProperty("SystemEconomy_Localised")]
        [Description("")]
        public string SystemEconomy { get; internal set; }

        [JsonProperty("SystemGovernment")]
        [Description("")]
        public string SystemGovernmentId { get; internal set; }

        [JsonProperty("SystemGovernment_Localised")]
        [Description("")]
        public string SystemGovernment { get; internal set; }

        [JsonProperty("SystemSecurity")]
        [Description("")]
        public string SystemSecurityId { get; internal set; }

        [JsonProperty("SystemSecurity_Localised")]
        [Description("")]
        public string SystemSecurity { get; internal set; }

        [JsonProperty("JumpDist")]
        [Description("distance jumped")]
        public double JumpDist { get; internal set; }

        [JsonProperty("FuelUsed")]
        [Description("")]
        public double FuelUsed { get; internal set; }

        [JsonProperty("FuelLevel")]
        [Description("")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("Factions")]
        [Description("an array of info for the local minor factions")]
        public List<FsdJumpFaction> FactionsList { get; internal set; }

        [JsonProperty("SystemFaction")]
        [Description("system controlling faction")]
        public string SystemFaction { get; internal set; }

        [JsonProperty("FactionState")]
        [Description("")]
        public string FactionState { get; internal set; }

        [JsonProperty("Powers")]
        [Description("a json array with the names of any powers contesting the system, or the name of the controlling power")]
        public List<string> PowersList { get; internal set; }

        [JsonProperty("PowerplayState")]
        [Description("the system state – one of (\"InPrepareRadius\", \"Prepared\", \"Exploited\", \"Contested\", \"Controlled\", \"Turmoil\", \"HomeSystem\")")]
        public string PowerplayStateRaw { get; internal set; }

        [JsonIgnore]
        [Description("the system state – one of (\"InPrepareRadius\", \"Prepared\", \"Exploited\", \"Contested\", \"Controlled\", \"Turmoil\", \"HomeSystem\")")]
        public PowerplayState PowerplayState => PowerplayStateRaw.GetEnumValue<PowerplayState>();
    }
}