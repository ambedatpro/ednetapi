// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonInternalResolver.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System.Reflection;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class JsonInternalResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);

            if (jsonProperty.Writable)
            {
                return jsonProperty;
            }

            var property = jsonProperty.DeclaringType.GetProperty(jsonProperty.PropertyName);
            var isInternalSet = property?.SetMethod?.IsAssembly;
            if (isInternalSet == true)
            {
                jsonProperty.Writable = true;
            }

            return jsonProperty;
        }
    }
}