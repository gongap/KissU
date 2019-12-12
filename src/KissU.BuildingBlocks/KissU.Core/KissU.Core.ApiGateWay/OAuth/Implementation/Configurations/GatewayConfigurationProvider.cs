using System.IO;
using KissU.Core.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.ApiGateWay.OAuth.Implementation.Configurations
{
   public class GatewayConfigurationProvider : FileConfigurationProvider
    {
        public GatewayConfigurationProvider(GatewayConfigurationSource source) : base(source) { }

        public override void Load(Stream stream)
        {
            var parser = new JsonConfigurationParser();
            this.Data = parser.Parse(stream, null);
        }
    }
}