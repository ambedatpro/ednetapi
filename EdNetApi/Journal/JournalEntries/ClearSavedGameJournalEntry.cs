// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearSavedGameJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class ClearSavedGameJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ClearSavedGame;

        internal ClearSavedGameJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}