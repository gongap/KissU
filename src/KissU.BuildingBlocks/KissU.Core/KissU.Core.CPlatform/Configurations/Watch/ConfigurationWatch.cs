using System.Threading.Tasks;

namespace KissU.Core.CPlatform.Configurations.Watch
{
    /// <summary>
    /// 配置监视.
    /// </summary>
    public abstract class ConfigurationWatch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationWatch" /> class.
        /// </summary>
        protected ConfigurationWatch()
        {
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public abstract Task Process();
    }
}
