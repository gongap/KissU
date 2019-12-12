using System.IO;
using KissU.Core.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.EventBusRabbitMQ.Configurations
{
   public class EventBusConfigurationProvider : FileConfigurationProvider
    {
        public EventBusConfigurationProvider(EventBusConfigurationSource source) : base(source) { }

        public override void Load(Stream stream)
        {
            var parser = new JsonConfigurationParser();
            this.Data = parser.Parse(stream, null);
        }
    }
}
