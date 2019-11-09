using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.IModuleServices.IdentityServer.Commands;
using KissU.IModuleServices.IdentityServer.Dtos;
using KissU.IModuleServices.IdentityServer.Queries;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Util.Applications;
using Util.Applications.Aspects;
using Util.Domains.Repositories;
using Util.Validations.Aspects;

namespace KissU.IModuleServices.IdentityServer.Abstractions
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IApiResourceService : IService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<ApiResourceDto> GetByIdAsync(object id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<ApiResourceDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<ApiResourceDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<ApiResourceDto>> QueryAsync(ApiResourceQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<ApiResourceDto>> PagerQueryAsync(ApiResourceQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost(true)]
        [UnitOfWork]
        Task<string> CreateAsync([Valid] ApiResourceCreateRequest request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut(true)]
        [UnitOfWork]
        Task UpdateAsync([Valid] ApiResourceDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        #region Api许可范围
        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        Task<List<ApiResourceScopeDto>> GetApiResourceScopesAsync(Guid apiResourceId);

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        Task<ApiResourceScopeDto> GetApiResourceScopeAsync(Guid id);

        /// <summary>
        /// 创建Api许可范围
        /// </summary>
        /// <param name="request">创建Api许可范围参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<Guid> CreateApiResourceScopeAsync([Valid] ApiResourceScopeCreateRequest request);

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="dto">Api许可范围</param>
        /// <returns></returns>
        [UnitOfWork]
        Task UpdateApiResourceScopeAsync([Valid] ApiResourceScopeDto dto);

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteApiResourceScopeAsync(Guid id);
        #endregion

        #region Api密钥
        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        Task<List<ApiResourceSecretDto>> GetApiResourceSecretsAsync(Guid apiResourceId);

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        Task<ApiResourceSecretDto> GetApiResourceSecretAsync(Guid id);

        /// <summary>
        /// 创建Api密钥
        /// </summary>
        /// <param name="request">创建Api密钥参数</param>
        /// <returns></returns>
        [UnitOfWork]
        Task<Guid> CreateApiResourceSecretAsync([Valid] ApiResourceSecretCreateRequest request);

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        [UnitOfWork]
        Task DeleteApiResourceSecretAsync(Guid id);
        #endregion
    }
}
