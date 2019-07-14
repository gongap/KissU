using Util.Domains.Repositories;
using KissU.Modules.QuickStart.Domain.Models;

namespace KissU.Modules.QuickStart.Domain.Repositories {
    /// <summary>
    /// 租户仓储
    /// </summary>
    public interface ITenantRepository : IRepository<Tenant> {
    }
}