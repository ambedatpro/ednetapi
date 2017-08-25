// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DockingDeniedJournalEntry.cs" company="Martin Amareld">
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

    public class DockingDeniedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.DockingDenied;

        internal DockingDeniedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Reason")]
        [Description("reason for denial - Reasons include: NoSpace, TooLarge, Hostile, Offences, Distance, ActiveFighter, NoReason")]
        public string ReasonRaw { get; internal set; }

        [JsonIgnore]
        [Description("reason for denial - Reasons include: NoSpace, TooLarge, Hostile, Offences, Distance, ActiveFighter, NoReason")]
        public DockingDeniedType Reason => ReasonRaw.GetEnumValue<DockingDeniedType>();

        [JsonProperty("StationName")]
        [Description("name of station")]
        public string StationName { get; internal set; }
    }
}