﻿using System;
using KissU.Core.Swagger.Swagger.Model;
using KissU.Core.Swagger.SwaggerGen.Generator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KissU.Core.Swagger.SwaggerGen.Application
{
    public static class SwaggerGenServiceCollectionExtensions
    {
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

        public static void ConfigureSwaggerGen(
            this IServiceCollection services,
            Action<SwaggerGenOptions> setupAction)
        {
            services.Configure(setupAction);
        }
    }
}
