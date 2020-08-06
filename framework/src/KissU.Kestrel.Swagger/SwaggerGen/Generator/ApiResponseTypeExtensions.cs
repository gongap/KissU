using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KissU.Kestrel.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// ApiResponseTypeExtensions.
    /// </summary>
    public static class ApiResponseTypeExtensions
    {
        /// <summary>
        /// Determines whether [is default response] [the specified API response type].
        /// </summary>
        /// <param name="apiResponseType">Type of the API response.</param>
        /// <returns><c>true</c> if [is default response] [the specified API response type]; otherwise, <c>false</c>.</returns>
        internal static bool IsDefaultResponse(this ApiResponseType apiResponseType)
        {
            var propertyInfo = apiResponseType.GetType().GetProperty("IsDefaultResponse");
            if (propertyInfo != null)
            {
                return (bool) propertyInfo.GetValue(apiResponseType);
            }

            // ApiExplorer < 2.1.0 does not support default response.
            return false;
        }
    }
}