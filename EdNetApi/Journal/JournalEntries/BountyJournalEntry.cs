// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BountyJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

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
        [Description("an array of Faction names and the Reward values, as the target can have multiple bounties payable by different factions")]
        public List<BountyReward> RewardsList { get; internal set; }

        [JsonProperty("Target")]
        [Description("")]
        public string Target { get; internal set; }

        [JsonProperty("TotalReward")]
        [Description("")]
        public int TotalReward { get; internal set; }

        [JsonProperty("VictimFaction")]
        [Description("the victim’s faction")]
        public string VictimFaction { get; internal set; }
    }
}