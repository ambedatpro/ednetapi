// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TerraformState.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    public enum TerraformState
    {
        UnknownValue = -1,
        None = 0,
        Terraformable,
        Terraforming,
        Terraformed
    }
}