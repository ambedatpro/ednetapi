// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FuelScoopJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("tons fuel scooped")]
        public double Scooped { get; internal set; }

        [JsonProperty("Total")]
        [Description("total fuel level after scooping")]
        public double Total { get; internal set; }
    }
}