﻿using KissU.Abp.Autofac;
using KissU.Modules.SettingManagement.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.SettingManagement.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}