﻿using System.Linq;
using System.Reflection;
using KissU.AspNetCore.Internal;
using KissU.AspNetCore.Swagger.Internal;
using KissU.AspNetCore.Swagger.Swagger.Application;
using KissU.AspNetCore.Swagger.Swagger.Filters;
using KissU.AspNetCore.Swagger.Swagger.Model;
using KissU.AspNetCore.Swagger.SwaggerGen.Application;
using KissU.AspNetCore.Swagger.SwaggerUI;
using KissU.CPlatform.Runtime.Server;
using KissU.Modularity;
using Microsoft.Extensions.Configuration;

namespace KissU.AspNetCore.Swagger
{
    /// <summary>
    /// SwaggerModule.
    /// Implements the <see cref="AspNetCoreModule" />
    /// </summary>
    /// <seealso cref="AspNetCoreModule" />
    public class AspNetCoreSwaggerModule : AspNetCoreModule
    {
        private IServiceEntryProvider _serviceEntryProvider;
        private IServiceSchemaProvider _serviceSchemaProvider;

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            _serviceSchemaProvider = serviceProvider.GetInstances<IServiceSchemaProvider>();
            _serviceEntryProvider = serviceProvider.GetInstances<IServiceEntryProvider>();
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Configure(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
             var config = AppConfig.SwaggerConfig.Info ?? AppConfig.SwaggerOptions;
            if (config != null)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    var areaName = AppConfig.SwaggerConfig.Options?.IngressName;
                    c.SwaggerEndpoint($"../swagger/{config.Version}/swagger.json", config.Title, areaName);
                    c.SwaggerEndpoint(_serviceEntryProvider.GetALLEntries(), areaName);
                });
            }
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var config = AppConfig.SwaggerConfig.Info ?? AppConfig.SwaggerOptions;
            var swaggerOptions = AppConfig.SwaggerConfig.Options;
            if (config != null)
            {
                context.Services.AddSwaggerGen(options =>
                {
                    options.OperationFilter<AddAuthorizationOperationFilter>();
                    options.SwaggerDoc(config.Version, config);
                    if (swaggerOptions != null && swaggerOptions.IgnoreFullyQualified)
                    {
                        options.IgnoreFullyQualified();
                    }

                    options.GenerateSwaggerDoc(_serviceEntryProvider.GetALLEntries());
                    options.DocInclusionPredicateV2((docName, apiDesc) =>
                    {
                        if (docName == config.Version)
                            return true;
                        var assembly = apiDesc.Type.Assembly;

                        var title = assembly
                            .GetCustomAttributes(true)
                            .OfType<AssemblyTitleAttribute>();

                        return title.Any(v => v.Title == docName);
                    });
                    var xmlPaths = _serviceSchemaProvider.GetSchemaFilesPath();
                    foreach (var xmlPath in xmlPaths)
                        options.IncludeXmlComments(xmlPath, swaggerOptions.IncludeControllerXmlComments);
                });
            }
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            var section = CPlatform.AppConfig.GetSection("Swagger");
            if (section.Exists())
            {
                AppConfig.SwaggerOptions = section.Get<Info>();
                AppConfig.SwaggerConfig = section.Get<DocumentConfiguration>();
            }

            builder.RegisterType(typeof(DefaultServiceSchemaProvider)).As(typeof(IServiceSchemaProvider)).SingleInstance();
        }
    }
}