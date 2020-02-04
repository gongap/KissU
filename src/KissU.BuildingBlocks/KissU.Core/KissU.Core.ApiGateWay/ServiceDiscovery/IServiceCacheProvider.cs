using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Cache;

namespace KissU.Core.ApiGateWay.ServiceDiscovery
{
    /// <summary>
    /// Interface IServiceCacheProvider
    /// </summary>
    public interface IServiceCacheProvider
    {
        /// <summary>
        /// Gets the service descriptor asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;CacheDescriptor&gt;&gt;.</returns>
        Task<IEnumerable<CacheDescriptor>> GetServiceDescriptorAsync();

        /// <summary>
        /// Gets the cache endpoint asynchronous.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;CacheEndpoint&gt;&gt;.</returns>
        Task<IEnumerable<CacheEndpoint>> GetCacheEndpointAsync(string cacheId);

        /// <summary>
        /// Gets the cache endpoint asynchronous.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task&lt;CacheEndpoint&gt;.</returns>
        Task<CacheEndpoint> GetCacheEndpointAsync(string cacheId, string endpoint);

        /// <summary>
        /// Deletes the cache endpoint asynchronous.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task.</returns>
        Task DelCacheEndpointAsync(string cacheId, string endpoint);

        /// <summary>
        /// Sets the cache endpoint by endpoint.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="cacheEndpoint">The cache endpoint.</param>
        /// <returns>Task.</returns>
        Task SetCacheEndpointByEndpoint(string cacheId, string endpoint, CacheEndpoint cacheEndpoint);
    }
}