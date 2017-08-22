// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BountyJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class BountyJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Bounty;

        internal BountyJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Rewards")]
        public List<BountyReward> RewardsList { get; internal set; }

        [JsonProperty("Target")]
        public string Target { get; internal set; }

        [JsonProperty("TotalReward")]
        public int TotalReward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }
    }
}