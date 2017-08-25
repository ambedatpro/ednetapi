// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectCargoJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class CollectCargoJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.CollectCargo;

        internal CollectCargoJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Type")]
        [Description("cargo type")]
        public string Type { get; internal set; }

        [JsonProperty("Stolen")]
        [Description("whether stolen goods")]
        public bool Stolen { get; internal set; }
    }
}