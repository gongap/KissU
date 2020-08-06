using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.CPlatform.Cache;

namespace KissU.Caching.HealthChecks.Implementation
{
    /// <summary>
    /// 默认的健康检查服务
    /// </summary>
    public class DefaultHealthCheckService : IHealthCheckService, IDisposable
    {
        private readonly ConcurrentDictionary<ValueTuple<string, int>, MonitorEntry> _dictionary =
            new ConcurrentDictionary<ValueTuple<string, int>, MonitorEntry>();

        private readonly IServiceCacheManager _serviceCacheManager;
        private readonly Timer _timer;


        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHealthCheckService" /> class.
        /// </summary>
        /// <param name="serviceCacheManager">The service cache manager.</param>
        public DefaultHealthCheckService(IServiceCacheManager serviceCacheManager)
        {
            var timeSpan = TimeSpan.FromSeconds(10);
            _serviceCacheManager = serviceCacheManager;
            _timer = new Timer(async s =>
            {
                await Check(_dictionary.ToArray().Select(i => i.Value));
                RemoveUnhealthyAddress(_dictionary.ToArray().Select(i => i.Value).Where(m => m.UnhealthyTimes >= 6));
            }, null, timeSpan, timeSpan);

            //去除监控。
            _serviceCacheManager.Removed += (s, e) => { Remove(e.Cache.CacheEndpoint); };

            //重新监控。
            _serviceCacheManager.Created += async (s, e) =>
            {
                var keys = e.Cache.CacheEndpoint.Select(cacheEndpoint =>
                {
                    return new ValueTuple<string, int>(cacheEndpoint.Host, cacheEndpoint.Port);
                });
                await Check(_dictionary.Where(i => keys.Contains(i.Key)).Select(i => i.Value));
            };
            //重新监控。
            _serviceCacheManager.Changed += async (s, e) =>
            {
                var keys = e.Cache.CacheEndpoint.Select(cacheEndpoint =>
                {
                    return new ValueTuple<string, int>(cacheEndpoint.Host, cacheEndpoint.Port);
                });
                await Check(_dictionary.Where(i => keys.Contains(i.Key)).Select(i => i.Value));
            };
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _timer.Dispose();
        }

        /// <summary>
        /// 判断一个地址是否健康。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>健康返回true，否则返回false。</returns>
        public ValueTask<bool> IsHealth(CacheEndpoint address, string cacheId)
        {
            MonitorEntry entry;
            return !_dictionary.TryGetValue(new ValueTuple<string, int>(address.Host, address.Port), out entry)
                ? new ValueTask<bool>(Check(address, cacheId))
                : new ValueTask<bool>(entry.Health);
        }

        /// <summary>
        /// 标记一个地址为失败的。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>一个任务。</returns>
        public Task MarkFailure(CacheEndpoint address, string cacheId)
        {
            return Task.Run(() =>
            {
                var entry = _dictionary.GetOrAdd(new ValueTuple<string, int>(address.Host, address.Port),
                    k => new MonitorEntry(address, cacheId, false));
                entry.Health = false;
            });
        }

        /// <summary>
        /// 监控一个地址。
        /// </summary>
        /// <param name="address">地址模型。</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <returns>一个任务。</returns>
        public void Monitor(CacheEndpoint address, string cacheId)
        {
            _dictionary.GetOrAdd(new ValueTuple<string, int>(address.Host, address.Port),
                k => new MonitorEntry(address, cacheId));
        }

        private async Task<bool> Check(CacheEndpoint address, string id)
        {
            return await CacheContainer.GetService<ICacheProvider>(id)
                .ConnectionAsync(address);
        }

        private async Task Check(IEnumerable<MonitorEntry> entrys)
        {
            foreach (var entry in entrys)
            {
                try
                {
                    await CacheContainer.GetService<ICacheProvider>(entry.CacheId).ConnectionAsync(entry.EndPoint);
                    entry.UnhealthyTimes = 0;
                    entry.Health = true;
                }
                catch
                {
                    entry.UnhealthyTimes++;
                    entry.Health = false;
                }
            }
        }

        private void Remove(IEnumerable<CacheEndpoint> cacheEndpoints)
        {
            foreach (var cacheEndpoint in cacheEndpoints)
            {
                MonitorEntry value;
                _dictionary.TryRemove(new ValueTuple<string, int>(cacheEndpoint.Host, cacheEndpoint.Port), out value);
            }
        }


        private void RemoveUnhealthyAddress(IEnumerable<MonitorEntry> monitorEntry)
        {
            if (monitorEntry.Any())
            {
                var addresses = monitorEntry.Select(p => p.EndPoint).ToList();
                _serviceCacheManager.RemveAddressAsync(addresses).Wait();
                addresses.ForEach(p =>
                {
                    _dictionary.TryRemove(new ValueTuple<string, int>(p.Host, p.Port), out var value);
                });
            }
        }


        #region Help Class

        /// <summary>
        /// MonitorEntry.
        /// </summary>
        protected class MonitorEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MonitorEntry" /> class.
            /// </summary>
            /// <param name="address">The address.</param>
            /// <param name="cacheId">The cache identifier.</param>
            /// <param name="health">if set to <c>true</c> [health].</param>
            public MonitorEntry(CacheEndpoint address, string cacheId, bool health = true)
            {
                EndPoint = address;
                Health = health;
                CacheId = cacheId;
            }

            /// <summary>
            /// Gets or sets the unhealthy times.
            /// </summary>
            public int UnhealthyTimes { get; set; }

            /// <summary>
            /// Gets or sets the cache identifier.
            /// </summary>
            public string CacheId { get; set; }

            /// <summary>
            /// Gets or sets the end point.
            /// </summary>
            public CacheEndpoint EndPoint { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="MonitorEntry" /> is health.
            /// </summary>
            public bool Health { get; set; }
        }

        #endregion Help Class
    }
}