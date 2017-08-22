// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PassengersManifest.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using Newtonsoft.Json;

    public class PassengersManifest
    {
        internal PassengersManifest()
        {
        }

        [JsonProperty("MissionID")]
        public int MissionId { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("VIP")]
        public bool Vip { get; internal set; }

        [JsonProperty("Wanted")]
        public bool Wanted { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }
    }
}