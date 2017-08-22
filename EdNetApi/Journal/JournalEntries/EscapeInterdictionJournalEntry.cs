// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EscapeInterdictionJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class EscapeInterdictionJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EscapeInterdiction;

        internal EscapeInterdictionJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }
    }
}