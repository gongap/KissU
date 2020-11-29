using KissU.Modularity;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.Application
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpIdentityApplicationContractsModule), 
        typeof(AbpAutoMapperModule)
        )]
    public class AbpIdentityApplicationModule : AbpBusunessModule
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