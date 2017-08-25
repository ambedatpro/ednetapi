// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipyardNewJournalEntry.cs" company="Martin Amareld">
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

    public class ShipyardNewJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ShipyardNew;

        internal ShipyardNewJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ShipType")]
        [Description("")]
        public string ShipTypeRaw { get; internal set; }

        [JsonIgnore]
        [Description("")]
        public ShipType ShipType => ShipTypeRaw.GetEnumValue<ShipType>();

        [JsonProperty("NewShipID")]
        [Description("")]
        public int NewShipId { get; internal set; }
    }
}