using Microsoft.Extensions.Configuration;

namespace KissU.ServiceDiscovery.Zookeeper.Configurations
{
    /// <summary>
    /// ZookeeperConfigurationSource.
    /// Implements the <see cref="Microsoft.Extensions.Configuration.FileConfigurationSource" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Configuration.FileConfigurationSource" />
    public class ZookeeperConfigurationSource : FileConfigurationSource
    {
        /// <summary>
        /// Gets or sets the configuration key prefix.
        /// </summary>
        public string ConfigurationKeyPrefix { get; set; }

        /// <summary>
        /// Builds the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IConfigurationProvider.</returns>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            FileProvider = FileProvider ?? builder.GetFileProvider();
            return new ZookeeperConfigurationProvider(this);
        }
    }
}