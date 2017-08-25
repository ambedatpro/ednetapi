// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaterialCollectedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("type of material (Raw/Encoded/Manufactured)")]
        public string CategoryRaw { get; internal set; }

        [JsonIgnore]
        [Description("type of material (Raw/Encoded/Manufactured)")]
        public MaterialType Category => CategoryRaw.GetEnumValue<MaterialType>();

        [JsonProperty("Name")]
        [Description("name of material")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        [Description("number of units collected")]
        public int Count { get; internal set; }
    }
}