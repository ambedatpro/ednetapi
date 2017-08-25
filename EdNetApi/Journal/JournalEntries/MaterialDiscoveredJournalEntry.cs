// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaterialDiscoveredJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class MaterialDiscoveredJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MaterialDiscovered;

        internal MaterialDiscoveredJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Category")]
        [Description("")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        [Description("")]
        public string Name { get; internal set; }

        [JsonProperty("DiscoveryNumber")]
        [Description("")]
        public int DiscoveryNumber { get; internal set; }
    }
}