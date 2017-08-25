// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadGameJournalEntry.cs" company="Martin Amareld">
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
        [Description("commander name")]
        public string Commander { get; internal set; }

        [JsonProperty("Ship")]
        [Description("current ship type")]
        public string ShipRaw { get; internal set; }

        [JsonIgnore]
        [Description("current ship type")]
        public ShipType Ship => ShipRaw.GetEnumValue<ShipType>();

        [JsonProperty("ShipID")]
        [Description("ship id number (indicates which of your ships you are in)")]
        public int ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        [Description("user-defined ship name")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        [Description("user-defined ship ID string")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("FuelLevel")]
        [Description("current fuel")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("FuelCapacity")]
        [Description("size of main tank")]
        public double FuelCapacity { get; internal set; }

        [JsonProperty("GameMode")]
        [Description("Open, Solo or Group")]
        public string GameMode { get; internal set; }

        [JsonProperty("Credits")]
        [Description("current credit balance")]
        public int Credits { get; internal set; }

        [JsonProperty("Loan")]
        [Description("current loan")]
        public int Loan { get; internal set; }

        [JsonProperty("Group")]
        [Description("name of group (if in a group)")]
        public string Group { get; internal set; }
    }
}