﻿using Autofac;

using KissU.Dependency;
using KissU.EventBus;
using KissU.EventBus.Implementation;
using KissU.ServiceHosting;
using KissU.Surging.CPlatform.Engines;
using KissU.Surging.CPlatform.Routing;

namespace KissU.Surging.EventBusRabbitMQ
{
    /// <summary>
    /// ServiceHostBuilderExtensions.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// Subscribes at.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder SubscribeAt(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.Configure(mapper =>
            {
                mapper.Resolve<IServiceEngineLifetime>().ServiceEngineStarted.Register(() =>
                {
                    mapper.Resolve<ISubscriptionAdapt>().SubscribeAt();
                    new ServiceRouteWatch(mapper.Resolve<CPlatformContainer>(), () =>
                    {
                        var subscriptionAdapt = mapper.Resolve<ISubscriptionAdapt>();
                        mapper.Resolve<IEventBus>().OnShutdown += (sender, args) =>
                        {
                            subscriptionAdapt.Unsubscribe();
                        };
                        mapper.Resolve<ISubscriptionAdapt>().SubscribeAt();
                    });
                });
            });
        }
    }
}