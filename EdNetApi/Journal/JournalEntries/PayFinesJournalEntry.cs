// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayFinesJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class PayFinesJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.PayFines;

        internal PayFinesJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Amount")]
        [Description("(total amount paid , including any broker fee)")]
        public int Amount { get; internal set; }
    }
}