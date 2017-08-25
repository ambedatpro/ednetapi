// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipyardBuyJournalEntry.cs" company="Martin Amareld">
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

    public class ShipyardBuyJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ShipyardBuy;

        internal ShipyardBuyJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ShipType")]
        [Description("ship being purchased")]
        public string ShipTypeRaw { get; internal set; }

        [JsonIgnore]
        [Description("ship being purchased")]
        public ShipType ShipType => ShipTypeRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipPrice")]
        [Description("purchase cost")]
        public int ShipPrice { get; internal set; }

        [JsonProperty("StoreOldShip")]
        [Description("(if storing old ship) ship type being stored")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        [Description("")]
        public int StoreShipId { get; internal set; }

        [JsonProperty("SellOldShip")]
        [Description("(if selling current ship) ship type being sold")]
        public string SellOldShip { get; internal set; }

        [JsonProperty("SellShipID")]
        [Description("")]
        public int SellShipId { get; internal set; }

        [JsonProperty("SellPrice")]
        [Description("(if selling current ship) ship sale price")]
        public int SellPrice { get; internal set; }
    }
}