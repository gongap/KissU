using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Applications;
using KissU.Util.Applications.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.IdentityServer.Application.Abstractions
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public interface IApiResourceAppService : ICrudService<ApiResourceDto, ApiResourceDto, ApiResourceCreateRequest,
        ApiResourceDto, ApiResourceQuery>
    {
        #region Api许可范围

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        Task<List<ApiScopeDto>> GetApiScopesAsync(Guid apiResourceId);

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        Task<ApiScopeDto> GetApiScopeAsync(Guid id);

        /// <summary>
        /// 创建Api许可范围
        /// </summary>
        /// <param name="request">创建Api许可范围参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<Guid> CreateApiScopeAsync([Valid] ApiScopeCreateRequest request);

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="dto">Api许可范围</param>
        /// <returns></returns>
        [UnitOfWork]
        Task UpdateApiScopeAsync([Valid] ApiScopeDto dto);

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteApiScopeAsync(Guid id);

        #endregion

        #region Api密钥

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        Task<List<ApiSecretDto>> GetApiSecretsAsync(Guid apiResourceId);

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        Task<ApiSecretDto> GetApiSecretAsync(Guid id);

        /// <summary>
        /// 创建Api密钥
        /// </summary>
        /// <param name="request">创建Api密钥参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<Guid> CreateApiSecretAsync([Valid] ApiSecretCreateRequest request);

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteApiSecretAsync(Guid id);

        #endregion
    }
}