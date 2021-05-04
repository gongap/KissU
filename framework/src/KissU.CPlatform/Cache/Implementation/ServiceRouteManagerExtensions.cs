using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissU.CPlatform.Cache.Implementation
{
    /// <summary>
    /// 服务命令管理者扩展方法。
    /// </summary>
    public static class ServiceRouteManagerExtensions
    {
        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="serviceCacheManager">The service cache manager.</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>Task&lt;ServiceCache&gt;.</returns>
        public static async Task<ServiceCache> GetAsync(this IServiceCacheManager serviceCacheManager, string cacheId)
        {
            return (await serviceCacheManager.GetCachesAsync()).SingleOrDefault(i => i.CacheDescriptor.Id == cacheId);
        }

        /// <summary>
        /// get cache descriptor as an asynchronous operation.
        /// </summary>
        /// <param name="serviceCacheManager">The service cache manager.</param>
        /// <returns>Task&lt;IEnumerable&lt;CacheDescriptor&gt;&gt;.</returns>
        public static async Task<IEnumerable<CacheDescriptor>> GetCacheDescriptorAsync(
            this IServiceCacheManager serviceCacheManager)
        {
            var caches = await serviceCacheManager.GetCachesAsync();
            return caches.Select(p => p.CacheDescriptor);
        }

        /// <summary>
        /// get cache endpoint as an asynchronous operation.
        /// </summary>
        /// <param name="serviceCacheManager">The service cache manager.</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;CacheEndpoint&gt;&gt;.</returns>
        public static async Task<IEnumerable<CacheEndpoint>> GetCacheEndpointAsync(
            this IServiceCacheManager serviceCacheManager, string cacheId)
        {
            var caches = await serviceCacheManager.GetCachesAsync();
            return caches.Where(p => p.CacheDescriptor.Id == cacheId).Select(p => p.CacheEndpoint).FirstOrDefault(x=> x.Any(y=>y.Health));
        }

        /// <summary>
        /// get cache endpoint as an asynchronous operation.
        /// </summary>
        /// <param name="serviceCacheManager">The service cache manager.</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task&lt;CacheEndpoint&gt;.</returns>
        public static async Task<CacheEndpoint> GetCacheEndpointAsync(this IServiceCacheManager serviceCacheManager,
            string cacheId, string endpoint)
        {
            var caches = await serviceCacheManager.GetCachesAsync();
            var cache = caches.Where(p => p.CacheDescriptor.Id == cacheId).Select(p => p.CacheEndpoint)
                .FirstOrDefault();
            return cache.Where(p => p.ToString() == endpoint).FirstOrDefault();
        }
    }
}