﻿using System.Linq;
using System.Reflection;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.KestrelHttpServer;
using KissU.Core.Swagger.Internal;
using KissU.Core.Swagger.Swagger.Application;
using KissU.Core.Swagger.Swagger.Filters;
using KissU.Core.Swagger.Swagger.Model;
using KissU.Core.Swagger.SwaggerGen.Application;
using KissU.Core.Swagger.SwaggerUI;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.Swagger
{
    public class SwaggerModule: KestrelHttpModule
    {
        private  IServiceSchemaProvider _serviceSchemaProvider; 
        private  IServiceEntryProvider _serviceEntryProvider;

        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            _serviceSchemaProvider = serviceProvider.GetInstances<IServiceSchemaProvider>();
            _serviceEntryProvider = serviceProvider.GetInstances<IServiceEntryProvider>();
        }

        public override void Initialize(ApplicationInitializationContext context)
        {
            var info = AppConfig.SwaggerConfig.Info == null
          ? AppConfig.SwaggerOptions : AppConfig.SwaggerConfig.Info;
            if (info != null)
            {
                context.Builder.UseSwagger();
                context.Builder.UseSwaggerUI(c =>
                {
                    var areaName = AppConfig.SwaggerConfig.Options?.IngressName;
                    c.SwaggerEndpoint($"../swagger/{info.Version}/swagger.json", info.Title, areaName);
                    c.SwaggerEndpoint(_serviceEntryProvider.GetALLEntries(), areaName);
                });
            }
        }

        public override void RegisterBuilder(ConfigurationContext context)
        {
            var serviceCollection = context.Services;
            var info = AppConfig.SwaggerConfig.Info == null
                     ? AppConfig.SwaggerOptions : AppConfig.SwaggerConfig.Info;
            var swaggerOptions = AppConfig.SwaggerConfig.Options;
            if (info != null)
            {
                serviceCollection.AddSwaggerGen(options =>
                {
                    options.OperationFilter<AddAuthorizationOperationFilter>();
                    options.SwaggerDoc(info.Version, info);
                    if (swaggerOptions != null && swaggerOptions.IgnoreFullyQualified)
                        options.IgnoreFullyQualified();
                    options.GenerateSwaggerDoc(_serviceEntryProvider.GetALLEntries());
                    options.DocInclusionPredicateV2((docName, apiDesc) =>
                    {
                        if (docName == info.Version)
                            return true;
                        var assembly = apiDesc.Type.Assembly;

                        var title = assembly
                            .GetCustomAttributes(true)
                            .OfType<AssemblyTitleAttribute>();

                        return title.Any(v => v.Title == docName);
                    });
                    var xmlPaths = _serviceSchemaProvider.GetSchemaFilesPath();
                    foreach (var xmlPath in xmlPaths)
                        options.IncludeXmlComments(xmlPath);
                });
            }
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
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
