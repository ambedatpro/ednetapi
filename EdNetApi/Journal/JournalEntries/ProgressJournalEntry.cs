// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("percent progress to next rank")]
        public int Combat { get; internal set; }

        [JsonProperty("Trade")]
        [Description("\"")]
        public int Trade { get; internal set; }

        [JsonProperty("Explore")]
        [Description("\"")]
        public int Explore { get; internal set; }

        [JsonProperty("Empire")]
        [Description("\"")]
        public int Empire { get; internal set; }

        [JsonProperty("Federation")]
        [Description("\"")]
        public int Federation { get; internal set; }

        [JsonProperty("CQC")]
        [Description("\"")]
        public int Cqc { get; internal set; }
    }
}