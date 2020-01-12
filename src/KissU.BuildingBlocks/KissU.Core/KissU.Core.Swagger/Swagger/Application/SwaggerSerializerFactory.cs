using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KissU.Core.Swagger.Swagger.Application
{
    public class SwaggerSerializerFactory
    {
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
