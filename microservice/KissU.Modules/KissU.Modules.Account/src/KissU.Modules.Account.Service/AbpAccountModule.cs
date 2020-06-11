﻿using KissU.Abp.Autofac;
using KissU.Modules.Account.Application;
using KissU.Modules.Account.Application.Contracts.Localization;
using KissU.Modules.Identity.AspNetCore;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(AbpIdentityAspNetCoreModule),
        typeof(AbpAccountApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
        )]
    public class AbpAccountModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}