using Autofac;
using KissU.Extensions;
using Microsoft.Extensions.Hosting;

namespace KissU.EventBus.Kafka
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
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder SubscribeAt(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureMicroServiceHost(mapper => { mapper.Resolve<ISubscriptionAdapt>().SubscribeAt(); });
        }
    }
}