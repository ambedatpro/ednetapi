// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingType.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    public enum SettingType
    {
        SchemaVersion = 0,
        LastProcessedJournal,
        Commander,
        Ship,
        Location,
        CurrentLoadout,
        ActiveMissions
    }
}