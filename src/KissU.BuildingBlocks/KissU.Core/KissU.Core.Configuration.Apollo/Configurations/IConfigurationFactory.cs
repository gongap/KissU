using Microsoft.Extensions.Configuration;

namespace KissU.Core.Configuration.Apollo.Configurations
{
    public interface IConfigurationFactory
    {
        IConfiguration Create();
    }
}