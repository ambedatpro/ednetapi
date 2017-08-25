// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class LocationJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Location;

        internal LocationJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Docked")]
        [Description("(bool)")]
        public bool Docked { get; internal set; }

        [JsonProperty("StationName")]
        [Description("station name, (if docked)")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        [Description("(if docked)")]
        public string StationType { get; internal set; }

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

        [JsonProperty("Body")]
        [Description("star or planet’s body name")]
        public string BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        [Description("")]
        public string BodyType { get; internal set; }

        [JsonProperty("Factions")]
        [Description("an array with info on local minor factions (similar to FSDJump)")]
        public List<LocationFaction> FactionsList { get; internal set; }

        [JsonProperty("SystemFaction")]
        [Description("star system controlling faction")]
        public string SystemFaction { get; internal set; }

        [JsonProperty("FactionState")]
        [Description("")]
        public string FactionState { get; internal set; }

        [JsonProperty("Body_Localised")]
        [Description("")]
        public string Body { get; internal set; }

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