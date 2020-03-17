using System.IO;
using KissU.Surging.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.Surging.EventBusRabbitMQ.Configurations
{
    /// <summary>
    /// EventBusConfigurationProvider.
    /// Implements the <see cref="Microsoft.Extensions.Configuration.FileConfigurationProvider" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Configuration.FileConfigurationProvider" />
    public class EventBusConfigurationProvider : FileConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventBusConfigurationProvider" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public EventBusConfigurationProvider(EventBusConfigurationSource source) : base(source)
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