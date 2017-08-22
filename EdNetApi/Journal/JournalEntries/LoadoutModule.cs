// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadoutModule.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using Newtonsoft.Json;

    public class LoadoutModule
    {
        internal LoadoutModule()
        {
        }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("On")]
        public bool On { get; internal set; }

        [JsonProperty("Priority")]
        public int Priority { get; internal set; }

        [JsonProperty("Health")]
        public double Health { get; internal set; }

        [JsonProperty("Value")]
        public int Value { get; internal set; }

        [JsonProperty("AmmoInClip")]
        public int AmmoInClip { get; internal set; }

        [JsonProperty("AmmoInHopper")]
        public int AmmoInHopper { get; internal set; }
    }
}