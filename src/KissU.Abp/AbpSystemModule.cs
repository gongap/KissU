using Autofac; 
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Modularity.PlugIns;
using KissU.CPlatform;
using KissU.CPlatform.Engines.Implementation;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery;
using KissU.Dependency;
using KissU.Exceptions.Handling;
using KissU.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using KissUtil.Helpers;

namespace KissU.Abp
{
    public class AbpSystemModule : SystemModule
    {
        public override void Initialize(ModuleInitializationContext context)
        {
            base.Initialize(context);
            var serviceProvider = context.ServiceProvoider.GetInstances<IServiceProvider>();
            context.ServiceProvoider.GetInstances<IAbpApplicationWithExternalServiceProvider>().Initialize(serviceProvider);
        }

        public override void ConfigureServices(ServiceCollectionWrapper context)
        {
            context.Services.AddApplication<AbpStartupModule>(options =>
            {
                var modulePaths = DefaultServiceEngineBuilder.GetPaths(DefaultServiceEngineBuilder.ModuleServiceLocationFormat) ?? new string[] { };
                var paths = new[] { AppContext.BaseDirectory }.Concat(modulePaths).ToArray();
                var assemblies = ModuleHelper.GetAssemblies(paths);
                var businessModules = ReflectionHelper.FindTypes<IBusinessModule>(assemblies.ToArray());
                var startupModules = ReflectionHelper.FindTypes<AbpModule>(assemblies.ToArray());
                var moduleTypes = businessModules.Concat(startupModules).Distinct();
                options.PlugInSources.AddTypes(moduleTypes.ToArray());
            });
        }

        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            builder.RegisterType(typeof(AbpExceptionToErrorInfoConverter)).AsImplementedInterfaces().Named("Abp", typeof(IExceptionToErrorInfoConverter)).SingleInstance();
            var modulePaths = DefaultServiceEngineBuilder.GetPaths(DefaultServiceEngineBuilder.ModuleServiceLocationFormat) ?? new string[] { };
            var paths = new[] { AppContext.BaseDirectory }.Concat(modulePaths).ToArray();
            var assemblies = ModuleHelper.GetAssemblies(paths);
            var types = assemblies.SelectMany(i => i.ExportedTypes).ToArray();
            builder.Register(provider => new AbpAppServiceEntryProvider(types, provider.Resolve<IClrServiceEntryFactory>(), provider.Resolve<CPlatformContainer>())).As<IServiceEntryProvider>().SingleInstance();
            builder.Register(provider => new AbpInternalServiceEntryProvider(types, provider.Resolve<IClrServiceEntryFactory>(), provider.Resolve<CPlatformContainer>())).As<IServiceEntryProvider>().SingleInstance();
            builder.Register(provider => new AbpRemoteServiceEntryProvider(types, provider.Resolve<IClrServiceEntryFactory>(), provider.Resolve<CPlatformContainer>())).As<IServiceEntryProvider>().SingleInstance();

            var section = CPlatform.AppConfig.GetSection("Abp");
            AppConfig.Options = section.Exists() ? section.Get<AbpOption>() : new AbpOption();
        }
    }
}
