// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadoutJournalEntry.cs" company="Martin Amareld">
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

    public class LoadoutJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Loadout;

        internal LoadoutJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Ship")]
        [Description("current ship type")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        [Description("current ship type")]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("ship id number (indicates which of your ships you are in)")]
        public int ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        [Description("user-defined ship name")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        [Description("user-defined ship ID string")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("Modules")]
        [Description("array of installed items, each with:")]
        public List<LoadoutModule> ModulesList { get; internal set; }
    }
}