using KissU.Modules.FeatureManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.FeatureManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AbpFeatureManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<FeatureManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<IFeatureManagementDbContext>();

                options.AddRepository<FeatureValue, EfCoreFeatureValueRepository>();
            });
        }
    }
}