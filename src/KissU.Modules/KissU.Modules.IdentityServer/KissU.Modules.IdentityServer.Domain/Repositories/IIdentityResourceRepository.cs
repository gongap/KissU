using KissU.Core.Domains.Repositories;
using KissU.Modules.IdentityServer.Domain.Models;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public interface IIdentityResourceRepository : IRepository<IdentityResource, int>
    {
    }
}