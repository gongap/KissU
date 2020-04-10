using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KissU.Core;
using KissU.Core.Module;
using KissU.Core.Serialization;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Configurations;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Engines;
using KissU.Surging.CPlatform.Routing;
using KissU.Surging.KestrelHttpServer.Extensions;
using KissU.Surging.KestrelHttpServer.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.KestrelHttpServer
{
    /// <summary>
    /// KestrelHttpMessageListener.
    /// Implements the <see cref="KissU.Surging.KestrelHttpServer.HttpMessageListener" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.Surging.KestrelHttpServer.HttpMessageListener" />
    /// <seealso cref="System.IDisposable" />
    public class KestrelHttpMessageListener : HttpMessageListener, IDisposable
    {
        private readonly CPlatformContainer _container;
        private readonly IServiceEngineLifetime _lifetime;
        private readonly ILogger<KestrelHttpMessageListener> _logger;
        private readonly IModuleProvider _moduleProvider;
        private readonly ISerializer<string> _serializer;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly DiagnosticListener _diagnosticListener;
        private IWebHost _host;
        private bool _isCompleted;

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
            _diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
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
        public async Task StartAsync(IPAddress address, int? port)
        {
            try
            {
                if (AppConfig.ServerOptions.DockerDeployMode == DockerDeployMode.Swarm)
                {
                    address = IPAddress.Any;
                }

                var hostBuilder = new WebHostBuilder()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseKestrel((context, options) =>
                    {
                        options.Limits.MinRequestBodyDataRate = null;
                        options.Limits.MinResponseDataRate = null;
                        options.Limits.MaxRequestBodySize = null;
                        options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
                        if (port != null && port > 0)
                            options.Listen(address, port.Value,
                                listenOptions => { listenOptions.Protocols = HttpProtocols.Http1AndHttp2; });
                        ConfigureHost(context, options, address);
                    })
                    .ConfigureServices(ConfigureServices)
                    .ConfigureLogging(logger =>
                    {
                        logger.AddConfiguration(
                            AppConfig.GetSection("Logging"));
                    })
                    .Configure(AppResolve);

                if (Directory.Exists(AppConfig.ServerOptions.WebRootPath))
                    hostBuilder = hostBuilder.UseWebRoot(AppConfig.ServerOptions.WebRootPath);
                _host = hostBuilder.Build();
                _lifetime.ServiceEngineStarted.Register(async () => { await _host.RunAsync(); });
            }
            catch
            {
                _logger.LogError($"http服务主机启动失败，监听地址：{address}:{port}。 ");
            }
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
            var builder = new ContainerBuilder();
            services.AddMvc()
                .AddNewtonsoftJson();
            _moduleProvider.ConfigureServices(new ConfigurationContext(services,
                _moduleProvider.Modules,
                _moduleProvider.VirtualPaths,
                AppConfig.Configuration));
            builder.Populate(services);
            builder.Update(_container.Current.ComponentRegistry);
        }

        private void AppResolve(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
            _moduleProvider.Initialize(new ApplicationInitializationContext(app, _moduleProvider.Modules,
                _moduleProvider.VirtualPaths,
                AppConfig.Configuration));
            app.Run(async context =>
            {
                var messageId = Guid.NewGuid().ToString("N");
                var sender = new HttpServerMessageSender(_serializer, context);
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

        private void WirteDiagnosticError(string messageId, Exception ex)
        {
            _diagnosticListener.WriteTransportError(CPlatform.Diagnostics.TransportType.Rest, new TransportErrorEventData(new DiagnosticMessage
            {
                Id = messageId
            }, ex));
        }
    }
}