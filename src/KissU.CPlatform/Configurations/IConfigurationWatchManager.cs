using KissU.CPlatform.Configurations.Watch;

namespace KissU.CPlatform.Configurations
{
    /// <summary>
    /// 配置监视管理器
    /// </summary>
    public interface IConfigurationWatchManager
    {
        /// <summary>
        /// Registers the watch.
        /// </summary>
        /// <param name="watch">The watch.</param>
        void Register(ConfigurationWatch watch);
    }
}