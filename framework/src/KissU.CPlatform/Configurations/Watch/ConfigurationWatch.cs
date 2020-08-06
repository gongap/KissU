using System.Threading.Tasks;

namespace KissU.CPlatform.Configurations.Watch
{
    /// <summary>
    /// 配置监视.
    /// </summary>
    public abstract class ConfigurationWatch
    {
        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public abstract Task Process();
    }
}