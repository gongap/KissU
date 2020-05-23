using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace KissU.Modules.Identity.DbMigrations.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See IdentityDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class IdentityMigrationsDbContext : AbpDbContext<IdentityMigrationsDbContext>
    {
        public IdentityMigrationsDbContext(DbContextOptions<IdentityMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside the ConfigureIdentity method */

            builder.ConfigureIdentity();
        }
    }
}