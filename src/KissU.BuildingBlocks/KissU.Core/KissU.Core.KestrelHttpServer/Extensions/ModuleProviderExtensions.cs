using System;
using KissU.Core.CPlatform.Module;

namespace KissU.Core.KestrelHttpServer.Extensions
{
    /// <summary>
    /// ModuleProviderExtensions.
    /// </summary>
    public static  class ModuleProviderExtensions
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="moduleProvider">The module provider.</param>
        /// <param name="builder">The builder.</param>
        public static void Initialize(this IModuleProvider moduleProvider, ApplicationInitializationContext builder)
        {
            moduleProvider.Modules.ForEach(p =>
            {
                try
                {
                    using (var abstractModule = p)
                        if (abstractModule.Enable)
                        {
                            var module = abstractModule as KestrelHttpModule;
                            module?.Initialize(builder);
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
        public static void ConfigureServices(this IModuleProvider moduleProvider, ConfigurationContext context)
        {
            moduleProvider.Modules.ForEach(p =>
            {
                try
                {
                    if (p.Enable)
                    {
                        var module = p as KestrelHttpModule;
                        module?.RegisterBuilder(context);
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
                        module?.RegisterBuilder(context);
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
