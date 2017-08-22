// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleSellRemoteJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class ModuleSellRemoteJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ModuleSellRemote;

        internal ModuleSellRemoteJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("StorageSlot")]
        public int StorageSlot { get; internal set; }

        [JsonProperty("SellItem")]
        public string SellItemId { get; internal set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItem { get; internal set; }

        [JsonProperty("ServerId")]
        public int ServerId { get; internal set; }

        [JsonProperty("SellPrice")]
        public int SellPrice { get; internal set; }

        [JsonProperty("Ship")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        public int ShipId { get; internal set; }
    }
}