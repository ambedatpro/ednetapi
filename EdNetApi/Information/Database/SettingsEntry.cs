// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    using ServiceStack.DataAnnotations;

    public class SettingsEntry
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Index(Unique = true)]
        public SettingType Type { get; set; }

        public string Value { get; set; }
    }
}