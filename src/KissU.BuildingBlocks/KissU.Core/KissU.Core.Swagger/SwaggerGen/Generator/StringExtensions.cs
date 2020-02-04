namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// StringExtensions.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts to camelcase.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        internal static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Converts to titlecase.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        internal static string ToTitleCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToUpperInvariant(value[0]) + value.Substring(1);
        }
    }
}