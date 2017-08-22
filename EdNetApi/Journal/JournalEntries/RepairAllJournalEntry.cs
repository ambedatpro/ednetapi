// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairAllJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class RepairAllJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.RepairAll;

        internal RepairAllJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Cost")]
        public int Cost { get; internal set; }
    }
}