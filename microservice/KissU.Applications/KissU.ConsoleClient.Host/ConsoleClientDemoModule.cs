using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace KissU.ConsoleClient.Host
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ConsoleClientDemoModule : AbpModule
    {
         
    }
}
