using KissU.Dependency;
using KissU.Modularity;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Volo.Abp.Http.Client.IdentityModel;

namespace KissU.ServiceClient
{
    [DependsOn(typeof(AbpHttpClientIdentityModelModule))]
    public class AppModule : AbpModule, IBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var appService = ServiceLocator.GetService<AppService>();
            AsyncHelper.RunSync(() => appService.RunAsync());
        }
    }
}