// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionAcceptedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

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
        public string Faction { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Commodity")]
        public string CommodityId { get; internal set; }

        [JsonProperty("Commodity_Localised")]
        public string Commodity { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; internal set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; internal set; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; internal set; }

        [JsonProperty("Influence")]
        public string InfluenceRaw { get; internal set; }

        [JsonIgnore]
        public EffectType Influence => InfluenceRaw.GetEnumValue<EffectType>();

        [JsonProperty("Reputation")]
        public string ReputationRaw { get; internal set; }

        [JsonIgnore]
        public EffectType Reputation => ReputationRaw.GetEnumValue<EffectType>();

        [JsonProperty("MissionID")]
        public int MissionId { get; internal set; }

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

        [JsonProperty("PassengerCount")]
        public int PassengerCount { get; internal set; }

        [JsonProperty("PassengerVIPs")]
        public bool PassengerViPs { get; internal set; }

        [JsonProperty("PassengerWanted")]
        public bool PassengerWanted { get; internal set; }

        [JsonProperty("PassengerType")]
        public string PassengerType { get; internal set; }
    }
}