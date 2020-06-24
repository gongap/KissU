using System;
using KissU.Modularity;
using KissU.Surging.KestrelHttpServer;
using KissU.Surging.KestrelHttpServer.Extensions;
using KissU.Surging.Stage.Configurations;
using KissU.Surging.Stage.Filters;
using KissU.Surging.Stage.Internal;
using KissU.Surging.Stage.Internal.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KissU.Surging.Stage
{
    /// <summary>
    /// StageModule.
    /// Implements the <see cref="KestrelHttpModule" />
    /// </summary>
    /// <seealso cref="KestrelHttpModule" />
    public class StageModule : KestrelHttpModule
    {
        private IWebServerListener _listener;

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
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
            var policy = AppConfig.Options.AccessPolicy;
            if (policy != null)
            {
                context.Builder.UseCors(builder =>
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
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            var apiConfig = AppConfig.Options.ApiGetWay;
            if (apiConfig != null)
            {
                ApiGateWay.AppConfig.CacheMode = apiConfig.CacheMode;
                ApiGateWay.AppConfig.AuthorizationServiceKey = apiConfig.AuthorizationServiceKey;
                ApiGateWay.AppConfig.AccessTokenExpireTimeSpan =
                    TimeSpan.FromMinutes(apiConfig.AccessTokenExpireTimeSpan);
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
            context.Services.AddFilters(typeof(JWTBearerAuthorizationFilterAttribute));
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