using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Datas;
using KissU.Core.Ioc;
using KissU.Core.Validations.Aspects;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.IdentityServer.Service.Contracts
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IClientService : IServiceKey
    {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;ClientDto&gt;.</returns>
        [HttpGet(true)]
        Task<ClientDto> GetByIdAsync(int id);

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;ClientDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ClientDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;ClientDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ClientDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;ClientDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ClientDto>> QueryAsync(ClientQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;ClientDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<PagerList<ClientDto>> PagerQueryAsync(ClientQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        [HttpPost(true)]
        Task<string> CreateAsync([Valid] ClientCreateRequest request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>Task.</returns>
        [HttpPut(true)]
        Task UpdateAsync([Valid] ClientDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        /// 克隆应用程序
        /// </summary>
        /// <param name="request">克隆请求参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> CloneAsync(ClientCloneRequest request);

        /// <summary>
        /// 通过编码查找
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
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
        Task<int> CreateClaimAsync(int clientId, [Valid] ClientClaimCreateRequest request);

        /// <summary>
        /// 更新应用程序声明
        /// </summary>
        /// <param name="clientId">应用标识</param>
        /// <param name="dto">应用程序声明</param>
        /// <returns>Task.</returns>
        Task UpdateClaimAsync(int clientId, [Valid] ClientClaimDto dto);

        /// <summary>
        /// 删除应用程序声明
        /// </summary>
        /// <param name="id">应用程序声明编号</param>
        /// <returns>Task.</returns>
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
        Task<int> CreateSecretAsync(int clientId, [Valid] ClientSecretCreateRequest request);

        /// <summary>
        /// 删除应用程序密钥
        /// </summary>
        /// <param name="id">应用程序密钥编号</param>
        /// <returns>Task.</returns>
        Task DeleteSecretAsync(int id);

        #endregion
    }
}