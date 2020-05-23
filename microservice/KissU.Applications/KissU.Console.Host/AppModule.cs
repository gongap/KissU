using Autofac;
using KissU.Abp.Autofac;
using KissU.Core.Dependency;
using KissU.Surging.Caching;
using KissU.Surging.CPlatform;
using KissU.Surging.ProxyGenerator;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Console.Host
{
    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class AppModule : AbpModule
    {


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           var builder = context.Services.GetObject<ContainerBuilder>();
           builder.AddMicroService(service => { service.AddClient().AddCache(); });
           builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }
    }
}