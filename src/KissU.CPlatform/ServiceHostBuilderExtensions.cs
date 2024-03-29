using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using KissU.Address;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modularity;
using KissU.CPlatform.Configurations;
using KissU.CPlatform.Engines;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Client;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Support;
using KissUtil.Helpers;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace KissU.CPlatform
{
    /// <summary>
    /// 服务构建器扩展.
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Uses the server.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <param name="token">The token.</param>
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseServer(this IHostBuilder hostBuilder, string ip, int port, string token = "True")
        {
            return hostBuilder.ConfigureContainer(async mapper =>
            {
                var _token = AppConfig.ServerOptions.Token ?? token;
                mapper.Resolve<IServiceTokenGenerator>().GeneratorToken(_token);
                var _port = AppConfig.ServerOptions.Port = AppConfig.ServerOptions.Port == 0 ? port : AppConfig.ServerOptions.Port;
                var _ip = AppConfig.ServerOptions.Ip ??= ip;
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
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseServer(this IHostBuilder hostBuilder,
            Action<ServerEngineOptions> options = null)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var serverOptions = new ServerEngineOptions();
            options?.Invoke(serverOptions);
            AppConfig.ServerOptions = serverOptions;
            if (AppConfig.ServerOptions.ShowWelcomeMessage)
            {
                Console.WriteLine($@"                                         
    //   / /                         //   / / 
   //__ / /   ( )  ___      ___     //   / /  
  //__  /    / / ((   ) ) ((   ) ) //   / /   
 //   \ \   / /   \ \      \ \    //   / /    
//     \ \ / / //   ) ) //   ) ) ((___/ /     Version :  {versionInfo.FileVersion}
------------------------------------------------------------------------------------");
            }

            return hostBuilder.UseServer(serverOptions.Ip, serverOptions.Port, serverOptions.Token);
        }

        /// <summary>
        /// Uses the client.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseClient(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureContainer(mapper =>
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
        /// 配置路由.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public static async Task ConfigureRoute(ILifetimeScope mapper)
        {
            if (AppConfig.ServerOptions.Protocols.Contains(nameof(CommunicationProtocol.Rpc)) || AppConfig.ServerOptions.Protocols == nameof(CommunicationProtocol.None))
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
