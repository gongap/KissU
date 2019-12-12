using System.IO;
using KissU.Core.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.Zookeeper.Configurations
{
    public class ZookeeperConfigurationProvider : FileConfigurationProvider
    {
        public ZookeeperConfigurationProvider(ZookeeperConfigurationSource source) : base(source) { }

        public override void Load(Stream stream)
        {
            var parser = new JsonConfigurationParser();
            this.Data = parser.Parse(stream, null);
        }
    }
}
