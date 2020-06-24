using KissU.Modules.TenantManagement.Application.Contracts;
using KissU.Modules.TenantManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.Application
{
    [DependsOn(typeof(AbpTenantManagementDomainModule))]
    [DependsOn(typeof(AbpTenantManagementApplicationContractsModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class AbpTenantManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpTenantManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpTenantManagementApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}