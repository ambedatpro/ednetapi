// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;
    using System.Text.RegularExpressions;

    using Newtonsoft.Json;

    public static class StringExtensions
    {
        private static readonly JsonSerializerSettings Settings =
            new JsonSerializerSettings { ContractResolver = new JsonInternalResolver() };

        private static readonly Regex PascalCaseRegex = new Regex(@"[A-Z]{2,}(?![a-z])", RegexOptions.Compiled);

        public static T DeserializeJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value, Settings);
        }

        public static T GetEnumValue<T>(this string value) where T : struct
        {
            return Enum.TryParse(value, true, out T enumValue) ? enumValue : (T)Enum.ToObject(typeof(T), -1);
        }

        public static string ToPascalCase(this string value)
        {
            value = char.ToUpperInvariant(value[0]) + value.Substring(1);
            foreach (Match match in PascalCaseRegex.Matches(value))
            {
                var part = value.Substring(match.Index, match.Length);
                part = part[0] + part.Substring(1).ToLowerInvariant();
                value = value.Substring(0, match.Index) + part + value.Substring(match.Index + match.Length);
            }

            return value;
        }
    }
}