using System;
using KissU.Core.CPlatform.Module;
using KissU.Core.KestrelHttpServer;
using KissU.Core.KestrelHttpServer.Extensions;
using KissU.Core.Stage.Configurations;
using KissU.Core.Stage.Filters;
using KissU.Core.Stage.Internal;
using KissU.Core.Stage.Internal.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KissU.Core.Stage
{
    public class StageModule : KestrelHttpModule
    {
        private IWebServerListener _listener;
        public override void Initialize(AppModuleContext context)
        {
            _listener = context.ServiceProvoider.GetInstances<IWebServerListener>();
        }

        public override void RegisterBuilder(WebHostContext context)
        {  
            _listener.Listen(context);
        }

        public override void Initialize(ApplicationInitializationContext context)
        {
            var policy = AppConfig.Options.AccessPolicy;
            if (policy != null)
            {
                context.Builder.UseCors(builder =>
                {
                    if(policy.Origins!=null)
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

        public override void RegisterBuilder(ConfigurationContext context)
        {
            var apiConfig = AppConfig.Options.ApiGetWay;
            if (apiConfig != null)
            {
                ApiGateWay.AppConfig.CacheMode = apiConfig.CacheMode;
                ApiGateWay.AppConfig.AuthorizationServiceKey = apiConfig.AuthorizationServiceKey;
                ApiGateWay.AppConfig.AccessTokenExpireTimeSpan =TimeSpan.FromMinutes(apiConfig.AccessTokenExpireTimeSpan);
                ApiGateWay.AppConfig.AuthorizationRoutePath = apiConfig.AuthorizationRoutePath;
                ApiGateWay.AppConfig.TokenEndpointPath = apiConfig.TokenEndpointPath;
            }
            context.Services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                if (AppConfig.Options.IsCamelCaseResolver)
                {
                    JsonConvert.DefaultSettings= new Func<JsonSerializerSettings>(() =>
                    {
                       JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                        setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        return setting;
                    });
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                }
                else
                {
                    JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                    {
                        JsonSerializerSettings setting = new JsonSerializerSettings();
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                        setting.ContractResolver= new DefaultContractResolver();
                        return setting;
                    });
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                }
            });
            context.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            context.Services.AddSingleton<IIPChecker,IPAddressChecker>();
            context.Services.AddFilters(typeof(JWTBearerAuthorizationFilterAttribute));
            context.Services.AddFilters(typeof(ActionFilterAttribute));
            context.Services.AddFilters(typeof(IPFilterAttribute));
        }

        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
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
