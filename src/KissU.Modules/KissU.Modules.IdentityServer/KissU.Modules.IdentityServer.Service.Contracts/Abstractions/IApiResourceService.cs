// <copyright file="IApiResourceService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests;
using KissU.Modules.IdentityServer.Service.Contracts.Queries;
using KissU.Util.Applications;
using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.IdentityServer.Service.Contracts.Abstractions
{
    /// <summary>
    /// 资源服务
    /// </summary>
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IApiResourceService : IService
    {
        #region 资源

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [ServiceRoute("{id}")]
        [HttpGet(true)]
        Task<ApiResourceDto> GetByIdAsync(string id);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<ApiResourceDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpPost(true)]
        Task<List<ApiResourceDto>> QueryAsync(ApiResourceQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpPost(true)]
        Task<PagerList<ApiResourceDto>> PagerQueryAsync(ApiResourceQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost(true)]
        Task<string> CreateAsync([Valid] ApiResourceCreateRequest request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [HttpPut(true)]
        Task UpdateAsync([Valid] ApiResourceDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpDelete(true)]
        Task DeleteAsync(string ids);

        #endregion

        #region 许可范围

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns></returns>
        [ServiceRoute("{id}")]
        [HttpGet(true)]
        Task<List<ApiResourceScopeDto>> GetScopesAsync(string id);

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns></returns>
        [ServiceRoute("{scopeId}")]
        [HttpGet(true)]
        Task<ApiResourceScopeDto> GetScopeAsync(string scopeId);

        /// <summary>
        /// 创建许可范围
        /// </summary>
        /// <param name="request">创建许可范围参数</param>
        /// <returns></returns>
        [HttpPost(true)]
        Task<Guid> CreateScopeAsync([Valid] ApiResourceScopeCreateRequest request);

        /// <summary>
        /// 更新许可范围
        /// </summary>
        /// <param name="request">许可范围</param>
        /// <returns></returns>
        [HttpPut(true)]
        Task UpdateScopeAsync([Valid] ApiResourceScopeDto request);

        /// <summary>
        /// 删除许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns></returns>
        [ServiceRoute("{scopeId}")]
        [HttpDelete(true)]
        Task DeleteScopeAsync(string scopeId);

        #endregion

        #region 密钥

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns></returns>
        [ServiceRoute("{id}")]
        [HttpGet(true)]
        Task<List<ApiResourceSecretDto>> GetSecretsAsync(string id);

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns></returns>
        [ServiceRoute("{secretId}")]
        [HttpGet(true)]
        Task<ApiResourceSecretDto> GetSecretAsync(string secretId);

        /// <summary>
        /// 创建密钥
        /// </summary>
        /// <param name="request">创建密钥参数</param>
        /// <returns></returns>
        [HttpPost(true)]
        Task<Guid> CreateSecretAsync([Valid] ApiResourceSecretCreateRequest request);

        /// <summary>
        /// 删除密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns></returns>
        [ServiceRoute("{secretId}")]
        [HttpDelete(true)]
        Task DeleteSecretAsync(string secretId);

        #endregion
    }
}
