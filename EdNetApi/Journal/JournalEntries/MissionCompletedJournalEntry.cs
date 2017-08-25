// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionCompletedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class MissionCompletedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MissionCompleted;

        internal MissionCompletedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Faction")]
        [Description("faction name")]
        public string Faction { get; internal set; }

        [JsonProperty("Name")]
        [Description("mission type")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        [Description("")]
        public int MissionId { get; internal set; }

        [JsonProperty("DestinationSystem")]
        [Description("")]
        public string DestinationSystem { get; internal set; }

        [JsonProperty("DestinationStation")]
        [Description("")]
        public string DestinationStation { get; internal set; }

        [JsonProperty("Reward")]
        [Description("value of reward")]
        public int Reward { get; internal set; }

        [JsonProperty("Commodity")]
        [Description("")]
        public string CommodityId { get; internal set; }

        [JsonProperty("Commodity_Localised")]
        [Description("")]
        public string Commodity { get; internal set; }

        [JsonProperty("Count")]
        [Description("")]
        public int Count { get; internal set; }

        [JsonProperty("CommodityReward")]
        [Description("[] (names and counts of any commodity rewards)")]
        public List<MissionCompletedCommodityReward> CommodityRewardList { get; internal set; }

        [JsonProperty("Donation")]
        [Description("donation offered (for altruism missions)")]
        public int Donation { get; internal set; }

        [JsonProperty("Target")]
        [Description("")]
        public string TargetId { get; internal set; }

        [JsonProperty("Target_Localised")]
        [Description("")]
        public string Target { get; internal set; }

        [JsonProperty("TargetFaction")]
        [Description("")]
        public string TargetFaction { get; internal set; }

        [JsonProperty("TargetType")]
        [Description("")]
        public string TargetTypeId { get; internal set; }

        [JsonProperty("TargetType_Localised")]
        [Description("")]
        public string TargetType { get; internal set; }

        [JsonProperty("KillCount")]
        [Description("")]
        public int KillCount { get; internal set; }
    }
}