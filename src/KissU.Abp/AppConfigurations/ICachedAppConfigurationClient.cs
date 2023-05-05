using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using System.Threading.Tasks;

namespace KissU.Abp.AppConfigurations
{
    public interface ICachedAppConfigurationClient
    {
        /// <summary>
        /// 获取应用配置
        /// </summary>
        Task<AppConfigurationDto> GetAsync();

        /// <summary>
        /// 获取应用设置配置
        /// </summary>
        Task<ApplicationSettingConfigurationDto> GetSettingConfigAsync();

        /// <summary>
        /// 获取应用权限配置
        /// </summary>
        Task<ApplicationAuthConfigurationDto> GetAuthConfigAsync();

        /// <summary>
        /// 获取应用功能配置
        /// </summary>
        Task<ApplicationFeatureConfigurationDto> GetFeaturesConfigAsync();
    }
}
