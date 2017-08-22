// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionCompletedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
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
        public string Faction { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public int MissionId { get; internal set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; internal set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; internal set; }

        [JsonProperty("Reward")]
        public int Reward { get; internal set; }

        [JsonProperty("Commodity")]
        public string CommodityId { get; internal set; }

        [JsonProperty("Commodity_Localised")]
        public string Commodity { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("CommodityReward")]
        public List<MissionCompletedCommodityReward> CommodityRewardList { get; internal set; }

        [JsonProperty("Donation")]
        public int Donation { get; internal set; }

        [JsonProperty("Target")]
        public string TargetId { get; internal set; }

        [JsonProperty("Target_Localised")]
        public string Target { get; internal set; }

        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; internal set; }

        [JsonProperty("TargetType")]
        public string TargetTypeId { get; internal set; }

        [JsonProperty("TargetType_Localised")]
        public string TargetType { get; internal set; }

        [JsonProperty("KillCount")]
        public int KillCount { get; internal set; }
    }
}