using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KissU.Surging.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// TypeExtensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Friendlies the identifier.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="fullyQualified">if set to <c>true</c> [fully qualified].</param>
        /// <returns>System.String.</returns>
        public static string FriendlyId(this Type type, bool fullyQualified = false)
        {
            var typeName = fullyQualified
                ? type.FullNameSansTypeArguments().Replace("+", ".")
                : type.Name;

            if (type.GetTypeInfo().IsGenericType)
            {
                var genericArgumentIds = type.GetGenericArguments()
                    .Select(t => t.FriendlyId(fullyQualified))
                    .ToArray();

                return new StringBuilder(typeName)
                    .Replace(string.Format("`{0}", genericArgumentIds.Count()), string.Empty)
                    .Append(string.Format("[{0}]", string.Join(",", genericArgumentIds).TrimEnd(',')))
                    .ToString();
            }

            return typeName;
        }

        /// <summary>
        /// Determines whether the specified type is nullable.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is nullable; otherwise, <c>false</c>.</returns>
        internal static bool IsNullable(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        /// <summary>
        /// Determines whether [is f sharp option] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is f sharp option] [the specified type]; otherwise, <c>false</c>.</returns>
        internal static bool IsFSharpOption(this Type type)
        {
            return type.FullNameSansTypeArguments() == "Microsoft.FSharp.Core.FSharpOption`1";
        }

        private static string FullNameSansTypeArguments(this Type type)
        {
            if (string.IsNullOrEmpty(type.FullName)) return string.Empty;

            var fullName = type.FullName;
            var chopIndex = fullName.IndexOf("[[");
            return chopIndex == -1 ? fullName : fullName.Substring(0, chopIndex);
        }
    }
}