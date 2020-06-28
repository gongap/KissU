using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace KissU.ConsoleClient.Host
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpHttpClientIdentityModelModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule)
        )]
    public class ConsoleClientDemoModule : AbpModule
    {
         
    }
}
