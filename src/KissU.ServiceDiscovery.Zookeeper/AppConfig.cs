using Microsoft.Extensions.Configuration;

namespace KissU.ServiceDiscovery.Zookeeper
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