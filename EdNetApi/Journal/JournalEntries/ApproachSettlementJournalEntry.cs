// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApproachSettlementJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class ApproachSettlementJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ApproachSettlement;

        internal ApproachSettlementJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Name")]
        [Description("")]
        public string Name { get; internal set; }
    }
}