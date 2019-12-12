using System.Collections.Generic;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.KestrelHttpServer
{
    public class ConfigurationContext
    {
        public ConfigurationContext( IServiceCollection services, 
            List<AbstractModule> modules,
            string[] virtualPaths,
           IConfigurationRoot configuration)
        {
            Services = Check.NotNull(services, nameof(services));
            Modules = Check.NotNull(modules, nameof(modules));
            VirtualPaths = Check.NotNull(virtualPaths, nameof(virtualPaths));
            Configuration = Check.NotNull(configuration, nameof(configuration));
        }

        public IConfigurationRoot Configuration { get; }
        public IServiceCollection Services { get; }

        public List<AbstractModule> Modules { get; }

        public string[] VirtualPaths { get; }
    }
}
