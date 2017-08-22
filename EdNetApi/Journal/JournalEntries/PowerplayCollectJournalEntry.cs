// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PowerplayCollectJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class PowerplayCollectJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.PowerplayCollect;

        internal PowerplayCollectJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Type")]
        public string TypeId { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }
    }
}