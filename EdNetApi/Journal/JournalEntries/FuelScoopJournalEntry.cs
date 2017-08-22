// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FuelScoopJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class FuelScoopJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.FuelScoop;

        internal FuelScoopJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Scooped")]
        public double Scooped { get; internal set; }

        [JsonProperty("Total")]
        public double Total { get; internal set; }
    }
}