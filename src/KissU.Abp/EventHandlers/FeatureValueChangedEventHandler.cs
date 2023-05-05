using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Features;
using KissU.Bsf.AppConfigurations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KissU.Bsf.EventHandlers
{
    /// <summary>
    /// 功能变更事件处理程序.
    /// </summary>
    public class FeatureValueChangedEventHandler : IDistributedEventHandler<FeatureValueChangedEto>, ITransientDependency
    {
        private readonly ILogger<FeatureValueChangedEventHandler> _logger;
        private readonly IDistributedCache<ApplicationFeatureConfigurationDto> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureValueChangedEventHandler"/> class.
        /// </summary>
        /// <param name="logger">ILogger</param>
        public FeatureValueChangedEventHandler(ILogger<FeatureValueChangedEventHandler> logger, IDistributedCache<ApplicationFeatureConfigurationDto> cache)
        {
            _logger = logger;
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task HandleEventAsync(FeatureValueChangedEto eventData)
        {
            _logger.LogInformation($"消费功能变更事件：{JsonConvert.SerializeObject(eventData)}");
            if (CachedAppConfigurationClient.CacheKeys.TryGetValue(CachedAppConfigurationClient.FeatureCacheKey, out var cacheKeys) && cacheKeys != null)
            {
                cacheKeys.ForEach(async cacheKey => await _cache.RemoveAsync(cacheKey));
            }
        }
    }
}
