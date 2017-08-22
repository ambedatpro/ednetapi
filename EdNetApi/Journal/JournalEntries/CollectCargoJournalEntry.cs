// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectCargoJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class CollectCargoJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.CollectCargo;

        internal CollectCargoJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Stolen")]
        public bool Stolen { get; internal set; }
    }
}