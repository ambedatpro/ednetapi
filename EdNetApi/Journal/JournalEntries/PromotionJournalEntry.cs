// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionJournalEntry.cs" company="Martin Amareld">
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
        [Description("new rank")]
        public int TradeRaw { get; internal set; }

        [JsonIgnore]
        [Description("new rank")]
        public TradeRank Trade => TradeRaw.GetEnumValue<TradeRank>();

        [JsonProperty("Federation")]
        [Description("")]
        public int FederationRaw { get; internal set; }

        [JsonIgnore]
        [Description("")]
        public FederationRank Federation => FederationRaw.GetEnumValue<FederationRank>();

        [JsonProperty("Explore")]
        [Description("new rank")]
        public int ExploreRaw { get; internal set; }

        [JsonIgnore]
        [Description("new rank")]
        public ExplorationRank Explore => ExploreRaw.GetEnumValue<ExplorationRank>();

        [JsonProperty("Empire")]
        [Description("")]
        public int EmpireRaw { get; internal set; }

        [JsonIgnore]
        [Description("")]
        public EmpireRank Empire => EmpireRaw.GetEnumValue<EmpireRank>();
    }
}