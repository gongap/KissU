using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// API资源仓储
    /// </summary>
    public interface IApiResourceRepository : IRepository<ApiResource, int>
    {
        #region Api许可范围

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns>Task&lt;List&lt;ApiScope&gt;&gt;.</returns>
        Task<List<ApiScope>> GetApiResourceScopesAsync(int apiResourceId);

        /// <summary>
        /// 获取Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns>Task&lt;ApiScope&gt;.</returns>
        Task<ApiScope> GetApiResourceScopeAsync(int id);

        /// <summary>
        /// 创建Api许可范围
        /// </summary>
        /// <param name="entity">api许可范围</param>
        /// <returns>Task.</returns>
        Task CreateApiResourceScopeAsync([Valid] ApiScope entity);

        /// <summary>
        /// 更新Api许可范围
        /// </summary>
        /// <param name="entity">api许可范围</param>
        /// <returns>Task.</returns>
        Task UpdateApiResourceScopeAsync([Valid] ApiScope entity);

        /// <summary>
        /// 删除Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        /// <returns>Task.</returns>
        Task DeleteApiResourceScopeAsync(int id);

        #endregion

        #region Api密钥

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="apiResourceId">Api资源编号</param>
        /// <returns>Task&lt;List&lt;ApiSecret&gt;&gt;.</returns>
        Task<List<ApiSecret>> GetApiResourceSecretsAsync(int apiResourceId);

        /// <summary>
        /// 获取Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns>Task&lt;ApiSecret&gt;.</returns>
        Task<ApiSecret> GetApiResourceSecretAsync(int id);

        /// <summary>
        /// 创建Api密钥
        /// </summary>
        /// <param name="entity">api密钥</param>
        /// <returns>Task.</returns>
        Task CreateApiResourceSecretAsync([Valid] ApiSecret entity);

        /// <summary>
        /// 删除Api密钥
        /// </summary>
        /// <param name="id">Api密钥编号</param>
        /// <returns>Task.</returns>
        Task DeleteApiResourceSecretAsync(int id);

        #endregion
    }
}