// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EscapeInterdictionJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("interdicting pilot name")]
        public string Interdictor { get; internal set; }

        [JsonProperty("IsPlayer")]
        [Description("whether player or npc")]
        public bool IsPlayer { get; internal set; }
    }
}