// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadoutModule.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class LoadoutModule
    {
        internal LoadoutModule()
        {
        }

        [JsonProperty("Slot")]
        [Description("slot name")]
        public string Slot { get; internal set; }

        [JsonProperty("Item")]
        [Description("module name")]
        public string Item { get; internal set; }

        [JsonProperty("On")]
        [Description("bool, indicates on or off")]
        public bool On { get; internal set; }

        [JsonProperty("Priority")]
        [Description("power priority")]
        public int Priority { get; internal set; }

        [JsonProperty("Health")]
        [Description("")]
        public double Health { get; internal set; }

        [JsonProperty("Value")]
        [Description("")]
        public int Value { get; internal set; }

        [JsonProperty("AmmoInClip")]
        [Description("(if relevant) - (For a passenger cabin, AmmoInClip holds the number of places in the cabin)")]
        public int AmmoInClip { get; internal set; }

        [JsonProperty("AmmoInHopper")]
        [Description("(if relevant)")]
        public int AmmoInHopper { get; internal set; }
    }
}