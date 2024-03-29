using System;
using KissU.AspNetCore.Internal;
using KissU.Modularity;

namespace KissU.AspNetCore.Extensions
{
    /// <summary>
    /// ModuleProviderExtensions.
    /// </summary>
    public static class ModuleProviderExtensions
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="moduleProvider">The module provider.</param>
        /// <param name="app">The applicationInitializationContext.</param>
        public static void Configure(this IModuleProvider moduleProvider, ApplicationInitializationContext app)
        {
            moduleProvider.Modules.ForEach(p =>
            {
                try
                {
                    if (p.Enable)
                    {
                        var module = p as AspNetCoreModule;
                        module?.Configure(app);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="moduleProvider">The module provider.</param>
        /// <param name="context">The context.</param>
        public static void ConfigureServices(this IModuleProvider moduleProvider, ServiceCollectionWrapper context)
        {
            moduleProvider.Modules.ForEach(p =>
            {
                if (p.Enable)
                {
                    var module = p as AspNetCoreModule;
                    module?.ConfigureServices(context);
                }
            });
        }

        /// <summary>
        /// Configures the host.
        /// </summary>
        /// <param name="moduleProvider">The module provider.</param>
        /// <param name="context">The context.</param>
        public static void ConfigureHost(this IModuleProvider moduleProvider, WebHostContext context)
        {
            moduleProvider.Modules.ForEach(p =>
            {
                if (p.Enable)
                {
                    var module = p as AspNetCoreModule;
                    module?.ConfigureWebHost(context);
                }
            });
        }
    }
}
