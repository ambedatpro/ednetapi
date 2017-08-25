// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleSwapJournalEntry.cs" company="Martin Amareld">
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
        [Description("")]
        public string FromSlot { get; internal set; }

        [JsonProperty("ToSlot")]
        [Description("")]
        public string ToSlot { get; internal set; }

        [JsonProperty("FromItem")]
        [Description("")]
        public string FromItemId { get; internal set; }

        [JsonProperty("FromItem_Localised")]
        [Description("")]
        public string FromItem { get; internal set; }

        [JsonProperty("ToItem")]
        [Description("")]
        public string ToItemId { get; internal set; }

        [JsonProperty("ToItem_Localised")]
        [Description("")]
        public string ToItem { get; internal set; }

        [JsonProperty("Ship")]
        [Description("")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        [Description("")]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("")]
        public int ShipId { get; internal set; }
    }
}