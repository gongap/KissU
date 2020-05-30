using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.PermissionManagement.EntityFrameworkCore
{
    [ConnectionStringName(AbpPermissionManagementDbProperties.ConnectionStringName)]
    public interface IPermissionManagementDbContext : IEfCoreDbContext
    {
        DbSet<PermissionGrant> PermissionGrants { get; set; }
    }
}