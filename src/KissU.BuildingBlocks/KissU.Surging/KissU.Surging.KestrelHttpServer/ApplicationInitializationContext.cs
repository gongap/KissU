using System.Collections.Generic;
using KissU.Surging.CPlatform.Module;
using KissU.Surging.CPlatform.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace KissU.Surging.KestrelHttpServer
{
    /// <summary>
    /// ApplicationInitializationContext.
    /// </summary>
    public class ApplicationInitializationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationInitializationContext" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="modules">The modules.</param>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <param name="configuration">The configuration.</param>
        public ApplicationInitializationContext(IApplicationBuilder builder,
            List<AbstractModule> modules,
            string[] virtualPaths,
            IConfigurationRoot configuration)
        {
            Builder = Check.NotNull(builder, nameof(builder));
            Modules = Check.NotNull(modules, nameof(modules));
            VirtualPaths = Check.NotNull(virtualPaths, nameof(virtualPaths));
            Configuration = Check.NotNull(configuration, nameof(configuration));
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        public IApplicationBuilder Builder { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfigurationRoot Configuration { get; }

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