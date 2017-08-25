// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleBuyJournalEntry.cs" company="Martin Amareld">
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

    public class ModuleBuyJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ModuleBuy;

        internal ModuleBuyJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Slot")]
        [Description("the outfitting slot")]
        public string Slot { get; internal set; }

        [JsonProperty("BuyItem")]
        [Description("the module being purchased")]
        public string BuyItemId { get; internal set; }

        [JsonProperty("BuyItem_Localised")]
        [Description("")]
        public string BuyItem { get; internal set; }

        [JsonProperty("BuyPrice")]
        [Description("price paid")]
        public int BuyPrice { get; internal set; }

        [JsonProperty("Ship")]
        [Description("the players ship")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        [Description("the players ship")]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("")]
        public int ShipId { get; internal set; }

        [JsonProperty("SellItem")]
        [Description("item being sold")]
        public string SellItemId { get; internal set; }

        [JsonProperty("SellItem_Localised")]
        [Description("")]
        public string SellItem { get; internal set; }

        [JsonProperty("SellPrice")]
        [Description("sale price")]
        public int SellPrice { get; internal set; }

        [JsonProperty("StoredItem")]
        [Description("item being stored")]
        public string StoredItemId { get; internal set; }

        [JsonProperty("StoredItem_Localised")]
        [Description("")]
        public string StoredItem { get; internal set; }
    }
}