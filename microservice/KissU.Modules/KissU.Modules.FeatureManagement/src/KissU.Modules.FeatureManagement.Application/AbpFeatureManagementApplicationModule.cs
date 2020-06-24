using KissU.Modules.FeatureManagement.Application.Contracts;
using KissU.Modules.FeatureManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace KissU.Modules.FeatureManagement.Application
{
    [DependsOn(
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpFeatureManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpFeatureManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<FeatureManagementApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
