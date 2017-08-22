// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiningRefinedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class MiningRefinedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MiningRefined;

        internal MiningRefinedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Type")]
        public string TypeId { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string Type { get; internal set; }
    }
}