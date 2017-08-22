// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class PromotionJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Promotion;

        internal PromotionJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Trade")]
        public int TradeRaw { get; internal set; }

        [JsonIgnore]
        public TradeRank Trade => TradeRaw.GetEnumValue<TradeRank>();

        [JsonProperty("Federation")]
        public int FederationRaw { get; internal set; }

        [JsonIgnore]
        public FederationRank Federation => FederationRaw.GetEnumValue<FederationRank>();

        [JsonProperty("Explore")]
        public int ExploreRaw { get; internal set; }

        [JsonIgnore]
        public ExplorationRank Explore => ExploreRaw.GetEnumValue<ExplorationRank>();

        [JsonProperty("Empire")]
        public int EmpireRaw { get; internal set; }

        [JsonIgnore]
        public EmpireRank Empire => EmpireRaw.GetEnumValue<EmpireRank>();
    }
}