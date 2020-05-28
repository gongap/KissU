using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Volo.Abp.Identity
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpIdentityApplicationContractsModule), 
        typeof(AbpAutoMapperModule)
        )]
    public class AbpIdentityApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpIdentityApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpIdentityApplicationModuleAutoMapperProfile>(validate: true);
            });
        }
    }
}