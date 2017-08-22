// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SellExplorationDataJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class SellExplorationDataJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.SellExplorationData;

        internal SellExplorationDataJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Systems")]
        public List<string> SystemsList { get; internal set; }

        [JsonProperty("BaseValue")]
        public int BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public int Bonus { get; internal set; }
    }
}