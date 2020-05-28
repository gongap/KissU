using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.TenantManagement.EntityFrameworkCore
{
    [ConnectionStringName(AbpTenantManagementDbProperties.ConnectionStringName)]
    public interface ITenantManagementDbContext : IEfCoreDbContext
    {
        DbSet<Tenant> Tenants { get; set; }

        DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    }
}