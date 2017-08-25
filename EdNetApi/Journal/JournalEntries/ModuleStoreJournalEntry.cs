// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleStoreJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class ModuleStoreJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ModuleStore;

        internal ModuleStoreJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Slot")]
        [Description("")]
        public string Slot { get; internal set; }

        [JsonProperty("StoredItem")]
        [Description("")]
        public string StoredItemId { get; internal set; }

        [JsonProperty("StoredItem_Localised")]
        [Description("")]
        public string StoredItem { get; internal set; }

        [JsonProperty("Ship")]
        [Description("")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        [Description("")]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("")]
        public int ShipId { get; internal set; }

        [JsonProperty("EngineerModifications")]
        [Description("name of modification blueprint, if any")]
        public string EngineerModifications { get; internal set; }
    }
}