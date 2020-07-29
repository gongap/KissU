﻿using KissU.Abp;
using KissU.Abp.Autofac;
using KissU.Abp.Business;
using KissU.Modules.Identity.Application;
using KissU.Modules.Identity.Domain;
using KissU.Modules.Identity.EntityFrameworkCore;
using KissU.Services.Identity.Contract;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.Identity.Service
{
    [DependsOn(typeof(IdentityServiceContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class IdentityServiceModule : AbpModule, IAbpStartupModule
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

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}