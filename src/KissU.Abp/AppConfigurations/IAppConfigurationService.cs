using KissU.Dependency;
using System.Threading.Tasks;

namespace KissU.Abp.AppConfigurations
{
    /// <summary>
    /// 应用配置服务
    /// </summary>
    public interface IAppConfigurationService : IServiceKey
    {
        /// <summary>
        /// 获取应用配置
        /// </summary>
        /// <returns>应用配置</returns>
        Task<AppConfigurationDto> GetAsync();
    }
}
