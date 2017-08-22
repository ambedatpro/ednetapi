// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CqcRank.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum CqcRank
    {
        UnknownValue = -1,
        Helpless = 0,

        [Description("Mostly Helpless")]
        MostlyHelpless = 1,
        Amateur = 2,

        [Description("Semi Professional")]
        SemiProfessional = 3,
        Professional = 4,
        Champion = 5,
        Hero = 6,
        Legend = 7,
        Elite = 8
    }
}