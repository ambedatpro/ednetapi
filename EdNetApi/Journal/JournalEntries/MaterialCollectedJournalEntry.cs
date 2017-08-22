// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaterialCollectedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class MaterialCollectedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MaterialCollected;

        internal MaterialCollectedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Category")]
        public string CategoryRaw { get; internal set; }

        [JsonIgnore]
        public MaterialType Category => CategoryRaw.GetEnumValue<MaterialType>();

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }
    }
}