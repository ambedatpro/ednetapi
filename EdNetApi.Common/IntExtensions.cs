// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntExtensions.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;

    public static class IntExtensions
    {
        public static T GetEnumValue<T>(this int value)
        {
            return Enum.IsDefined(typeof(T), value)
                       ? (T)Enum.ToObject(typeof(T), value)
                       : (T)Enum.ToObject(typeof(T), -1);
        }
    }
}