// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerProgressJournalEntry.cs" company="Martin Amareld">
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

    public class EngineerProgressJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EngineerProgress;

        internal EngineerProgressJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Engineer")]
        [Description("name of engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Progress")]
        [Description("progress stage (Invited/Acquainted/Unlocked/Barred)")]
        public string ProgressRaw { get; internal set; }

        [JsonIgnore]
        [Description("progress stage (Invited/Acquainted/Unlocked/Barred)")]
        public ProgressState Progress => ProgressRaw.GetEnumValue<ProgressState>();

        [JsonProperty("Rank")]
        [Description("rank reached (when unlocked)")]
        public int Rank { get; internal set; }
    }
}