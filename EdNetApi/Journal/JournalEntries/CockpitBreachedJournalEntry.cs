// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CockpitBreachedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class CockpitBreachedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.CockpitBreached;

        internal CockpitBreachedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }
    }
}