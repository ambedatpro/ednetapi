// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FederationRank.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum FederationRank
    {
        UnknownValue = -1,
        None = 0,
        Recruit = 1,
        Cadet = 2,
        Midshipman = 3,

        [Description("Petty Officer")]
        PettyOfficer = 4,

        [Description("Chief Petty Officer")]
        ChiefPettyOfficer = 5,

        [Description("Warrant Officer")]
        WarrantOfficer = 6,
        Ensign = 7,
        Lieutenant = 8,

        [Description("Lt. Commander")]
        LtCommander = 9,

        [Description("Post Commander")]
        PostCommander = 10,

        [Description("Post Captain")]
        PostCaptain = 11,

        [Description("Rear Admiral")]
        RearAdmiral = 12,

        [Description("Vice Admiral")]
        ViceAdmiral = 13,
        Admiral = 14
    }
}