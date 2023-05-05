using Volo.Abp.Application.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace KissU.Abp.AppConfigurations
{
    /// <summary>
    /// 应用配置服务
    /// </summary>
    public class AppConfigurationService : ApplicationService, IAppConfigurationService
    {
        private readonly ICachedAppConfigurationClient _configuration;

        public AppConfigurationService(ICachedAppConfigurationClient configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<AppConfigurationDto> GetAsync()
        {
            Logger.LogDebug("Executing AppConfigurationService.GetAsync()...");

            var result = await _configuration.GetAsync();

            Logger.LogDebug("ExecutedAppConfigurationService.GetAsync().");

            return result;
        }
    }
}
