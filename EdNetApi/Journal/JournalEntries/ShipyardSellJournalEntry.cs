// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipyardSellJournalEntry.cs" company="Martin Amareld">
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

    public class ShipyardSellJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ShipyardSell;

        internal ShipyardSellJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ShipType")]
        [Description("type of ship being sold")]
        public string ShipTypeRaw { get; internal set; }

        [JsonIgnore]
        [Description("type of ship being sold")]
        public ShipType ShipType => ShipTypeRaw.GetEnumValue<ShipType>();

        [JsonProperty("SellShipID")]
        [Description("")]
        public int SellShipId { get; internal set; }

        [JsonProperty("ShipPrice")]
        [Description("sale price")]
        public int ShipPrice { get; internal set; }

        [JsonProperty("System")]
        [Description("(if ship is in another system) name of system")]
        public string System { get; internal set; }
    }
}