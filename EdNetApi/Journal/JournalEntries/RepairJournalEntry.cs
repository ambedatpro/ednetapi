// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class RepairJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Repair;

        internal RepairJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Item")]
        public string ItemRaw { get; internal set; }

        [JsonIgnore]
        public RepairType Item => ItemRaw.GetEnumValue<RepairType>();

        [JsonProperty("Cost")]
        public int Cost { get; internal set; }
    }
}