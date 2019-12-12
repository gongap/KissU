using System;
using KissU.Core.CPlatform.Module;

namespace KissU.Core.KestrelHttpServer.Extensions
{
   public static  class ModuleProviderExtensions
    {
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
