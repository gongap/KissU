using KissU.Modules.SettingManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.SettingManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class AbpSettingManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SettingManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<ISettingManagementDbContext>();

                options.AddRepository<Setting, EfCoreSettingRepository>();
            });
        }
    }
}
