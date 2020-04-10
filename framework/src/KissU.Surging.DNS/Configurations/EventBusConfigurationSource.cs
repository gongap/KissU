using Microsoft.Extensions.Configuration;

namespace KissU.Surging.DNS.Configurations
{
    /// <summary>
    /// EventBusConfigurationSource.
    /// Implements the <see cref="Microsoft.Extensions.Configuration.FileConfigurationSource" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Configuration.FileConfigurationSource" />
    public class EventBusConfigurationSource : FileConfigurationSource
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
            return new EventBusConfigurationProvider(this);
        }
    }
}