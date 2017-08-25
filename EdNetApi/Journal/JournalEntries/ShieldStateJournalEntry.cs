// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShieldStateJournalEntry.cs" company="Martin Amareld">
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

    public class ShieldStateJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ShieldState;

        internal ShieldStateJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ShieldsUp")]
        [Description("")]
        public bool ShieldsUpRaw { get; internal set; }

        [JsonIgnore]
        [Description("")]
        public ShieldState ShieldsUp => ShieldsUpRaw.GetEnumValue<ShieldState>();
    }
}