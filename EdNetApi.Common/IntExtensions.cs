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
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.ToObject(typeof(T), value);
            }

            FeedbackManager.SendFeedback(() => $@"Failed to cast ""{value}"" to enum ""{typeof(T).Name}""");
            return (T)Enum.ToObject(typeof(T), -1);
        }
    }
}