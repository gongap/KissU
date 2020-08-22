using KissU.Modules.AuditLogging.DbMigrations.Data;
using KissU.Modules.AuditLogging.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.AuditLogging.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpAuditLoggingEntityFrameworkCoreModule)
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