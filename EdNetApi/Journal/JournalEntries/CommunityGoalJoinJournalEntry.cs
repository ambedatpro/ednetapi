// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunityGoalJoinJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class CommunityGoalJoinJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.CommunityGoalJoin;

        internal CommunityGoalJoinJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }
    }
}