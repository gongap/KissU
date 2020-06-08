using KissU.Modules.TenantManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.EntityFrameworkCore
{
    [DependsOn(typeof(AbpTenantManagementDomainModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class AbpTenantManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TenantManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<ITenantManagementDbContext>();
            });
        }
    }
}
