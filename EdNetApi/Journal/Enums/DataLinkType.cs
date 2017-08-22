// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataLinkType.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum DataLinkType
    {
        UnknownValue = -1,

        [Description("Data Link")]
        DataLink = 0,

        [Description("Data Point")]
        DataPoint,

        [Description("Listening Post")]
        ListeningPost,

        [Description("Abandoned Data Log")]
        AbandonedDataLog,

        [Description("Wrecked Ship")]
        WreckedShip,

        [Description("Tourist Beacon")]
        TouristBeacon,
    }
}