using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Configurations;
using KissU.Core.CPlatform.Engines;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Runtime.Client;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Support;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.ServiceHosting.Internal;
using Microsoft.Extensions.Configuration;
using IServiceHost = KissU.Core.CPlatform.Runtime.Server.IServiceHost;

namespace KissU.Core.CPlatform
{
    /// <summary>
    /// 服务构建器扩展.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// Uses the server.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <param name="token">The token.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseServer(this IServiceHostBuilder hostBuilder, string ip, int port,
            string token = "True")
        {
            return hostBuilder.MapServices(async mapper =>
            {
                BuildServiceEngine(mapper);
                mapper.Resolve<IServiceTokenGenerator>().GeneratorToken(token);
                var _port = AppConfig.ServerOptions.Port =
                    AppConfig.ServerOptions.Port == 0 ? port : AppConfig.ServerOptions.Port;
                var _ip = AppConfig.ServerOptions.Ip = AppConfig.ServerOptions.Ip ?? ip;
                _port = AppConfig.ServerOptions.Port = AppConfig.ServerOptions.IpEndpoint?.Port ?? _port;
                _ip = AppConfig.ServerOptions.Ip = AppConfig.ServerOptions.IpEndpoint?.Address.ToString() ?? _ip;
                _ip = NetUtils.GetHostAddress(_ip);
                mapper.Resolve<IModuleProvider>().Initialize();
                if (!AppConfig.ServerOptions.DisableServiceRegistration)
                {
                    await mapper.Resolve<IServiceCommandManager>().SetServiceCommandsAsync();
                    await ConfigureRoute(mapper).ConfigureAwait(false);
                }

                var serviceHosts = mapper.Resolve<IList<IServiceHost>>();
                await Task.Factory.StartNew(async () =>
                {
                    foreach (var serviceHost in serviceHosts)
                    {
                        await serviceHost.StartAsync(_ip, _port).ConfigureAwait(false);
                    }

                    mapper.Resolve<IServiceEngineLifetime>().NotifyStarted();
                }).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Uses the server.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="options">The options.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseServer(this IServiceHostBuilder hostBuilder,
            Action<ServerEngineOptions> options)
        {
            var serverOptions = new ServerEngineOptions();
            options.Invoke(serverOptions);
            AppConfig.ServerOptions = serverOptions;
            return hostBuilder.UseServer(serverOptions.Ip, serverOptions.Port, serverOptions.Token);
        }

        /// <summary>
        /// Uses the client.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseClient(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.MapServices(mapper =>
            {
                var serviceEntryManager = mapper.Resolve<IServiceEntryManager>();
                var addressDescriptors = serviceEntryManager.GetEntries().Select(i =>
                {
                    i.Descriptor.Metadatas = null;
                    return new ServiceSubscriber
                    {
                        Address = new[]
                        {
                            new IpAddressModel
                            {
                                Ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList
                                    .FirstOrDefault(a => a.AddressFamily.ToString().Equals("InterNetwork"))?.ToString()
                            }
                        },
                        ServiceDescriptor = i.Descriptor
                    };
                }).ToList();
                mapper.Resolve<IServiceSubscribeManager>().SetSubscribersAsync(addressDescriptors);
                mapper.Resolve<IModuleProvider>().Initialize();
            });
        }

        /// <summary>
        /// 构建服务引擎.
        /// </summary>
        /// <param name="container">The container.</param>
        [Obsolete]
        public static void BuildServiceEngine(IContainer container)
        {
            if (container.IsRegistered<IServiceEngine>())
            {
                var builder = new ContainerBuilder();
                container.Resolve<IServiceEngineBuilder>().Build(builder);
                var configBuilder = container.Resolve<IConfigurationBuilder>();
                var appSettingPath = Path.Combine(AppConfig.ServerOptions.RootPath, "appsettings.json");
                configBuilder.AddCPlatformFile("${appsettingspath}|" + appSettingPath, false, true);
                builder.Update(container);
            }
        }

        /// <summary>
        /// 配置路由.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public static async Task ConfigureRoute(IContainer mapper)
        {
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.Tcp ||
                AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                var routeProvider = mapper.Resolve<IServiceRouteProvider>();
                if (AppConfig.ServerOptions.EnableRouteWatch)
                {
                    new ServiceRouteWatch(mapper.Resolve<CPlatformContainer>(),
                        async () => await routeProvider.RegisterRoutes(Math.Round(
                            Convert.ToDecimal(Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds), 2,
                            MidpointRounding.AwayFromZero)));
                }
                else
                {
                    await routeProvider.RegisterRoutes(0);
                }
            }
        }
    }
}