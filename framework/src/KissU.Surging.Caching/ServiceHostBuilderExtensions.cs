using System.Linq;
using Autofac;
using KissU.Extensions;
using KissU.Surging.Caching.Configurations;
using KissU.Surging.CPlatform.Cache;
using Microsoft.Extensions.Hosting;

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
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseServiceCache(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseServiceHostBuilder(mapper =>
            {
                var serviceCacheProvider = mapper.Resolve<ICacheNodeProvider>();
                var addressDescriptors = serviceCacheProvider.GetServiceCaches().ToList();
                mapper.Resolve<IServiceCacheManager>().SetCachesAsync(addressDescriptors);
                mapper.Resolve<IConfigurationWatchProvider>();
            });
        }
    }
}