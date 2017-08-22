// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LaunchSrvJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class LaunchSrvJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.LaunchSrv;

        internal LaunchSrvJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }
    }
}