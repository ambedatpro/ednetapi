// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatRank.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum CombatRank
    {
        UnknownValue = -1,
        Harmless = 0,

        [Description("Mosty Harmless")]
        MostyHarmless = 1,
        Novice = 2,
        Competent = 3,
        Expert = 4,
        Master = 5,
        Dagnerous = 6,
        Deadly = 7,
        Elite = 8
    }
}