// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupercruiseEntryJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class SupercruiseEntryJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.SupercruiseEntry;

        internal SupercruiseEntryJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
    }
}