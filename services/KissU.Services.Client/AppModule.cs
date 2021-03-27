using KissU.Dependency;
using KissU.Modularity;
using Volo.Abp;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace KissU.Services.Client
{
    [DependsOn(typeof(AbpHttpClientIdentityModelModule))]
    public class AppModule : AbpModule, IBusinessModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var appService = ServiceLocator.GetService<AppService>();
            AsyncHelper.RunSync(() => appService.RunAsync());
        }
    }
}
