using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Settings;
using KissU.Bsf.AppConfigurations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KissU.Bsf.EventHandlers
{
    /// <summary>
    /// 设置变更事件处理程序.
    /// </summary>
    public class SettingValueChangedEventHandler : IDistributedEventHandler<SettingValueChangedEto>, ITransientDependency
    {
        private readonly ILogger<SettingValueChangedEventHandler> _logger;
        private readonly IDistributedCache<ApplicationSettingConfigurationDto> _settingCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingValueChangedEventHandler"/> class.
        /// </summary>
        /// <param name="logger">ILogger</param>
        public SettingValueChangedEventHandler(ILogger<SettingValueChangedEventHandler> logger, IDistributedCache<ApplicationSettingConfigurationDto> settingCache)
        {
            _logger = logger;
            _settingCache = settingCache;
        }

        /// <inheritdoc/>
        public async Task HandleEventAsync(SettingValueChangedEto eventData)
        {
            _logger.LogInformation($"消费设置变更事件：{JsonConvert.SerializeObject(eventData)}");
            if (CachedAppConfigurationClient.CacheKeys.TryGetValue(CachedAppConfigurationClient.SettingCacheKey, out var cacheKeys) && cacheKeys != null)
            {
                cacheKeys.ForEach(async cacheKey => await _settingCache.RemoveAsync(cacheKey));
            }
        }
    }
}
