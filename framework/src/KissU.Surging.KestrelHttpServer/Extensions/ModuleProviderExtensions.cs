using System;
using KissU.Modularity;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Surging.KestrelHttpServer.Extensions
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
                        p.Configure(app);
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
        public static void ConfigureServices(this IModuleProvider moduleProvider, ServiceConfigurationContext context)
        {
            moduleProvider.Modules.ForEach(p =>
            {
                try
                {
                    if (p.Enable)
                    {
                        p.ConfigureServices(context);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
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
                try
                {
                    if (p.Enable)
                    {
                        var module = p as KestrelHttpModule;
                        module?.ConfigureWebHost(context);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
    }
}