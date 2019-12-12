using System.IO;
using KissU.Core.CPlatform.Configurations.Remote;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.CPlatform.Configurations
{
    public class CPlatformConfigurationProvider : FileConfigurationProvider
    {

        public CPlatformConfigurationProvider(CPlatformConfigurationSource source) : base(source) { }

        public override void Load(Stream stream)
        {
            var parser = new JsonConfigurationParser();
            this.Data = parser.Parse(stream, null);
        }
    }
}
