using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(BloggingEntityFrameworkCoreModule)
    )]
    public class EntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MigrationsDbContext>();

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}