// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairJournalEntry.cs" company="Martin Amareld">
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
        [Description("all, wear, hull, paint, or name of module")]
        public string ItemRaw { get; internal set; }

        [JsonIgnore]
        [Description("all, wear, hull, paint, or name of module")]
        public RepairType Item => ItemRaw.GetEnumValue<RepairType>();

        [JsonProperty("Cost")]
        [Description("cost of repair")]
        public int Cost { get; internal set; }
    }
}