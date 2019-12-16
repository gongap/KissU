using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Cache.Implementation;

namespace KissU.Core.CPlatform.Cache
{
    /// <summary>
    /// 服务缓存管理
    /// </summary>
    public interface IServiceCacheManager
    {
        event EventHandler<ServiceCacheEventArgs> Created;

        event EventHandler<ServiceCacheEventArgs> Removed;

        event EventHandler<ServiceCacheChangedEventArgs> Changed;

        Task<IEnumerable<ServiceCache>> GetCachesAsync();

        Task SetCachesAsync(IEnumerable<ServiceCache> caches);

        Task SetCachesAsync(IEnumerable<ServiceCacheDescriptor> cacheDescriptors);

        Task RemveAddressAsync(IEnumerable<CacheEndpoint> endpoints);

        Task ClearAsync();
    }

    /// <summary>
    /// 服务命令管理者扩展方法。
    /// </summary>
    public static class ServiceRouteManagerExtensions
    {
        public static async Task<ServiceCache> GetAsync(this IServiceCacheManager serviceCacheManager, string cacheId)
        {
            return (await serviceCacheManager.GetCachesAsync()).SingleOrDefault(i => i.CacheDescriptor.Id == cacheId);
        }

        public static async Task<IEnumerable<CacheDescriptor>> GetCacheDescriptorAsync(this IServiceCacheManager serviceCacheManager)
        {
            var caches = await serviceCacheManager.GetCachesAsync();
            return caches.Select(p => p.CacheDescriptor);
        }

        public static async Task<IEnumerable<CacheEndpoint>> GetCacheEndpointAsync(this IServiceCacheManager serviceCacheManager, string cacheId)
        {
            var caches = await serviceCacheManager.GetCachesAsync();
            return caches.Where(p => p.CacheDescriptor.Id == cacheId).Select(p => p.CacheEndpoint).FirstOrDefault();
        }


        public static async Task<CacheEndpoint> GetCacheEndpointAsync(this IServiceCacheManager serviceCacheManager, string cacheId,string endpoint)
        {
            var caches = await serviceCacheManager.GetCachesAsync();
            var cache= caches.Where(p => p.CacheDescriptor.Id == cacheId).Select(p => p.CacheEndpoint).FirstOrDefault();
            return cache.Where(p => p.ToString() == endpoint).FirstOrDefault();
        }
    }
}

