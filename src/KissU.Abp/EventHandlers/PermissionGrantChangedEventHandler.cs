using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using KissU.Bsf.AppConfigurations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KissU.Bsf.EventHandlers
{
    /// <summary>
    /// 授权变更事件处理程序.
    /// </summary>
    public class PermissionGrantChangedEventHandler : IDistributedEventHandler<PermissionGrantChangedEto>, ITransientDependency
    {
        private readonly ILogger<PermissionGrantChangedEventHandler> _logger;
        private readonly IDistributedCache<ApplicationAuthConfigurationDto> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionGrantChangedEventHandler"/> class.
        /// </summary>
        /// <param name="logger">ILogger</param>
        public PermissionGrantChangedEventHandler(ILogger<PermissionGrantChangedEventHandler> logger, IDistributedCache<ApplicationAuthConfigurationDto> cache)
        {
            _logger = logger;
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task HandleEventAsync(PermissionGrantChangedEto eventData)
        {
            _logger.LogInformation($"消费授权变更事件：{JsonConvert.SerializeObject(eventData)}");
            if (CachedAppConfigurationClient.CacheKeys.TryGetValue(CachedAppConfigurationClient.AuthCacheKey, out var cacheKeys) && cacheKeys != null)
            {
                cacheKeys.ForEach(async cacheKey => await _cache.RemoveAsync(cacheKey));
            }
        }
    }
}
