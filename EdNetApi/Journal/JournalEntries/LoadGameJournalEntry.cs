// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadGameJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class LoadGameJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.LoadGame;

        internal LoadGameJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Commander")]
        public string Commander { get; internal set; }

        [JsonProperty("Ship")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        public int ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("FuelCapacity")]
        public double FuelCapacity { get; internal set; }

        [JsonProperty("GameMode")]
        public string GameMode { get; internal set; }

        [JsonProperty("Credits")]
        public int Credits { get; internal set; }

        [JsonProperty("Loan")]
        public int Loan { get; internal set; }

        [JsonProperty("Group")]
        public string Group { get; internal set; }
    }
}