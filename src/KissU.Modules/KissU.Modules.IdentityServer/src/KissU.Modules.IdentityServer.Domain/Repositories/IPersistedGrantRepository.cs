using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;
using Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 认证操作数据仓储
    /// </summary>
    public interface IPersistedGrantRepository : IRepository<PersistedGrant>
    {
    }
}