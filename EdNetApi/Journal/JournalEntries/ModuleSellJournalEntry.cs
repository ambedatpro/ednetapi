// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleSellJournalEntry.cs" company="Martin Amareld">
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

    public class ModuleSellJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ModuleSell;

        internal ModuleSellJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Slot")]
        [Description("")]
        public string Slot { get; internal set; }

        [JsonProperty("SellItem")]
        [Description("")]
        public string SellItemId { get; internal set; }

        [JsonProperty("SellItem_Localised")]
        [Description("")]
        public string SellItem { get; internal set; }

        [JsonProperty("SellPrice")]
        [Description("")]
        public int SellPrice { get; internal set; }

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