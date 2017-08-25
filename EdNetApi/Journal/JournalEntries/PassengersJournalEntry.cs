// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PassengersJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class PassengersJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Passengers;

        internal PassengersJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Manifest")]
        [Description("array of passenger records, each containing:")]
        public List<PassengersManifest> ManifestList { get; internal set; }
    }
}