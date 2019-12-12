using System.Linq;
using Autofac;
using KissU.Core.Caching.Configurations;
using KissU.Core.CPlatform.Cache;
using KissU.Core.ServiceHosting.Internal;

namespace KissU.Core.Caching
{
    public static class ServiceHostBuilderExtensions
    {
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
