// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerContributionJournalEntry.cs" company="Martin Amareld">
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

    public class EngineerContributionJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EngineerContribution;

        internal EngineerContributionJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Engineer")]
        [Description("name of engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Type")]
        [Description("type of contribution (Commodity, materials, Credits, Bond, Bounty)")]
        public string TypeRaw { get; internal set; }

        [JsonIgnore]
        [Description("type of contribution (Commodity, materials, Credits, Bond, Bounty)")]
        public ContributionType Type => TypeRaw.GetEnumValue<ContributionType>();

        [JsonProperty("Commodity")]
        [Description("")]
        public string Commodity { get; internal set; }

        [JsonProperty("Quantity")]
        [Description("amount offered this time")]
        public int Quantity { get; internal set; }

        [JsonProperty("TotalQuantity")]
        [Description("total amount now donated")]
        public int TotalQuantity { get; internal set; }
    }
}