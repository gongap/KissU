using KissU.Modules.IdentityServer.Domain.Shared;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement.Domain.IdentityServer
{
    [DependsOn(
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainModule)
    )]
    public class AbpPermissionManagementDomainIdentityServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionManagementOptions>(options =>
            {
                options.ManagementProviders.Add<ClientPermissionManagementProvider>();

                options.ProviderPolicies[ClientPermissionValueProvider.ProviderName] = "IdentityServer.Client.ManagePermissions";
            });
        }
    }
}
