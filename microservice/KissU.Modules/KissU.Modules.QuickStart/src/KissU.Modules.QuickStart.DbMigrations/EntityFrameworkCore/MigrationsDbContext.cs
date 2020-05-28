using KissU.Modules.QuickStart.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See QuickStartDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class MigrationsDbContext : AbpDbContext<MigrationsDbContext>
    {
        public MigrationsDbContext(DbContextOptions<MigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside the ConfigureQuickStart method */

            builder.ConfigureQuickStart();
        }
    }
}