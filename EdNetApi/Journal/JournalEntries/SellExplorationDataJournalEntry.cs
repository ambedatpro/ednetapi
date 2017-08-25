// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SellExplorationDataJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;
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
        [Description("JSON array of system names")]
        public List<string> SystemsList { get; internal set; }

        [JsonProperty("BaseValue")]
        [Description("value of systems")]
        public int BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        [Description("bonus for first discoveries")]
        public int Bonus { get; internal set; }
    }
}