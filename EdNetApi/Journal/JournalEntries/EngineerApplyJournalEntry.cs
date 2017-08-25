// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerApplyJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class EngineerApplyJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EngineerApply;

        internal EngineerApplyJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Engineer")]
        [Description("name of engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Blueprint")]
        [Description("blueprint being applied")]
        public string Blueprint { get; internal set; }

        [JsonProperty("Level")]
        [Description("crafting level")]
        public int Level { get; internal set; }
    }
}