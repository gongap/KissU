using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace KissU.Modules.TenantManagement.DbMigrator.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See IdentityDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    [ConnectionStringName(AbpTenantManagementDbProperties.ConnectionStringName)]
    public class MigrationsDbContext : AbpDbContext<MigrationsDbContext>
    {
        public MigrationsDbContext(DbContextOptions<MigrationsDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside the ConfigureIdentity method */

            builder.ConfigureTenantManagement();
        }
    }
}