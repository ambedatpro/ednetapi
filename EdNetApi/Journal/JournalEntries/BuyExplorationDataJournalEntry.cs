// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuyExplorationDataJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class BuyExplorationDataJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.BuyExplorationData;

        internal BuyExplorationDataJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("System")]
        [Description("")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        [Description("")]
        public int Cost { get; internal set; }
    }
}