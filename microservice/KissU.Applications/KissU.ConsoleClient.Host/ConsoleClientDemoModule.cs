using KissU.Abp;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace KissU.ConsoleClient.Host
{
    [DependsOn(
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ConsoleClientDemoModule : Volo.Abp.Modularity.AbpModule, IAbpServiceModule
    {
    }
}
