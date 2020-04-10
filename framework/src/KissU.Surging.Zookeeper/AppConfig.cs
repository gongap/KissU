using Microsoft.Extensions.Configuration;

namespace KissU.Surging.Zookeeper
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public static IConfigurationRoot Configuration { get; set; }
    }
}