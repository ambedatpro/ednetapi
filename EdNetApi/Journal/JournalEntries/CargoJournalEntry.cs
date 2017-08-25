// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CargoJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class CargoJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Cargo;

        internal CargoJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Inventory")]
        [Description("array of cargo, with Name and Count for each")]
        public List<CargoInventory> InventoryList { get; internal set; }
    }
}