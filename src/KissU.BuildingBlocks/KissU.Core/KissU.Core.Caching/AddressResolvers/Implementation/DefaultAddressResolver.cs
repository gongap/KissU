using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.Caching.HashAlgorithms;
using KissU.Core.Caching.HealthChecks;
using KissU.Core.Caching.RedisCache;
using KissU.Core.CPlatform.Cache;
using KissU.Core.CPlatform.Cache.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Caching.AddressResolvers.Implementation
{
    /// <summary>
    /// 默认地址解析程序
    /// </summary>
    public class DefaultAddressResolver : IAddressResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAddressResolver" /> class.
        /// </summary>
        /// <param name="healthCheckService">The health check service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceCacheManager">The service cache manager.</param>
        public DefaultAddressResolver(IHealthCheckService healthCheckService, ILogger<DefaultAddressResolver> logger,
            IServiceCacheManager serviceCacheManager)
        {
            _healthCheckService = healthCheckService;
            _logger = logger;
            _serviceCacheManager = serviceCacheManager;
            _serviceCacheManager.Changed += ServiceCacheManager_Removed;
            _serviceCacheManager.Removed += ServiceCacheManager_Removed;
            _serviceCacheManager.Created += ServiceCacheManager_Add;
        }

        /// <summary>
        /// Resolvers the specified cache identifier.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>ValueTask&lt;ConsistentHashNode&gt;.</returns>
        public async ValueTask<ConsistentHashNode> Resolver(string cacheId, string item)
        {
            _concurrent.TryGetValue(cacheId, out var descriptor);
            if (descriptor == null)
            {
                var descriptors = await _serviceCacheManager.GetCachesAsync();
                descriptor = descriptors.FirstOrDefault(i => i.CacheDescriptor.Id == cacheId);
                if (descriptor != null)
                {
                    _concurrent.GetOrAdd(cacheId, descriptor);
                }
                else
                {
                    if (descriptor == null)
                    {
                        if (_logger.IsEnabled(LogLevel.Warning))
                            _logger.LogWarning($"根据缓存id：{cacheId}，找不到缓存信息。");
                        return null;
                    }
                }
            }

            var address = new List<CacheEndpoint>();
            foreach (var addressModel in descriptor.CacheEndpoint)
            {
                _healthCheckService.Monitor(addressModel, cacheId);
                if (!await _healthCheckService.IsHealth(addressModel, cacheId))
                    continue;

                address.Add(addressModel);
            }

            if (address.Count == 0)
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                    _logger.LogWarning($"根据缓存id：{cacheId}，找不到可用的地址。");
                return null;
            }

            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation(
                    $"根据缓存id：{cacheId}，找到以下可用地址：{string.Join(",", address.Select(i => i.ToString()))}。");
            var redisContext = CacheContainer.GetService<RedisContext>(descriptor.CacheDescriptor.Prefix);
            ConsistentHash<ConsistentHashNode> hash;
            redisContext.dicHash.TryGetValue(descriptor.CacheDescriptor.Type, out hash);
            return hash != null ? hash.GetItemNode(item) : default;
        }


        private static string GetKey(CacheDescriptor descriptor)
        {
            return descriptor.Id;
        }

        private void ServiceCacheManager_Removed(object sender, ServiceCacheEventArgs e)
        {
            var key = GetKey(e.Cache.CacheDescriptor);
            if (CacheContainer.IsRegistered<RedisContext>(e.Cache.CacheDescriptor.Prefix))
            {
                var redisContext = CacheContainer.GetService<RedisContext>(e.Cache.CacheDescriptor.Prefix);
                ServiceCache value;
                _concurrent.TryRemove(key, out value);
                ConsistentHash<ConsistentHashNode> hash;
                redisContext.dicHash.TryGetValue(e.Cache.CacheDescriptor.Type, out hash);
                if (hash != null)
                    foreach (var node in e.Cache.CacheEndpoint)
                    {
                        var hashNode = node as ConsistentHashNode;
                        var addr = string.Format("{0}:{1}", hashNode.Host, hashNode.Port);
                        hash.Remove(addr);
                        hash.Add(hashNode, addr);
                    }
            }
        }

        private void ServiceCacheManager_Add(object sender, ServiceCacheEventArgs e)
        {
            var key = GetKey(e.Cache.CacheDescriptor);
            if (CacheContainer.IsRegistered<RedisContext>(e.Cache.CacheDescriptor.Prefix))
            {
                var redisContext = CacheContainer.GetService<RedisContext>(e.Cache.CacheDescriptor.Prefix);
                _concurrent.GetOrAdd(key, e.Cache);
                ConsistentHash<ConsistentHashNode> hash;
                redisContext.dicHash.TryGetValue(e.Cache.CacheDescriptor.Type, out hash);
                if (hash != null)
                    foreach (var node in e.Cache.CacheEndpoint)
                    {
                        var hashNode = node as ConsistentHashNode;
                        var addr = string.Format("{0}:{1}", hashNode.Host, hashNode.Port);
                        hash.Remove(addr);
                        hash.Add(hashNode, addr);
                    }
            }
        }

        #region Field  

        private readonly ILogger<DefaultAddressResolver> _logger;
        private readonly IHealthCheckService _healthCheckService;
        private readonly IServiceCacheManager _serviceCacheManager;

        private readonly ConcurrentDictionary<string, ServiceCache> _concurrent =
            new ConcurrentDictionary<string, ServiceCache>();

        #endregion
    }
}