// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RankJournalEntry.cs" company="Martin Amareld">
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

    public class RankJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Rank;

        internal RankJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Combat")]
        [Description("rank on scale 0-8")]
        public int CombatRaw { get; internal set; }

        [JsonIgnore]
        [Description("rank on scale 0-8")]
        public CombatRank Combat => CombatRaw.GetEnumValue<CombatRank>();

        [JsonProperty("Trade")]
        [Description("rank on scale 0-8")]
        public int TradeRaw { get; internal set; }

        [JsonIgnore]
        [Description("rank on scale 0-8")]
        public TradeRank Trade => TradeRaw.GetEnumValue<TradeRank>();

        [JsonProperty("Explore")]
        [Description("rank on scale 0-8")]
        public int ExploreRaw { get; internal set; }

        [JsonIgnore]
        [Description("rank on scale 0-8")]
        public ExplorationRank Explore => ExploreRaw.GetEnumValue<ExplorationRank>();

        [JsonProperty("Empire")]
        [Description("military rank")]
        public int EmpireRaw { get; internal set; }

        [JsonIgnore]
        [Description("military rank")]
        public EmpireRank Empire => EmpireRaw.GetEnumValue<EmpireRank>();

        [JsonProperty("Federation")]
        [Description("military rank")]
        public int FederationRaw { get; internal set; }

        [JsonIgnore]
        [Description("military rank")]
        public FederationRank Federation => FederationRaw.GetEnumValue<FederationRank>();

        [JsonProperty("CQC")]
        [Description("rank on scale 0-8")]
        public int CqcRaw { get; internal set; }

        [JsonIgnore]
        [Description("rank on scale 0-8")]
        public CqcRank Cqc => CqcRaw.GetEnumValue<CqcRank>();
    }
}