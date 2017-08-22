// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TradeRank.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum TradeRank
    {
        UnknownValue = -1,
        Penniless = 0,

        [Description("Mostly Penniless")]
        MostlyPenniless = 1,
        Peddler = 2,
        Dealer = 3,
        Merchant = 4,
        Broker = 5,
        Entrepreneur = 6,
        Tycoon = 7,
        Elite = 8
    }
}