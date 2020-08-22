using KissU.Modules.BackgroundJobs.DbMigrations.Data;
using KissU.Modules.BackgroundJobs.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.BackgroundJobs.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpBackgroundJobsEntityFrameworkCoreModule)
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