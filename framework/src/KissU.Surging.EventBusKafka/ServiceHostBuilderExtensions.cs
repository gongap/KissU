using Autofac;
using KissU.EventBus;
using KissU.ServiceHosting;

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
            return hostBuilder.Configure(mapper => { mapper.Resolve<ISubscriptionAdapt>().SubscribeAt(); });
        }
    }
}