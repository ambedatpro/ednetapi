// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DockingGrantedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class DockingGrantedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.DockingGranted;

        internal DockingGrantedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("LandingPad")]
        [Description("pad number")]
        public int LandingPad { get; internal set; }

        [JsonProperty("StationName")]
        [Description("name of station")]
        public string StationName { get; internal set; }
    }
}