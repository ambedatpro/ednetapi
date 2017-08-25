// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResurrectJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class ResurrectJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Resurrect;

        internal ResurrectJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Option")]
        [Description("the option selected on the insurance rebuy screen")]
        public string Option { get; internal set; }

        [JsonProperty("Cost")]
        [Description("the price paid")]
        public int Cost { get; internal set; }

        [JsonProperty("Bankrupt")]
        [Description("whether the commander declared bankruptcy")]
        public bool Bankrupt { get; internal set; }
    }
}