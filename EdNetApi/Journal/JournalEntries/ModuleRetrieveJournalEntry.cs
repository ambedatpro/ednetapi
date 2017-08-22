// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleRetrieveJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class ModuleRetrieveJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ModuleRetrieve;

        internal ModuleRetrieveJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("RetrievedItem")]
        public string RetrievedItemId { get; internal set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItem { get; internal set; }

        [JsonProperty("Ship")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        public int ShipId { get; internal set; }

        [JsonProperty("SwapOutItem")]
        public string SwapOutItemId { get; internal set; }

        [JsonProperty("SwapOutItem_Localised")]
        public string SwapOutItem { get; internal set; }

        [JsonProperty("Cost")]
        public int Cost { get; internal set; }
    }
}