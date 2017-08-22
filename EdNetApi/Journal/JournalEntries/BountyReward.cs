// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BountyReward.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using Newtonsoft.Json;

    public class BountyReward
    {
        internal BountyReward()
        {
        }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Reward")]
        public int Reward { get; internal set; }
    }
}