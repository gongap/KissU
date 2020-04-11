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
    /// 应用程序服务
    /// </summary>
    public interface IClientAppService : ICrudService<ClientDto, ClientDto, ClientCreateRequest, ClientDto, ClientQuery>
    {
        /// <summary>
        /// 克隆应用程序
        /// </summary>
        /// <param name="request">克隆请求参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [UnitOfWork]
        Task<int> CloneAsync(ClientCloneRequest request);

        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientId">应用编码</param>
        /// <returns>Task&lt;ClientDto&gt;.</returns>
        Task<ClientDto> FindEnabledByIdAsync(string clientId);

        #region 应用程序声明

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns>Task&lt;List&lt;ClientClaimDto&gt;&gt;.</returns>
        Task<List<ClientClaimDto>> GetClaimsAsync(int clientId);

        /// <summary>
        /// 获取应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns>Task&lt;ClientClaimDto&gt;.</returns>
        Task<ClientClaimDto> GetClaimAsync(int id);

        /// <summary>
        /// 创建应用程序声明
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="request">创建应用程序声明参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [UnitOfWork]
        Task<int> CreateClaimAsync(int clientId, [Valid] ClientClaimCreateRequest request);

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="dto">应用程序声明</param>
        /// <returns>Task.</returns>
        [UnitOfWork]
        Task UpdateClaimAsync(int clientId, [Valid] ClientClaimDto dto);

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns>Task.</returns>
        [UnitOfWork]
        Task DeleteClaimAsync(int id);

        #endregion

        #region 应用程序密钥

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="clientId">应用程序编号</param>
        /// <returns>Task&lt;List&lt;ClientSecretDto&gt;&gt;.</returns>
        Task<List<ClientSecretDto>> GetSecretsAsync(int clientId);

        /// <summary>
        /// 获取应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns>Task&lt;ClientSecretDto&gt;.</returns>
        Task<ClientSecretDto> GetSecretAsync(int id);

        /// <summary>
        /// 创建应用程序密钥
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="request">创建应用程序密钥参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [UnitOfWork]
        Task<int> CreateSecretAsync(int clientId, [Valid] ClientSecretCreateRequest request);

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns>Task.</returns>
        [UnitOfWork]
        Task DeleteSecretAsync(int id);

        #endregion
    }
}