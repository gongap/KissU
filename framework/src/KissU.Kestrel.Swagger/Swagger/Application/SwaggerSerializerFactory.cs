using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KissU.Kestrel.Swagger.Swagger.Application
{
    /// <summary>
    /// SwaggerSerializerFactory.
    /// </summary>
    public class SwaggerSerializerFactory
    {
        /// <summary>
        /// Creates the specified application json options.
        /// </summary>
        /// <param name="applicationJsonOptions">The application json options.</param>
        /// <returns>JsonSerializer.</returns>
        public static JsonSerializer Create(IOptions<MvcNewtonsoftJsonOptions> applicationJsonOptions)
        {
            // TODO: Should this handle case where mvcJsonOptions.Value == null?
            return new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = applicationJsonOptions.Value.SerializerSettings.Formatting,
                ContractResolver = new SwaggerContractResolver(applicationJsonOptions.Value.SerializerSettings)
            };
        }
    }
}