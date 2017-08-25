// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PassengersManifest.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class PassengersManifest
    {
        internal PassengersManifest()
        {
        }

        [JsonProperty("MissionID")]
        [Description("")]
        public int MissionId { get; internal set; }

        [JsonProperty("Type")]
        [Description("")]
        public string Type { get; internal set; }

        [JsonProperty("VIP")]
        [Description("")]
        public bool Vip { get; internal set; }

        [JsonProperty("Wanted")]
        [Description("")]
        public bool Wanted { get; internal set; }

        [JsonProperty("Count")]
        [Description("")]
        public int Count { get; internal set; }
    }
}