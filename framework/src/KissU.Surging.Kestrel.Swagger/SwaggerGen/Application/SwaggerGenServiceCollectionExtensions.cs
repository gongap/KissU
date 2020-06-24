using System;
using KissU.Surging.Kestrel.Swagger.Swagger.Model;
using KissU.Surging.Kestrel.Swagger.SwaggerGen.Generator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KissU.Surging.Kestrel.Swagger.SwaggerGen.Application
{
    /// <summary>
    /// SwaggerGenServiceCollectionExtensions.
    /// </summary>
    public static class SwaggerGenServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the swagger gen.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddSwaggerGen(
            this IServiceCollection services,
            Action<SwaggerGenOptions> setupAction = null)
        {
            // Add Mvc convention to ensure ApiExplorer is enabled for all actions
            services.Configure<MvcOptions>(c =>
                c.Conventions.Add(new SwaggerApplicationConvention()));

            // Register generator and it's dependencies
            services.AddTransient<ISwaggerProvider, SwaggerGenerator>();
            services.AddTransient<ISchemaRegistryFactory, SchemaRegistryFactory>();

            // Register custom configurators that assign values from SwaggerGenOptions (i.e. high level config)
            // to the service-specific options (i.e. lower-level config)
            services.AddTransient<IConfigureOptions<SwaggerGeneratorOptions>, ConfigureSwaggerGeneratorOptions>();
            services.AddTransient<IConfigureOptions<SchemaRegistryOptions>, ConfigureSchemaRegistryOptions>();

            if (setupAction != null) services.ConfigureSwaggerGen(setupAction);

            return services;
        }

        /// <summary>
        /// Configures the swagger gen.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="setupAction">The setup action.</param>
        public static void ConfigureSwaggerGen(
            this IServiceCollection services,
            Action<SwaggerGenOptions> setupAction)
        {
            services.Configure(setupAction);
        }
    }
}