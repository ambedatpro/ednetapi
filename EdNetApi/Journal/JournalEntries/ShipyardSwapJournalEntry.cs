// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipyardSwapJournalEntry.cs" company="Martin Amareld">
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

    public class ShipyardSwapJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ShipyardSwap;

        internal ShipyardSwapJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ShipType")]
        [Description("type of ship being switched to")]
        public string ShipTypeRaw { get; internal set; }

        [JsonIgnore]
        [Description("type of ship being switched to")]
        public ShipType ShipType => ShipTypeRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("")]
        public int ShipId { get; internal set; }

        [JsonProperty("StoreOldShip")]
        [Description("(if storing old ship) type of ship being stored")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        [Description("")]
        public int StoreShipId { get; internal set; }
    }
}