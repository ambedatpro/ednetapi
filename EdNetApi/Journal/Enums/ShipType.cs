// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipType.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    using Newtonsoft.Json;

    public enum ShipType
    {
        UnknownValue = -1,

        Adder = 0,

        [Description("Asp Explorer")]
        Asp,

        [JsonProperty("CobraMkIII")]
        [Description("CobraMkIII")]
        CobraMkIii,
        Dolphin,

        [JsonProperty("Federation_Dropship")]
        [Description("Federation Dropship")]
        FederationDropship,

        [JsonProperty("Independant_Trader")]
        [Description("Independant Trader")]
        IndependantTrader,
        SideWinder,
        Vulture,
    }
}