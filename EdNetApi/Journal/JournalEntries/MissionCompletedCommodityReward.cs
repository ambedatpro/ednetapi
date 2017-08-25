// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionCompletedCommodityReward.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class MissionCompletedCommodityReward
    {
        internal MissionCompletedCommodityReward()
        {
        }

        [JsonProperty("Name")]
        [Description("mission type")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        [Description("")]
        public int Count { get; internal set; }
    }
}