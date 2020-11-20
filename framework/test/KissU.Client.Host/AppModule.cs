using KissU.Dependency;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace KissU.Client.Host
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpHttpClientIdentityModelModule))]
    public class AppModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var appService = ServiceLocator.GetService<AppService>();
            AsyncHelper.RunSync(() => appService.RunAsync());
        }
    }
}
