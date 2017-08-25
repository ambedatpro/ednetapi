// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleRetrieveJournalEntry.cs" company="Martin Amareld">
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
        [Description("")]
        public string Slot { get; internal set; }

        [JsonProperty("RetrievedItem")]
        [Description("")]
        public string RetrievedItemId { get; internal set; }

        [JsonProperty("RetrievedItem_Localised")]
        [Description("")]
        public string RetrievedItem { get; internal set; }

        [JsonProperty("Ship")]
        [Description("")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        [Description("")]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("")]
        public int ShipId { get; internal set; }

        [JsonProperty("SwapOutItem")]
        [Description("")]
        public string SwapOutItemId { get; internal set; }

        [JsonProperty("SwapOutItem_Localised")]
        [Description("")]
        public string SwapOutItem { get; internal set; }

        [JsonProperty("Cost")]
        [Description("")]
        public int Cost { get; internal set; }

        [JsonProperty("EngineerModifications")]
        [Description("name of modification blueprint, if any")]
        public string EngineerModifications { get; internal set; }
    }
}