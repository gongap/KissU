using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KissU.Bsf.EventHandlers
{
    /// <summary>
    /// 租户更新事件处理程序.
    /// </summary>
    public class TenantUpdatedEventHandler : IDistributedEventHandler<TenantUpdatedEto>, ITransientDependency
    {
        private readonly ILogger<TenantUpdatedEventHandler> _logger;
        private readonly IDistributedCache<TenantConfiguration> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantUpdatedEventHandler"/> class.
        /// </summary>
        /// <param name="logger">ILogger</param>
        public TenantUpdatedEventHandler(ILogger<TenantUpdatedEventHandler> logger, IDistributedCache<TenantConfiguration> cache)
        {
            _logger = logger;
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task HandleEventAsync(TenantUpdatedEto eventData)
        {
            _logger.LogInformation($"消费租户更新事件：{JsonConvert.SerializeObject(eventData)}");
            if (eventData != null)
            {
                var cacheKey = CreateCacheKey(eventData.Id);
                await _cache.RemoveAsync(cacheKey);
                cacheKey = CreateCacheKey(eventData.Name);
                await _cache.RemoveAsync(cacheKey);
            }
        }

        protected virtual string CreateCacheKey(string tenantName)
        {
            return $"BsfRemoteTenantStore_Name_{tenantName}";
        }

        protected virtual string CreateCacheKey(Guid tenantId)
        {
            return $"BsfRemoteTenantStore_Id_{tenantId:N}";
        }
    }
}
