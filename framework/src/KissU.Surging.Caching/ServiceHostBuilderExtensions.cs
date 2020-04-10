using System.Linq;
using Autofac;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform.Cache;
using KissU.Surging.ServiceHosting.Internal;

namespace KissU.Surging.Caching
{
    /// <summary>
    /// ServiceHostBuilderExtensions.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// Uses the service cache.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseServiceCache(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.MapServices(mapper =>
            {
                var serviceCacheProvider = mapper.Resolve<ICacheNodeProvider>();
                var addressDescriptors = serviceCacheProvider.GetServiceCaches().ToList();
                mapper.Resolve<IServiceCacheManager>().SetCachesAsync(addressDescriptors);
                mapper.Resolve<IConfigurationWatchProvider>();
            });
        }
    }
}