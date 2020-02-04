using System.Collections.Generic;
using KissU.Core.Caching.Models;
using KissU.Core.Caching.RedisCache;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Cache;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.Caching.Internal.Implementation
{
    /// <summary>
    /// 默认缓存节点提供者
    /// </summary>
    public class DefaultCacheNodeProvider : ICacheNodeProvider
    {
        private readonly CPlatformContainer _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCacheNodeProvider" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultCacheNodeProvider(CPlatformContainer serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets the service caches.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceCache&gt;.</returns>
        public IEnumerable<ServiceCache> GetServiceCaches()
        {
            var cacheWrapperSetting = AppConfig.Configuration.Get<CachingProvider>();
            var bingingSettings = cacheWrapperSetting.CachingSettings;
            var serviceCaches = new List<ServiceCache>();
            foreach (var setting in bingingSettings)
            {
                var context = _serviceProvider.GetInstances<RedisContext>(setting.Id);
                foreach (var type in context.dicHash.Keys)
                {
                    var cacheDescriptor = new CacheDescriptor
                    {
                        Id = $"{setting.Id}.{type}",
                        Prefix = setting.Id,
                        Type = type
                    };
                    int.TryParse(context.DefaultExpireTime, out var defaultExpireTime);
                    int.TryParse(context.ConnectTimeout, out var connectTimeout);
                    cacheDescriptor.DefaultExpireTime(defaultExpireTime);
                    cacheDescriptor.ConnectTimeout(connectTimeout);
                    var serviceCache = new ServiceCache
                    {
                        CacheDescriptor = cacheDescriptor,
                        CacheEndpoint = context.dicHash[type].GetNodes()
                    };
                    serviceCaches.Add(serviceCache);
                }
            }

            return serviceCaches;
        }
    }
}