using System.Collections.Generic;
using KissU.Helpers;
using KissU.Module;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Surging.KestrelHttpServer
{
    /// <summary>
    /// ConfigurationContext.
    /// </summary>
    public class ConfigurationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationContext" /> class.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="modules">The modules.</param>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <param name="configuration">The configuration.</param>
        public ConfigurationContext(IServiceCollection services,
            List<AbstractModule> modules,
            string[] virtualPaths,
            IConfigurationRoot configuration)
        {
            Services = Check.NotNull(services, nameof(services));
            Modules = Check.NotNull(modules, nameof(modules));
            VirtualPaths = Check.NotNull(virtualPaths, nameof(virtualPaths));
            Configuration = Check.NotNull(configuration, nameof(configuration));
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Gets the services.
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets the modules.
        /// </summary>
        public List<AbstractModule> Modules { get; }

        /// <summary>
        /// Gets the virtual paths.
        /// </summary>
        public string[] VirtualPaths { get; }
    }
}