using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Validations.Aspects;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Util.Ddd.Application.Contracts;
using KissU.Util.Ddd.Application.Contracts.Aspects;

namespace KissU.Modules.IdentityServer.Application.Contracts.Abstractions
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
        /// <returns>Task&lt;List&lt;ApiScopeDto&gt;&gt;.</returns>
        Task<List<ApiScopeDto>> GetApiScopesAsync(int apiResourceId);

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns>Task&lt;ApiScopeDto&gt;.</returns>
        Task<ApiScopeDto> GetApiScopeAsync(int id);

        /// <summary>
        /// 创建Api许可范围
        /// </summary>
        /// <param name="request">创建Api许可范围参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [UnitOfWork]
        Task<int> CreateApiScopeAsync([Valid] ApiScopeCreateRequest request);

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="dto">Api许可范围</param>
        /// <returns>Task.</returns>
        [UnitOfWork]
        Task UpdateApiScopeAsync([Valid] ApiScopeDto dto);

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns>Task.</returns>
        [UnitOfWork]
        Task DeleteApiScopeAsync(int id);

        #endregion

        #region Api密钥

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns>Task&lt;List&lt;ApiSecretDto&gt;&gt;.</returns>
        Task<List<ApiSecretDto>> GetApiSecretsAsync(int apiResourceId);

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns>Task&lt;ApiSecretDto&gt;.</returns>
        Task<ApiSecretDto> GetApiSecretAsync(int id);

        /// <summary>
        /// 创建Api密钥
        /// </summary>
        /// <param name="request">创建Api密钥参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [UnitOfWork]
        Task<int> CreateApiSecretAsync([Valid] ApiSecretCreateRequest request);

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns>Task.</returns>
        [UnitOfWork]
        Task DeleteApiSecretAsync(int id);

        #endregion
    }
}