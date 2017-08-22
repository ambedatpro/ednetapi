// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadoutJournalEntry.cs" company="Martin Amareld">
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
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        public int ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("Modules")]
        public List<LoadoutModule> ModulesList { get; internal set; }
    }
}