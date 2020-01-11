using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Configurations;
using KissU.Core.CPlatform.Diagnostics;
using KissU.Core.CPlatform.Engines;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Serialization;
using KissU.Core.KestrelHttpServer.Extensions;
using KissU.Core.KestrelHttpServer.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Core.KestrelHttpServer
{
    public class KestrelHttpMessageListener : HttpMessageListener, IDisposable
    {
        private readonly ILogger<KestrelHttpMessageListener> _logger;
        private IWebHost _host;
        private bool _isCompleted;
        private readonly ISerializer<string> _serializer;
        private readonly IServiceEngineLifetime _lifetime;
        private readonly IModuleProvider _moduleProvider;
        private readonly CPlatformContainer _container;
        private readonly IServiceRouteProvider _serviceRouteProvider;

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
        }

        public async Task StartAsync(IPAddress address,int? port)
        { 
            try
            {
                if (AppConfig.ServerOptions.DockerDeployMode == DockerDeployMode.Swarm)
                {
                    address = IPAddress.Any;
                }

                var hostBuilder = new WebHostBuilder()
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseKestrel((context,options) =>
                  {
                      options.Limits.MinRequestBodyDataRate = null;
                      options.Limits.MinResponseDataRate = null;
                      options.Limits.MaxRequestBodySize = null;
                      options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
                      if (port != null && port > 0)
                          options.Listen(address, port.Value, listenOptions =>
                          {
                              listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                          });
                      ConfigureHost(context, options, address);

                  })
                  .ConfigureServices(ConfigureServices)
                  .ConfigureLogging((logger) =>
                  {
                      logger.AddConfiguration(
                             CPlatform.AppConfig.GetSection("Logging"));
                  })
                  .Configure(AppResolve);

                if (Directory.Exists(CPlatform.AppConfig.ServerOptions.WebRootPath))
                    hostBuilder = hostBuilder.UseWebRoot(CPlatform.AppConfig.ServerOptions.WebRootPath);
                _host = hostBuilder.Build();
                _lifetime.ServiceEngineStarted.Register(async () =>
                {
                    await _host.RunAsync();
                });

            }
            catch
            {
                _logger.LogError($"http服务主机启动失败，监听地址：{address}:{port}。 ");
            }

        }

        public void ConfigureHost(WebHostBuilderContext context, KestrelServerOptions options,IPAddress ipAddress)
        {
            _moduleProvider.ConfigureHost(new WebHostContext(context, options, ipAddress));
        }

        public void ConfigureServices(IServiceCollection services)
        { 
            var builder = new ContainerBuilder();
            services.AddMvc();
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
            app.UseMvc();
            _moduleProvider.Initialize(new ApplicationInitializationContext(app, _moduleProvider.Modules,
                _moduleProvider.VirtualPaths,
                AppConfig.Configuration));
            app.Run(async (context) =>
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

        private void WirteDiagnosticError(string messageId,Exception ex)
        {
            var diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
            diagnosticListener.WriteTransportError(CPlatform.Diagnostics.TransportType.Rest, new TransportErrorEventData(new DiagnosticMessage
            {
                Id = messageId
            }, ex));
        }

        public void Dispose()
        {
            _host.Dispose();
        }

    }
}
