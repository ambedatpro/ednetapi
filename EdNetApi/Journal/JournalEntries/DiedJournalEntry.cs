// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class DiedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Died;

        internal DiedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("KillerName")]
        public string KillerNameId { get; internal set; }

        [JsonProperty("KillerShip")]
        public string KillerShip { get; internal set; }

        [JsonProperty("KillerRank")]
        public string KillerRank { get; internal set; }

        [JsonProperty("KillerName_Localised")]
        public string KillerName { get; internal set; }
    }
}