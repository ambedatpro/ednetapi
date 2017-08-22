// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayLegacyFinesJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class PayLegacyFinesJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.PayLegacyFines;

        internal PayLegacyFinesJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Amount")]
        public int Amount { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }
    }
}