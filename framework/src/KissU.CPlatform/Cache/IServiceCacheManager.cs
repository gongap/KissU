using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.CPlatform.Cache.Implementation;

namespace KissU.CPlatform.Cache
{
    /// <summary>
    /// 服务缓存管理
    /// </summary>
    public interface IServiceCacheManager
    {
        /// <summary>
        /// Occurs when [created].
        /// </summary>
        event EventHandler<ServiceCacheEventArgs> Created;

        /// <summary>
        /// Occurs when [removed].
        /// </summary>
        event EventHandler<ServiceCacheEventArgs> Removed;

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        event EventHandler<ServiceCacheChangedEventArgs> Changed;

        /// <summary>
        /// Gets the caches asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCache&gt;&gt;.</returns>
        Task<IEnumerable<ServiceCache>> GetCachesAsync();

        /// <summary>
        /// Sets the caches asynchronous.
        /// </summary>
        /// <param name="caches">The caches.</param>
        /// <returns>Task.</returns>
        Task SetCachesAsync(IEnumerable<ServiceCache> caches);

        /// <summary>
        /// Sets the caches asynchronous.
        /// </summary>
        /// <param name="cacheDescriptors">The cache descriptors.</param>
        /// <returns>Task.</returns>
        Task SetCachesAsync(IEnumerable<ServiceCacheDescriptor> cacheDescriptors);

        /// <summary>
        /// Remves the address asynchronous.
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        /// <returns>Task.</returns>
        Task RemveAddressAsync(IEnumerable<CacheEndpoint> endpoints);

        /// <summary>
        /// Clears the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task ClearAsync();
    }
}