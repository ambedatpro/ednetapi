// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RefuelAllJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class RefuelAllJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.RefuelAll;

        internal RefuelAllJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Cost")]
        public int Cost { get; internal set; }

        [JsonProperty("Amount")]
        public double Amount { get; internal set; }
    }
}