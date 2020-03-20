using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Domains.Repositories;
using KissU.Core.Validations.Aspects;
using KissU.Modules.IdentityServer.Domain.Models;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IClientRepository : IRepository<Client, int>
    {
        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientId">应用编号</param>
        /// <returns>Task&lt;Client&gt;.</returns>
        Task<Client> FindEnabledClientByIdAsync(string clientId);

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns>Task&lt;List&lt;ClientClaim&gt;&gt;.</returns>
        Task<List<ClientClaim>> GetClientClaimsAsync(int clientId);

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns>Task&lt;ClientClaim&gt;.</returns>
        Task<ClientClaim> GetClientClaimAsync(int id);

        /// <summary>
        /// 创建应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        /// <returns>Task.</returns>
        Task CreateClientClaimAsync([Valid] ClientClaim entity);

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="entity">应用程序声明</param>
        /// <returns>Task.</returns>
        Task UpdateClientClaimAsync([Valid] ClientClaim entity);

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明</param>
        /// <returns>Task.</returns>
        Task DeleteClientClaimAsync(int id);

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns>Task&lt;List&lt;ClientSecret&gt;&gt;.</returns>
        Task<List<ClientSecret>> GetClientSecretsAsync(int clientId);

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns>Task&lt;ClientSecret&gt;.</returns>
        Task<ClientSecret> GetClientSecretAsync(int id);

        /// <summary>
        /// 创建应用程序密钥
        /// </summary>
        /// <param name="entity">应用程序密钥</param>
        /// <returns>Task.</returns>
        Task CreateClientSecretAsync([Valid] ClientSecret entity);

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥</param>
        /// <returns>Task.</returns>
        Task DeleteClientSecretAsync(int id);

        #endregion
    }
}