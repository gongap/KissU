using KissU.Modularity;
using KissU.Modules.Account.Application;
using KissU.Modules.Account.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(AccountServiceContractsModule),
        typeof(AccountApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AccountServiceModule : AbpModule, IBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<AbpIdentitySettingDefinitionProvider>();
            });

            context.Services.AddAutoMapperObjectMapper<AccountServiceModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AccountServiceAutomapperProfile>(true);
            });

            context.Services.GetObject<IdentityBuilder>().AddDefaultTokenProviders();
        }
    }
}