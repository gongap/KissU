using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consul;
using KissU.CPlatform.Cache;
using KissU.CPlatform.Cache.Implementation;
using KissU.Serialization;
using KissU.ServiceDiscovery.Consul.Configurations;
using KissU.ServiceDiscovery.Consul.Internal;
using KissU.ServiceDiscovery.Consul.Utilitys;
using KissU.ServiceDiscovery.Consul.WatcherProvider;
using KissU.ServiceDiscovery.Consul.WatcherProvider.Implementation;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace KissU.ServiceDiscovery.Consul
{
    /// <summary>
    /// ConsulServiceCacheManager.
    /// Implements the <see cref="KissU.CPlatform.Cache.Implementation.ServiceCacheManagerBase" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Cache.Implementation.ServiceCacheManagerBase" />
    /// <seealso cref="System.IDisposable" />
    public class ConsulServiceCacheManager : ServiceCacheManagerBase, IDisposable
    {
        private readonly ConfigInfo _configInfo;
        private readonly IConsulClientProvider _consulClientFactory;
        private readonly ILogger<ConsulServiceCacheManager> _logger;
        private readonly IClientWatchManager _manager;
        private readonly ISerializer<byte[]> _serializer;
        private readonly IServiceCacheFactory _serviceCacheFactory;
        private readonly ISerializer<string> _stringSerializer;
        private ServiceCache[] _serviceCaches;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsulServiceCacheManager" /> class.
        /// </summary>
        /// <param name="configInfo">The configuration information.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="stringSerializer">The string serializer.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="serviceCacheFactory">The service cache factory.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="consulClientFactory">The consul client factory.</param>
        public ConsulServiceCacheManager(ConfigInfo configInfo, ISerializer<byte[]> serializer,
            ISerializer<string> stringSerializer, IClientWatchManager manager, IServiceCacheFactory serviceCacheFactory,
            ILogger<ConsulServiceCacheManager> logger, IConsulClientProvider consulClientFactory) : base(
            stringSerializer)
        {
            _configInfo = configInfo;
            _serializer = serializer;
            _stringSerializer = stringSerializer;
            _serviceCacheFactory = serviceCacheFactory;
            _consulClientFactory = consulClientFactory;
            _logger = logger;
            _manager = manager;
            EnterCaches().Wait();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// clear as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public override async Task ClearAsync()
        {
            var clients = await _consulClientFactory.GetClients();
            foreach (var client in clients)
            {
                // 根据前缀获取consul结果
                var queryResult = await client.KV.List(_configInfo.CachePath);
                var response = queryResult.Response;
                if (response != null)
                {
                    foreach (var result in response)
                    {
                        await client.KV.DeleteCAS(result);
                    }
                }
            }
        }

        /// <summary>
        /// set caches as an asynchronous operation.
        /// </summary>
        /// <param name="caches">The caches.</param>
        /// <returns>Task.</returns>
        public override async Task SetCachesAsync(IEnumerable<ServiceCache> caches)
        {
            var serviceCaches = await GetCaches(caches.Select(p => $"{_configInfo.CachePath}{p.CacheDescriptor.Id}"));

            await RemoveCachesAsync(caches);
            await base.SetCachesAsync(caches);
        }

        /// <summary>
        /// get caches as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCache&gt;&gt;.</returns>
        public override async Task<IEnumerable<ServiceCache>> GetCachesAsync()
        {
            await EnterCaches();
            return _serviceCaches;
        }

        /// <summary>
        /// remve address as an asynchronous operation.
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        /// <returns>Task.</returns>
        public override async Task RemveAddressAsync(IEnumerable<CacheEndpoint> endpoints)
        {
            var caches = await GetCachesAsync();
            try
            {
                foreach (var cache in caches)
                {
                    foreach (var endpoint in cache.CacheEndpoint)
                    {
                        if (endpoints.Any(x => x == endpoint))
                        {
                            endpoint.Health = false;
                        }
                    }

                    //cache.CacheEndpoint = cache.CacheEndpoint.Except(endpoints);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            await base.SetCachesAsync(caches);
        }

        /// <summary>
        /// set caches as an asynchronous operation.
        /// </summary>
        /// <param name="cacheDescriptors">The cache descriptors.</param>
        public override async Task SetCachesAsync(IEnumerable<ServiceCacheDescriptor> cacheDescriptors)
        {
            var clients = await _consulClientFactory.GetClients();
            foreach (var client in clients)
            {
                foreach (var cacheDescriptor in cacheDescriptors)
                {
                    var nodeData = _serializer.Serialize(cacheDescriptor);
                    var keyValuePair = new KVPair($"{_configInfo.CachePath}{cacheDescriptor.CacheDescriptor.Id}")
                        {Value = nodeData};
                    await client.KV.Put(keyValuePair);
                }
            }
        }

        private async Task<ServiceCache[]> GetCaches(IEnumerable<string> childrens)
        {
            childrens = childrens.ToArray();
            var caches = new List<ServiceCache>(childrens.Count());

            foreach (var children in childrens)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace($"准备从节点：{children}中获取缓存信息。");

                var cache = await GetCache(children);
                if (cache != null)
                    caches.Add(cache);
            }

            return caches.ToArray();
        }

        private async Task<ServiceCache> GetCache(string path)
        {
            ServiceCache result = null;
            var client = await GetConsulClient();
            var watcher = new NodeMonitorWatcher(GetConsulClient, _manager, path,
                async (oldData, newData) => await NodeChange(oldData, newData), null);
            var queryResult = await client.KV.Keys(path);
            if (queryResult.Response != null)
            {
                var data = await client.GetDataAsync(path);
                if (data != null)
                {
                    watcher.SetCurrentData(data);
                    result = await GetCache(data);
                }
            }

            return result;
        }

        #region 私有方法

        private async Task RemoveCachesAsync(IEnumerable<ServiceCache> caches)
        {
            var path = _configInfo.CachePath;
            caches = caches.ToArray();

            if (_serviceCaches != null)
            {
                var clients = await _consulClientFactory.GetClients();
                foreach (var client in clients)
                {
                    var deletedCacheIds = caches.Select(i => i.CacheDescriptor.Id).ToArray();
                    foreach (var deletedCacheId in deletedCacheIds)
                    {
                        var nodePath = $"{path}{deletedCacheId}";
                        await client.KV.Delete(nodePath);
                    }
                }
            }
        }

        private async Task EnterCaches()
        {
            if (_serviceCaches != null && _serviceCaches.Length > 0)
                return;
            var client = await GetConsulClient();
            var watcher = new ChildrenMonitorWatcher(GetConsulClient, _manager, _configInfo.CachePath,
                async (oldChildrens, newChildrens) => await ChildrenChange(oldChildrens, newChildrens),
                result => ConvertPaths(result).Result);
            if (client.KV.Keys(_configInfo.CachePath).Result.Response?.Count() > 0)
            {
                var result = await client.GetChildrenAsync(_configInfo.CachePath);
                var keys = await client.KV.Keys(_configInfo.CachePath);
                var childrens = result;
                watcher.SetCurrentData(ConvertPaths(childrens).Result.Select(key => $"{_configInfo.CachePath}{key}")
                    .ToArray());
                _serviceCaches = await GetCaches(keys.Response);
            }
            else
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                    _logger.LogWarning($"无法获取缓存信息，因为节点：{_configInfo.CachePath}，不存在。");
                _serviceCaches = new ServiceCache[0];
            }
        }

        private static bool DataEquals(IReadOnlyList<byte> data1, IReadOnlyList<byte> data2)
        {
            if (data1.Count != data2.Count)
                return false;
            for (var i = 0; i < data1.Count; i++)
            {
                var b1 = data1[i];
                var b2 = data2[i];
                if (b1 != b2)
                    return false;
            }

            return true;
        }

        private async Task<ServiceCache> GetCache(byte[] data)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"准备转换服务缓存，配置内容：{Encoding.UTF8.GetString(data)}。");

            if (data == null)
                return null;

            var descriptor = _serializer.Deserialize<byte[], ServiceCacheDescriptor>(data);
            return (await _serviceCacheFactory.CreateServiceCachesAsync(new[] {descriptor})).First();
        }

        private async Task<ServiceCache> GetCacheData(string data)
        {
            if (data == null)
                return null;

            var descriptor =
                _stringSerializer.Deserialize(data, typeof(ServiceCacheDescriptor)) as ServiceCacheDescriptor;
            return (await _serviceCacheFactory.CreateServiceCachesAsync(new[] {descriptor})).First();
        }

        private async Task<ServiceCache[]> GetCacheDatas(string[] caches)
        {
            var serviceCaches = new List<ServiceCache>();
            foreach (var cache in caches)
            {
                var serviceCache = await GetCacheData(cache);
                serviceCaches.Add(serviceCache);
            }

            return serviceCaches.ToArray();
        }

        private async Task<string[]> ConvertPaths(string[] datas)
        {
            var paths = new List<string>();
            foreach (var data in datas)
            {
                var result = await GetCacheData(data);
                var serviceId = result?.CacheDescriptor.Id;
                if (!string.IsNullOrEmpty(serviceId))
                    paths.Add(serviceId);
            }

            return paths.ToArray();
        }

        private async ValueTask<ConsulClient> GetConsulClient()
        {
            var client = await _consulClientFactory.GetClient();
            return client;
        }

        private async Task NodeChange(byte[] oldData, byte[] newData)
        {
            if (DataEquals(oldData, newData))
                return;

            var newCache = await GetCache(newData);
            //得到旧的缓存。
            var oldCache = _serviceCaches.FirstOrDefault(i => i.CacheDescriptor.Id == newCache.CacheDescriptor.Id);

            lock (_serviceCaches)
            {
                //删除旧缓存，并添加上新的缓存。
                _serviceCaches =
                    _serviceCaches
                        .Where(i => i.CacheDescriptor.Id != newCache.CacheDescriptor.Id)
                        .Concat(new[] {newCache}).ToArray();
            }

            if (newCache == null)
                //触发删除事件。
                OnRemoved(new ServiceCacheEventArgs(oldCache));

            else if (oldCache == null)
                OnCreated(new ServiceCacheEventArgs(newCache));

            else
                //触发缓存变更事件。
                OnChanged(new ServiceCacheChangedEventArgs(newCache, oldCache));
        }

        private async Task ChildrenChange(string[] oldChildrens, string[] newChildrens)
        {
            //计算出已被删除的节点。
            var deletedChildrens = oldChildrens.Except(newChildrens).ToArray();
            //计算出新增的节点。
            var createdChildrens = newChildrens.Except(oldChildrens).ToArray();

            if (deletedChildrens.Length > 0 || createdChildrens.Length > 0 && _logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation($"最新的节点信息：{string.Join(",", newChildrens)}");
                _logger.LogInformation($"旧的节点信息：{string.Join(",", oldChildrens)}");
                if (deletedChildrens.Length > 0)
                    _logger.LogInformation($"需要被删除的服务缓存节点：{string.Join(",", deletedChildrens)}");
                if (createdChildrens.Length > 0)
                    _logger.LogInformation($"需要被添加的服务缓存节点：{string.Join(",", createdChildrens)}");
            }

            //获取新增的缓存信息。
            var newCaches = (await GetCaches(createdChildrens)).ToArray();

            var caches = _serviceCaches.ToArray();
            lock (_serviceCaches)
            {
                _serviceCaches = _serviceCaches
                    //删除无效的缓存节点。
                    .Where(i => !deletedChildrens.Contains($"{_configInfo.CachePath}{i.CacheDescriptor.Id}"))
                    //连接上新的缓存。
                    .Concat(newCaches)
                    .ToArray();
            }

            //需要删除的缓存集合。
            var deletedCaches = caches
                .Where(i => deletedChildrens.Contains($"{_configInfo.CachePath}{i.CacheDescriptor.Id}")).ToArray();
            //触发删除事件。
            OnRemoved(deletedCaches.Select(cache => new ServiceCacheEventArgs(cache)).ToArray());

            //触发缓存被创建事件。
            OnCreated(newCaches.Select(cache => new ServiceCacheEventArgs(cache)).ToArray());

            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug("Consul缓存节点数据更新成功");
        }

        #endregion
    }
}