using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using KissU.AspNetCore.Extensions;
using KissU.AspNetCore.Filters;
using KissU.AspNetCore.Internal;
using KissU.AspNetCore.Kestrel.Filters.Implementation;
using KissU.CPlatform.Configurations;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Engines;
using KissU.CPlatform.Routing;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modularity;
using KissU.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KissU.AspNetCore.Kestrel
{
    /// <summary>
    /// KestrelHttpMessageListener.
    /// Implements the <see cref="HttpMessageListener" />
    /// Implements the <see cref="IDisposable" />
    /// </summary>
    /// <seealso cref="HttpMessageListener" />
    /// <seealso cref="IDisposable" />
    public class KestrelHttpMessageListener : HttpMessageListener, IDisposable
    {
        private readonly CPlatformContainer _container;
        private readonly IServiceEngineLifetime _lifetime;
        private readonly ILogger<KestrelHttpMessageListener> _logger;
        private readonly IModuleProvider _moduleProvider;
        private readonly ISerializer<string> _serializer;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly DiagnosticListener _diagnosticListener;
        private IHost _host;
        private readonly bool _isCompleted;

        /// <summary>
        /// Initializes a new instance of the <see cref="KestrelHttpMessageListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="lifetime">The lifetime.</param>
        /// <param name="moduleProvider">The module provider.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="container">The container.</param>
        public KestrelHttpMessageListener(ILogger<KestrelHttpMessageListener> logger,
            ISerializer<string> serializer,
            IServiceEngineLifetime lifetime,
            IModuleProvider moduleProvider,
            IServiceRouteProvider serviceRouteProvider,
            CPlatformContainer container) : base(logger, serializer, serviceRouteProvider)
        {
            _logger = logger;
            _serializer = serializer;
            _lifetime = lifetime;
            _moduleProvider = moduleProvider;
            _container = container;
            _serviceRouteProvider = serviceRouteProvider;
            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rest));
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _host.Dispose();
        }

        /// <summary>
        /// start as an asynchronous operation.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="port">The port.</param>
        public Task StartAsync(IPAddress address, int? port)
        {
            try
            {
                if (CPlatform.AppConfig.ServerOptions.DockerDeployMode == DockerDeployMode.Swarm)
                {
                    address = IPAddress.Any;
                }

                var hostBuilder = Host.CreateDefaultBuilder()
                    .ConfigureLogging(configure => configure.ClearProviders())
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseKestrel((context, options) =>
                            {
                                options.Limits.MinRequestBodyDataRate = null;
                                options.Limits.MinResponseDataRate = null;
                                options.Limits.MaxRequestBodySize = null;
                                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
                                if (port != null && port > 0)
                                {
                                    options.Listen(address, port.Value, listenOptions =>
                                    {
                                        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                                    });
                                }

                                ConfigureHost(context, options, address);
                            })
                            .ConfigureServices(ConfigureServices)
                            .Configure(AppResolve);

                        if (Directory.Exists(CPlatform.AppConfig.ServerOptions.WebRootPath))
                        {
                            webBuilder.UseWebRoot(CPlatform.AppConfig.ServerOptions.WebRootPath);
                        }
                    });

                _host = hostBuilder.Build();
                _lifetime.ServiceEngineStarted.Register(async () =>
                {
                    await _host.RunAsync();
                });
            }
            catch
            {
                _logger.LogError($"Kestrel服务主机启动失败, 监听端口: {address}:{port}。 ");
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Configures the host.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="options">The options.</param>
        /// <param name="ipAddress">The ip address.</param>
        public void ConfigureHost(WebHostBuilderContext context, KestrelServerOptions options, IPAddress ipAddress)
        {
            _moduleProvider.ConfigureHost(new WebHostContext(context, options, ipAddress));
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureLocalizationServices(services);
            services.AddSingleton(ServiceLocator.GetService<ILoggerFactory>());
            services.AddMvc().AddJsonOptions(options =>
            {
                if (CPlatform.AppConfig.ServerOptions.IsCamelCaseResolver)
                {
                    JsonConvert.DefaultSettings = () =>
                    {
                        var setting = new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        };
                        return setting;
                    };
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                }
                else
                {
                    JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                    {
                        var setting = new JsonSerializerSettings();
                        setting.ContractResolver= new DefaultContractResolver();
                        return setting;
                    });
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                }
            });
            services.AddObjectAccessor<IApplicationBuilder>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddFilters(typeof(HttpRequestFilterAttribute));
            services.AddFilters(typeof(CustomerExceptionFilterAttribute));
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            _moduleProvider.ConfigureServices(new ServiceCollectionWrapper(services));
            if (AppConfig.Options != null && AppConfig.Options.AddIdentityServerAuthentication)
            {
              services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication("Bearer", options =>
                    {
                        options.Authority = AppConfig.Options.AuthServer.Authority;
                        options.ApiName = AppConfig.Options.AuthServer.ApiName;
                        options.ApiSecret = AppConfig.Options.AuthServer.ApiSecret;
                        options.RequireHttpsMetadata = AppConfig.Options.AuthServer.RequireHttpsMetadata;
                        options.EnableCaching = AppConfig.Options.AuthServer.EnableCaching;
                        options.CacheDuration = TimeSpan.FromMinutes(AppConfig.Options.AuthServer.CacheDuration);
                    });
            }
        }

        private void AppResolve(IApplicationBuilder app)
        {
            ServiceLocator.Register(app.ApplicationServices);
            RestContext.GetContext().Initialize(app.ApplicationServices);
            app.ApplicationServices.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Value = app;
            app.UseRequestLocalization();
            app.UseStaticFiles(options:new StaticFileOptions());
            app.UseRouting();
            _moduleProvider.Configure(new ApplicationInitializationContext(app.ApplicationServices));
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
            app.Run(async context =>
            {
                if (context.Request.Path == "/" || context.Request.Path == "/favicon.ico")
                {
                    return;
                }

                var messageId = Guid.NewGuid().ToString("N");
                var sender = new HttpServerMessageSender(_serializer, context, _diagnosticListener);
                try
                {
                    var filters = app.ApplicationServices.GetServices<IAuthorizationFilter>();
                    var isSuccess = await OnAuthorization(context, sender, messageId, filters);
                    if (isSuccess)
                    {
                        var actionFilters = app.ApplicationServices.GetServices<IActionFilter>();
                        await OnReceived(sender, messageId, context, actionFilters);
                    }
                }
                catch (Exception ex)
                {
                    var filters = app.ApplicationServices.GetServices<IExceptionFilter>();
                    WirteDiagnosticError(messageId, ex);
                    await OnException(context, sender, messageId, ex, filters);
                }
            });
        }

        private static void ConfigureLocalizationServices(IServiceCollection services)
        {
            var cultures = new List<CultureInfo> { new("en") , new("zh"), new("zh-Hant") , new("zh-Hans") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("zh-Hans");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        private void WirteDiagnosticError(string messageId, Exception ex)
        {
            _diagnosticListener.WriteTransportError(CPlatform.Diagnostics.TransportType.Rest, new TransportErrorEventData(new DiagnosticMessage
            {
                Id = messageId
            }, ex));
        }
    }
}
