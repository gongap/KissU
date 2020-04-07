using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Util.Ddd.Application.Contracts;

namespace KissU.Modules.IdentityServer.Application.Contracts.Abstractions
{
    /// <summary>
    /// 身份资源服务
    /// </summary>
    public interface IIdentityResourceAppService : ICrudService<IdentityResourceDto, IdentityResourceDto,
        IdentityResourceCreateRequest, IdentityResourceDto, IdentityResourceQuery>
    {
    }
}