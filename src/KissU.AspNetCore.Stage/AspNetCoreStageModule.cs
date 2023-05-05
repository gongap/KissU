using System;
using System.Linq;
using KissU.AspNetCore.Configurations;
using KissU.AspNetCore.Extensions;
using KissU.AspNetCore.Internal;
using KissU.AspNetCore.Stage.Filters;
using KissU.AspNetCore.Stage.Internal;
using KissU.AspNetCore.Stage.Internal.Implementation;
using KissU.AspNetCore.Stage.Module;
using KissU.AspNetCore.Stage.Module.Implementation;
using KissU.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.AspNetCore.Stage
{
    /// <summary>
    /// StageModule.
    /// Implements the <see cref="AspNetCoreModule" />
    /// </summary>
    /// <seealso cref="AspNetCoreModule" />
    public class AspNetCoreStageModule : AspNetCoreModule
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
                    {
                       var origins = policy.Origins.Split(",").Where(x=>!string.IsNullOrWhiteSpace(x));
                        builder.WithOrigins(origins.ToArray());
                    }
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

            app.UseAuthentication();
            app.UseAuthorization();
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceCollectionWrapper context)
        {
            var apiConfig = AppConfig.Options?.ApiGetWay;
            if (apiConfig != null)
            {
                ApiGateWay.AppConfig.CacheMode = apiConfig.CacheMode;
                ApiGateWay.AppConfig.CacheKey = apiConfig.CacheKey;
                ApiGateWay.AppConfig.AuthorizationServiceKey = apiConfig.AuthorizationServiceKey;
                ApiGateWay.AppConfig.AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(apiConfig.AccessTokenExpireTimeSpan);
                ApiGateWay.AppConfig.AuthorizationRoutePath = apiConfig.AuthorizationRoutePath;
                ApiGateWay.AppConfig.RevocationRoutePath = apiConfig.RevocationRoutePath;
                ApiGateWay.AppConfig.TokenEndpointPath = apiConfig.TokenEndpointPath;
                ApiGateWay.AppConfig.RevocationEndpointPath = apiConfig.RevocationEndpointPath;
            }
            
            context.Services.AddSingleton<IIPChecker, IPAddressChecker>();
            context.Services.AddFilters(typeof(ActionFilterAttribute));
            context.Services.AddFilters(typeof(AuthorizationFilterAttribute));
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
            builder.RegisterType<RegisterService>().As<IRegisterService>().SingleInstance();
            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
        }
    }
}
