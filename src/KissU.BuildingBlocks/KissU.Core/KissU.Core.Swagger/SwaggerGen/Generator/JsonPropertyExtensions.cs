using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// JsonPropertyExtensions.
    /// </summary>
    internal static class JsonPropertyExtensions
    {
        /// <summary>
        /// Determines whether the specified json property is required.
        /// </summary>
        /// <param name="jsonProperty">The json property.</param>
        /// <returns><c>true</c> if the specified json property is required; otherwise, <c>false</c>.</returns>
        internal static bool IsRequired(this JsonProperty jsonProperty)
        {
            if (jsonProperty.Required == Required.AllowNull)
                return true;

            if (jsonProperty.Required == Required.Always)
                return true;

            if (jsonProperty.HasAttribute<RequiredAttribute>())
                return true;

            return false;
        }

        /// <summary>
        /// Determines whether the specified json property is obsolete.
        /// </summary>
        /// <param name="jsonProperty">The json property.</param>
        /// <returns><c>true</c> if the specified json property is obsolete; otherwise, <c>false</c>.</returns>
        internal static bool IsObsolete(this JsonProperty jsonProperty)
        {
            return jsonProperty.HasAttribute<ObsoleteAttribute>();
        }

        /// <summary>
        /// Determines whether the specified json property has attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonProperty">The json property.</param>
        /// <returns><c>true</c> if the specified json property has attribute; otherwise, <c>false</c>.</returns>
        internal static bool HasAttribute<T>(this JsonProperty jsonProperty)
            where T : Attribute
        {
            if (!jsonProperty.TryGetMemberInfo(out var memberInfo))
                return false;

            return memberInfo.GetCustomAttribute<T>() != null;
        }

        /// <summary>
        /// Tries the get member information.
        /// </summary>
        /// <param name="jsonProperty">The json property.</param>
        /// <param name="memberInfo">The member information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool TryGetMemberInfo(this JsonProperty jsonProperty, out MemberInfo memberInfo)
        {
            if (jsonProperty.UnderlyingName == null)
            {
                memberInfo = null;
                return false;
            }

            var metadataAttribute = jsonProperty.DeclaringType.GetTypeInfo()
                .GetCustomAttributes(typeof(ModelMetadataTypeAttribute), true)
                .FirstOrDefault();

            var typeToReflect = metadataAttribute != null
                ? ((ModelMetadataTypeAttribute) metadataAttribute).MetadataType
                : jsonProperty.DeclaringType;

            memberInfo = typeToReflect.GetMember(jsonProperty.UnderlyingName).FirstOrDefault();

            return memberInfo != null;
        }
    }
}