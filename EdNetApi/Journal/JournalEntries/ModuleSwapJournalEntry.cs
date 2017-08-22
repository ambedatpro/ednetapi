// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleSwapJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class ModuleSwapJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ModuleSwap;

        internal ModuleSwapJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("FromSlot")]
        public string FromSlot { get; internal set; }

        [JsonProperty("ToSlot")]
        public string ToSlot { get; internal set; }

        [JsonProperty("FromItem")]
        public string FromItemId { get; internal set; }

        [JsonProperty("FromItem_Localised")]
        public string FromItem { get; internal set; }

        [JsonProperty("ToItem")]
        public string ToItemId { get; internal set; }

        [JsonProperty("ToItem_Localised")]
        public string ToItem { get; internal set; }

        [JsonProperty("Ship")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        public int ShipId { get; internal set; }
    }
}