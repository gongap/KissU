using KissU.Modules.AuditLogging.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.FeatureManagement.EntityFrameworkCore;
using KissU.Modules.Identity.EntityFrameworkCore;
using KissU.Modules.IdentityServer.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.PermissionManagement.EntityFrameworkCore;
using KissU.Modules.SettingManagement.EntityFrameworkCore;
using KissU.Modules.TenantManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.AuthServer.Host.EntityFrameworkCore
{
    public class AuthServerDbContext : AbpDbContext<AuthServerDbContext>
    {
        public AuthServerDbContext(DbContextOptions<AuthServerDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureIdentity();
            modelBuilder.ConfigureIdentityServer();
            modelBuilder.ConfigureAuditLogging();
            modelBuilder.ConfigurePermissionManagement();
            modelBuilder.ConfigureSettingManagement();
            modelBuilder.ConfigureTenantManagement();
            modelBuilder.ConfigureFeatureManagement();
        }
    }
}
