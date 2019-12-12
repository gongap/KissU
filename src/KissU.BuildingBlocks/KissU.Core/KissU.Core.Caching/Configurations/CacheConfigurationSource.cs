using Microsoft.Extensions.Configuration;

namespace KissU.Core.Caching.Configurations
{
    public class CacheConfigurationSource : FileConfigurationSource
    {
        public string ConfigurationKeyPrefix { get; set; }

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            FileProvider = FileProvider ?? builder.GetFileProvider();
            return new CacheConfigurationProvider(this);
        }
    }
}