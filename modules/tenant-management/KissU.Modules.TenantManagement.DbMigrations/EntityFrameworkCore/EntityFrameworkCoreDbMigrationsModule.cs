using KissU.Modules.TenantManagement.DbMigrations.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace KissU.Modules.TenantManagement.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpTenantManagementEntityFrameworkCoreModule)
    )]
    public class EntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MigrationsDbContext>();
            context.Services.Replace(ServiceDescriptor.Singleton<IDbSchemaMigrator, EntityFrameworkCoreDbSchemaMigrator>());

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}