// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionAcceptedJournalEntry.cs" company="Martin Amareld">
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

    public class MissionAcceptedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MissionAccepted;

        internal MissionAcceptedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Faction")]
        [Description("faction offering mission")]
        public string Faction { get; internal set; }

        [JsonProperty("Name")]
        [Description("name of mission")]
        public string Name { get; internal set; }

        [JsonProperty("Commodity")]
        [Description("commodity type")]
        public string CommodityId { get; internal set; }

        [JsonProperty("Commodity_Localised")]
        [Description("")]
        public string Commodity { get; internal set; }

        [JsonProperty("Count")]
        [Description("number required / to deliver")]
        public int Count { get; internal set; }

        [JsonProperty("DestinationSystem")]
        [Description("")]
        public string DestinationSystem { get; internal set; }

        [JsonProperty("DestinationStation")]
        [Description("")]
        public string DestinationStation { get; internal set; }

        [JsonProperty("Expiry")]
        [Description("mission expiry time, in ISO 8601")]
        public DateTime Expiry { get; internal set; }

        [JsonProperty("Influence")]
        [Description("effect on influence (None/Low/Med/High)")]
        public string InfluenceRaw { get; internal set; }

        [JsonIgnore]
        [Description("effect on influence (None/Low/Med/High)")]
        public EffectType Influence => InfluenceRaw.GetEnumValue<EffectType>();

        [JsonProperty("Reputation")]
        [Description("effect on reputation (None/Low/Med/High)")]
        public string ReputationRaw { get; internal set; }

        [JsonIgnore]
        [Description("effect on reputation (None/Low/Med/High)")]
        public EffectType Reputation => ReputationRaw.GetEnumValue<EffectType>();

        [JsonProperty("MissionID")]
        [Description("")]
        public int MissionId { get; internal set; }

        [JsonProperty("Target")]
        [Description("name of target")]
        public string TargetId { get; internal set; }

        [JsonProperty("Target_Localised")]
        [Description("")]
        public string Target { get; internal set; }

        [JsonProperty("TargetFaction")]
        [Description("target’s faction")]
        public string TargetFaction { get; internal set; }

        [JsonProperty("TargetType")]
        [Description("type of target")]
        public string TargetTypeId { get; internal set; }

        [JsonProperty("TargetType_Localised")]
        [Description("")]
        public string TargetType { get; internal set; }

        [JsonProperty("KillCount")]
        [Description("number of targets")]
        public int KillCount { get; internal set; }

        [JsonProperty("PassengerCount")]
        [Description("")]
        public int PassengerCount { get; internal set; }

        [JsonProperty("PassengerVIPs")]
        [Description("bool")]
        public bool PassengerViPs { get; internal set; }

        [JsonProperty("PassengerWanted")]
        [Description("bool")]
        public bool PassengerWanted { get; internal set; }

        [JsonProperty("PassengerType")]
        [Description("eg Tourist, Soldier, Explorer,...")]
        public string PassengerType { get; internal set; }
    }
}