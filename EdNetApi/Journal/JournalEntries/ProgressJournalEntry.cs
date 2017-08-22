// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class ProgressJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Progress;

        internal ProgressJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Combat")]
        public int Combat { get; internal set; }

        [JsonProperty("Trade")]
        public int Trade { get; internal set; }

        [JsonProperty("Explore")]
        public int Explore { get; internal set; }

        [JsonProperty("Empire")]
        public int Empire { get; internal set; }

        [JsonProperty("Federation")]
        public int Federation { get; internal set; }

        [JsonProperty("CQC")]
        public int Cqc { get; internal set; }
    }
}