using System.Collections.Generic;
using System.Linq;
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
        private IServiceEntryManager _serviceEntryProvider;
        private IServiceSchemaProvider _serviceSchemaProvider;

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            _serviceSchemaProvider = serviceProvider.GetInstances<IServiceSchemaProvider>();
            _serviceEntryProvider = serviceProvider.GetInstances<IServiceEntryManager>();
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Configure(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
             var config = AppConfig.SwaggerConfig.Info ?? AppConfig.SwaggerOptions;
             var swaggerOptions = AppConfig.SwaggerConfig.Options;
            if (config != null)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    var areaName = swaggerOptions?.IngressName;
                    c.SwaggerEndpoint($"../swagger/{config.Version}/swagger.json", config.Title, areaName);
                    var tagServices = swaggerOptions?.TagService?.Split(",");
                    foreach (var tagService in tagServices!)
                    {
                        c.SwaggerEndpoint($"../swagger/KissU.{tagService}/swagger.json", $"KissU.{tagService}", areaName);
                    }
                    c.SwaggerEndpoint(GetServiceEntries(), areaName);
                });
            }
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceCollectionWrapper context)
        {
            var config = AppConfig.SwaggerConfig?.Info ?? AppConfig.SwaggerOptions;
            var swaggerOptions = AppConfig.SwaggerConfig?.Options;
            if (config != null)
            {
                context.Services.AddSwaggerGen(options =>
                {
                    options.OperationFilter<AddAuthorizationOperationFilter>();
                    options.SwaggerDoc(config.Version, config);
                    if (swaggerOptions.IgnoreFullyQualified)
                    {
                        options.IgnoreFullyQualified();
                    }

                    options.GenerateSwaggerDoc( GetServiceEntries());
                    
                    var tagServices = swaggerOptions.TagService?.Split(",");
                    if (tagServices != null)
                    {
                        foreach (var tagService in tagServices)
                        {
                            options.SwaggerDoc($"KissU.{tagService}", new Info {Title = $"KissU.{tagService}"});
                        }
                    }

                    options.DocInclusionPredicateV2((docName, apiDesc) =>
                    {
                        if (docName == config.Version)
                        {
                            return true;
                        }

                        if (tagServices != null)
                        {
                            if (tagServices.Any(tag => docName == $"KissU.{tag}" && apiDesc.Type.Name.EndsWith(tag)))
                            {
                                return true;
                            }

                            if (tagServices.Any(tag=>apiDesc.Type.Name.EndsWith(tag)))
                            {
                                return false;
                            }
                        }

                        return apiDesc.Type.Assembly.GetCustomAttributes(true).OfType<AssemblyTitleAttribute>().Any(v => v.Title == docName);
                    });

                    var xmlPaths = _serviceSchemaProvider.GetSchemaFilesPath();
                    foreach (var xmlPath in xmlPaths)
                    {
                        options.IncludeXmlComments(xmlPath, swaggerOptions.IncludeControllerXmlComments);
                    }
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

        private IEnumerable<ServiceEntry> GetServiceEntries()
        {
            var packages = CPlatform.AppConfig.ServerOptions.Packages.FirstOrDefault(x=>x.TypeName=="AspNetCoreModule");
            if((packages?.Using?.Contains("AspNetCoreStageModule")).GetValueOrDefault())
            {
                return _serviceEntryProvider.GetAllEntries();
            }

            return  _serviceEntryProvider.GetEntries();
        }
    }
}
