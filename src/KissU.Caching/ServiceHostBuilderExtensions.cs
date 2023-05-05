using System.Linq;
using Autofac;
using KissU.Extensions;
using KissU.Caching.Configurations;
using KissU.CPlatform.Cache;
using Microsoft.Extensions.Hosting;

namespace KissU.Caching
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
            return hostBuilder.ConfigureContainer(mapper =>
            {
                var serviceCacheProvider = mapper.Resolve<ICacheNodeProvider>();
                var addressDescriptors = serviceCacheProvider.GetServiceCaches().ToList();
                mapper.Resolve<IServiceCacheManager>().SetCachesAsync(addressDescriptors);
                mapper.Resolve<IConfigurationWatchProvider>();
            });
        }
    }
}