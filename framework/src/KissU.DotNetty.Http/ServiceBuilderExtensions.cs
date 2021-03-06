﻿using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation;
using KissU.CPlatform.Transport.Codec;
using KissU.Modularity;
using KissU.Serialization;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Http
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ServiceBuilderExtensions
    {
        /// <summary>
        /// 添加http协议
        /// </summary>
        /// <param name="builder">服务构建者。</param>
        /// <returns>服务构建者。</returns>
        public static IServiceBuilder AddHttpProtocol(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType(typeof(HttpServiceExecutor)).As(typeof(IServiceExecutor))
                .Named<IServiceExecutor>(CommunicationProtocol.Http.ToString()).SingleInstance();
            if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.Http)
            {
                RegisterDefaultProtocol(containerBuilder);
            }
            else if (AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterHttpProtocol(containerBuilder);
            }

            return builder;
        }

        private static void RegisterDefaultProtocol(ContainerBuilder builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyHttpServerMessageListener(
                    provider.Resolve<ILogger<DotNettyHttpServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>(),
                    provider.Resolve<ISerializer<string>>(),
                    provider.Resolve<IServiceRouteProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Http.ToString());
                var messageListener = provider.Resolve<DotNettyHttpServerMessageListener>();
                return new DefaultServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }

        private static void RegisterHttpProtocol(ContainerBuilder builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyHttpServerMessageListener(
                    provider.Resolve<ILogger<DotNettyHttpServerMessageListener>>(),
                    provider.Resolve<ITransportMessageCodecFactory>(),
                    provider.Resolve<ISerializer<string>>(),
                    provider.Resolve<IServiceRouteProvider>()
                );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Http.ToString());
                var messageListener = provider.Resolve<DotNettyHttpServerMessageListener>();
                return new HttpServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);
            }).As<IServiceHost>();
        }
    }
}