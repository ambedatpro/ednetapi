// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherType.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum VoucherType
    {
        UnknownValue = -1,
        [Description("Combat Bond")]
        CombatBond = 0,
        Bounty,
        Trade,
        Settlement,
        Scannable
    }
}