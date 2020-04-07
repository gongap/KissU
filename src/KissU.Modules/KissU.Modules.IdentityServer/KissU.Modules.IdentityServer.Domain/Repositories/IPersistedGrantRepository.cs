using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Ddd.Domain.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 认证操作数据仓储
    /// </summary>
    public interface IPersistedGrantRepository : IRepository<PersistedGrant, int>
    {
    }
}