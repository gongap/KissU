using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.Serialization;
using KissU.Core.Utilities;
using KissU.Surging.CPlatform.Cache;
using KissU.Surging.CPlatform.Cache.Implementation;

namespace KissU.Surging.ApiGateWay.ServiceDiscovery.Implementation
{
    /// <summary>
    /// 服务缓存提供者
    /// </summary>
    public class ServiceCacheProvider : IServiceCacheProvider
    {
        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCacheProvider" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public ServiceCacheProvider(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// get service descriptor as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;CacheDescriptor&gt;&gt;.</returns>
        public async Task<IEnumerable<CacheDescriptor>> GetServiceDescriptorAsync()
        {
            return await ServiceLocator.GetService<IServiceCacheManager>().GetCacheDescriptorAsync();
        }

        /// <summary>
        /// get cache endpoint as an asynchronous operation.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;CacheEndpoint&gt;&gt;.</returns>
        public async Task<IEnumerable<CacheEndpoint>> GetCacheEndpointAsync(string cacheId)
        {
            return await ServiceLocator.GetService<IServiceCacheManager>().GetCacheEndpointAsync(cacheId);
        }

        /// <summary>
        /// get cache endpoint as an asynchronous operation.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task&lt;CacheEndpoint&gt;.</returns>
        public async Task<CacheEndpoint> GetCacheEndpointAsync(string cacheId, string endpoint)
        {
            return await ServiceLocator.GetService<IServiceCacheManager>().GetCacheEndpointAsync(cacheId, endpoint);
        }

        /// <summary>
        /// Sets the cache endpoint by endpoint.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="cacheEndpoint">The cache endpoint.</param>
        public async Task SetCacheEndpointByEndpoint(string cacheId, string endpoint, CacheEndpoint cacheEndpoint)
        {
            var model = await ServiceLocator.GetService<IServiceCacheManager>().GetAsync(cacheId);

            var cacheEndpoints = model.CacheEndpoint.Where(p => p.ToString() != cacheEndpoint.ToString()).ToList();
            cacheEndpoints.Add(cacheEndpoint);
            model.CacheEndpoint = cacheEndpoints;
            var caches = new[] {model};
            var descriptors = caches.Where(cache => cache != null).Select(cache => new ServiceCacheDescriptor
            {
                AddressDescriptors = cache.CacheEndpoint?.Select(address => new CacheEndpointDescriptor
                {
                    Type = address.GetType().FullName,
                    Value = _serializer.Serialize(address)
                }) ?? Enumerable.Empty<CacheEndpointDescriptor>(),
                CacheDescriptor = cache.CacheDescriptor
            });
            await ServiceLocator.GetService<IServiceCacheManager>().SetCachesAsync(descriptors);
        }


        /// <summary>
        /// delete cache endpoint as an asynchronous operation.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="endpoint">The endpoint.</param>
        public async Task DelCacheEndpointAsync(string cacheId, string endpoint)
        {
            var model = await ServiceLocator.GetService<IServiceCacheManager>().GetAsync(cacheId);
            var cacheEndpoints = model.CacheEndpoint.Where(p => p.ToString() != endpoint).ToList();
            model.CacheEndpoint = cacheEndpoints;
            var caches = new[] {model};
            var descriptors = caches.Where(cache => cache != null).Select(cache => new ServiceCacheDescriptor
            {
                AddressDescriptors = cache.CacheEndpoint?.Select(address => new CacheEndpointDescriptor
                {
                    Type = address.GetType().FullName,
                    Value = _serializer.Serialize(address)
                }) ?? Enumerable.Empty<CacheEndpointDescriptor>(),
                CacheDescriptor = cache.CacheDescriptor
            });
            await ServiceLocator.GetService<IServiceCacheManager>().SetCachesAsync(descriptors);
        }
    }
}