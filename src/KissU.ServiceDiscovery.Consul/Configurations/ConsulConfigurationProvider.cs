using System.IO;
using KissU.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.ServiceDiscovery.Consul.Configurations
{
    /// <summary>
    /// ConsulConfigurationProvider.
    /// Implements the <see cref="Microsoft.Extensions.Configuration.FileConfigurationProvider" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Configuration.FileConfigurationProvider" />
    public class ConsulConfigurationProvider : FileConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsulConfigurationProvider" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public ConsulConfigurationProvider(ConsulConfigurationSource source) : base(source)
        {
        }

        /// <summary>
        /// Loads the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public override void Load(Stream stream)
        {
            var parser = new JsonConfigurationParser();
            Data = parser.Parse(stream, null);
        }
    }
}