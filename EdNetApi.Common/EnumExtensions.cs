// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Newtonsoft.Json;

    public static class EnumExtensions
    {
        public static string Description(this Enum @enum)
        {
            var value = GetAttributeValue<DescriptionAttribute, string>(@enum, attribute => attribute.Description);
            return value;
        }

        public static string JsonProperty(this Enum @enum)
        {
            var value = GetAttributeValue<JsonPropertyAttribute, string>(@enum, attribute => attribute.PropertyName);
            return value;
        }

        public static TValue GetAttributeValue<TAttribute, TValue>(Enum @enum, Func<TAttribute, TValue> getValueFunc)
        {
            var enumType = @enum.GetType();
            var memberInfo = enumType.GetMember(@enum.ToString());
            var customAttributes = memberInfo[0].GetCustomAttributes(typeof(TAttribute), false);
            var customAttribute = (TAttribute)customAttributes.FirstOrDefault();
            return customAttribute != null ? getValueFunc(customAttribute) : default(TValue);
        }
    }
}