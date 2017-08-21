// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoolExtensions.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    public static class BoolExtensions
    {
        public static T GetEnumValue<T>(this bool value)
        {
            var intValue = value ? 1 : 0;
            return intValue.GetEnumValue<T>();
        }
    }
}