using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.IdentityServer.Application.Contracts.Abstractions
{
    /// <summary>
    /// 认证操作数据服务
    /// </summary>
    public interface IPersistedGrantAppService : IDeleteService<PersistedGrantDto, PersistedGrantQuery>
    {
    }
}