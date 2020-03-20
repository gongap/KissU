using Autofac;
using KissU.Core.EventBus;
using KissU.Surging.ServiceHosting.Internal;

namespace KissU.Surging.EventBusKafka
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
            return hostBuilder.MapServices(mapper => { mapper.Resolve<ISubscriptionAdapt>().SubscribeAt(); });
        }
    }
}