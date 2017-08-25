// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipyardTransferJournalEntry.cs" company="Martin Amareld">
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

    public class ShipyardTransferJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ShipyardTransfer;

        internal ShipyardTransferJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ShipType")]
        [Description("type of ship")]
        public string ShipTypeRaw { get; internal set; }

        [JsonIgnore]
        [Description("type of ship")]
        public ShipType ShipType => ShipTypeRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("")]
        public int ShipId { get; internal set; }

        [JsonProperty("System")]
        [Description("where it is")]
        public string System { get; internal set; }

        [JsonProperty("Distance")]
        [Description("how far away")]
        public double Distance { get; internal set; }

        [JsonProperty("TransferPrice")]
        [Description("cost of transfer")]
        public int TransferPrice { get; internal set; }
    }
}