using Microsoft.Extensions.Configuration;

namespace KissU.Surging.Consul
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