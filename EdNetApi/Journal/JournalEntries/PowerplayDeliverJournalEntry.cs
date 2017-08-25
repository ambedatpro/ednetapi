// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PowerplayDeliverJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class PowerplayDeliverJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.PowerplayDeliver;

        internal PowerplayDeliverJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Power")]
        [Description("")]
        public string Power { get; internal set; }

        [JsonProperty("Type")]
        [Description("")]
        public string TypeId { get; internal set; }

        [JsonProperty("Type_Localised")]
        [Description("")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        [Description("")]
        public int Count { get; internal set; }
    }
}