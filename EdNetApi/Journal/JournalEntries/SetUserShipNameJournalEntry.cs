// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetUserShipNameJournalEntry.cs" company="Martin Amareld">
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

    public class SetUserShipNameJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.SetUserShipName;

        internal SetUserShipNameJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Ship")]
        [Description("Ship model (eg CobraMkIII)")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        [Description("Ship model (eg CobraMkIII)")]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("player's ship ID number")]
        public int ShipId { get; internal set; }

        [JsonProperty("UserShipName")]
        [Description("selected name")]
        public string UserShipName { get; internal set; }

        [JsonProperty("UserShipId")]
        [Description("selected ship id")]
        public string UserShipId { get; internal set; }
    }
}