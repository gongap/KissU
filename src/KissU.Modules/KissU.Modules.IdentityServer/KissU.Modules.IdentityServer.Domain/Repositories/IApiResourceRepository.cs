// <copyright file="IApiResourceRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain.Models;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// API资源仓储
    /// </summary>
    public interface IApiResourceRepository : IRepository<ApiResource>
    {
        #region Api许可范围

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        Task<List<ApiResourceScope>> GetApiResourceScopesAsync(Guid apiResourceId);

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        Task<ApiResourceScope> GetApiResourceScopeAsync(Guid id);

        /// <summary>
        /// 创建Api许可范围
        /// </summary>
        /// <param name="entity">api许可范围</param>
        /// <returns></returns>
        Task CreateApiResourceScopeAsync([Valid] ApiResourceScope entity);

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="entity">api许可范围</param>
        /// <returns></returns>
        Task UpdateApiResourceScopeAsync([Valid] ApiResourceScope entity);

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns></returns>
        Task DeleteApiResourceScopeAsync(Guid id);

        #endregion

        #region Api密钥

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns></returns>
        Task<List<ApiResourceSecret>> GetApiResourceSecretsAsync(Guid apiResourceId);

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        Task<ApiResourceSecret> GetApiResourceSecretAsync(Guid id);

        /// <summary>
        /// 创建Api密钥
        /// </summary>
        /// <param name="entity">api密钥</param>
        /// <returns></returns>
        Task CreateApiResourceSecretAsync([Valid] ApiResourceSecret entity);

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns></returns>
        Task DeleteApiResourceSecretAsync(Guid id);

        #endregion
    }
}
