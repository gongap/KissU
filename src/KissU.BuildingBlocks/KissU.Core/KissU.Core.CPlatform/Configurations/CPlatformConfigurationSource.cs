using Microsoft.Extensions.Configuration;

namespace KissU.Core.CPlatform.Configurations
{
    /// <summary>
    /// 平台配置源.
    /// Implements the <see cref="FileConfigurationSource" />.
    /// </summary>
    /// <seealso cref="FileConfigurationSource" />
    public class CPlatformConfigurationSource : FileConfigurationSource
    {
        /// <summary>
        /// Gets or sets the configuration key prefix.
        /// </summary>
        public string ConfigurationKeyPrefix { get; set; }

        /// <summary>
        /// Builds the <see cref="T:Microsoft.Extensions.Configuration.IConfigurationProvider" /> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.</param>
        /// <returns>A <see cref="T:Microsoft.Extensions.Configuration.IConfigurationProvider" /></returns>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            FileProvider = FileProvider ?? builder.GetFileProvider();
            return new CPlatformConfigurationProvider(this);
        }
    }
}