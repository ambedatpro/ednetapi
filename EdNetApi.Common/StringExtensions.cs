// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Newtonsoft.Json;

    public static class StringExtensions
    {
        private static readonly JsonSerializerSettings Settings =
            new JsonSerializerSettings { ContractResolver = new JsonInternalResolver() };

        private static readonly Dictionary<Type, Dictionary<string, object>> EnumStringCache =
            new Dictionary<Type, Dictionary<string, object>>();

        private static readonly Regex PascalCaseRegex = new Regex(@"[A-Z]{2,}(?![a-z])", RegexOptions.Compiled);

        public static T DeserializeJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value, Settings);
        }

        public static T GetEnumValue<T>(this string value)
            where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return (T)Enum.ToObject(typeof(T), -1);
            }

            var enumType = typeof(T);
            if (EnumStringCache.ContainsKey(enumType))
            {
                if (EnumStringCache[enumType].ContainsKey(value))
                {
                    return (T)EnumStringCache[enumType][value];
                }
            }
            else
            {
                EnumStringCache.Add(enumType, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase));
            }

            if (Enum.TryParse(value, true, out T enumValue))
            {
                EnumStringCache[enumType][value] = enumValue;
                return (T)EnumStringCache[enumType][value];
            }

            var enumValues = Enum.GetValues(typeof(T)).Cast<object>();
            var enumObject = enumValues.FirstOrDefault(
                v =>
                    {
                        var jsonProperty = ((Enum)v).JsonProperty();
                        return jsonProperty != null && jsonProperty.Equals(value, StringComparison.OrdinalIgnoreCase);
                    });
            if (enumObject != null)
            {
                EnumStringCache[enumType][value] = (T)enumObject;
                return (T)EnumStringCache[enumType][value];
            }

            FeedbackManager.SendFeedback(() => $@"Failed to parse enum ""{typeof(T).Name}"" from ""{value}""");
            return (T)Enum.ToObject(typeof(T), -1);
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