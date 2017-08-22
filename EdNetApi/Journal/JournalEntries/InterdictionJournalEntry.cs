// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterdictionJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class InterdictionJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Interdiction;

        internal InterdictionJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Success")]
        public bool Success { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Interdicted")]
        public string Interdicted { get; internal set; }
    }
}