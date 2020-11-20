using System;
using KissU.Kestrel.Extensions;
using KissU.Kestrel.Stage.Configurations;
using KissU.Kestrel.Stage.Filters;
using KissU.Kestrel.Stage.Internal;
using KissU.Kestrel.Stage.Internal.Implementation;
using KissU.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Kestrel.Stage
{
    /// <summary>
    /// StageModule.
    /// Implements the <see cref="KestrelHttpModule" />
    /// </summary>
    /// <seealso cref="KestrelHttpModule" />
    public class KestrelStageModule : KestrelHttpModule
    {
        private IWebServerListener _listener;

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            _listener = context.ServiceProvoider.GetInstances<IWebServerListener>();
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureWebHost(WebHostContext context)
        {
            _listener.Listen(context);
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Configure(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var policy = AppConfig.Options.AccessPolicy;
            if (policy != null)
            {
                app.UseCors(builder =>
                {
                    if (policy.Origins != null)
                        builder.WithOrigins(policy.Origins);
                    if (policy.AllowAnyHeader)
                        builder.AllowAnyHeader();
                    if (policy.AllowAnyMethod)
                        builder.AllowAnyMethod();
                    if (policy.AllowAnyOrigin)
                        builder.AllowAnyOrigin();
                    if (policy.AllowCredentials)
                        builder.AllowCredentials();
                });
            }
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var apiConfig = AppConfig.Options.ApiGetWay;
            if (apiConfig != null)
            {
                ApiGateWay.AppConfig.CacheMode = apiConfig.CacheMode;
                ApiGateWay.AppConfig.AuthorizationServiceKey = apiConfig.AuthorizationServiceKey;
                ApiGateWay.AppConfig.AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(apiConfig.AccessTokenExpireTimeSpan);
                ApiGateWay.AppConfig.AuthorizationRoutePath = apiConfig.AuthorizationRoutePath;
                ApiGateWay.AppConfig.TokenEndpointPath = apiConfig.TokenEndpointPath;
            }

            context.Services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                if (AppConfig.Options.IsCamelCaseResolver)
                {
                    JsonConvert.DefaultSettings = () =>
                    {
                        var setting = new JsonSerializerSettings();
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                        setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        return setting;
                    };
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                }
                else
                {
                    JsonConvert.DefaultSettings = () =>
                    {
                        var setting = new JsonSerializerSettings();
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                        setting.ContractResolver = new DefaultContractResolver();
                        return setting;
                    };
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                }
            });

            context.Services.AddSingleton<IIPChecker, IPAddressChecker>();
            context.Services.AddFilters(typeof(ActionFilterAttribute));
            context.Services.AddFilters(typeof(IPFilterAttribute));
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            CPlatform.AppConfig.ServerOptions.DisableServiceRegistration = true;
            var section = CPlatform.AppConfig.GetSection("Stage");
            if (section.Exists())
            {
                AppConfig.Options = section.Get<StageOption>();
            }

            builder.RegisterType<WebServerListener>().As<IWebServerListener>().SingleInstance();
        }
    }
}