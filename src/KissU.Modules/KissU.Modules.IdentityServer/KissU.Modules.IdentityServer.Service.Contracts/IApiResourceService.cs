using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.IdentityServer.Service.Contracts
{
    /// <summary>
    /// 资源服务
    /// </summary>
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IApiResourceService : IServiceKey
    {
        #region 资源

        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;ApiResourceDto&gt;.</returns>
        [ServiceRoute("{id}")]
        [HttpGet(true)]
        Task<ApiResourceDto> GetByIdAsync(int id);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;ApiResourceDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ApiResourceDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;ApiResourceDto&gt;&gt;.</returns>
        [HttpPost(true)]
        Task<List<ApiResourceDto>> QueryAsync(ApiResourceQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;ApiResourceDto&gt;&gt;.</returns>
        [HttpPost(true)]
        Task<PagerList<ApiResourceDto>> PagerQueryAsync(ApiResourceQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        [HttpPost(true)]
        Task<string> CreateAsync([Valid] ApiResourceCreateRequest request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>Task.</returns>
        [HttpPut(true)]
        Task UpdateAsync([Valid] ApiResourceDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        [HttpDelete(true)]
        Task DeleteAsync(string ids);

        #endregion

        #region 许可范围

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns>Task&lt;List&lt;ApiScopeDto&gt;&gt;.</returns>
        [ServiceRoute("{id}")]
        [HttpGet(true)]
        Task<List<ApiScopeDto>> GetScopesAsync(string id);

        /// <summary>
        /// 获取许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns>Task&lt;ApiScopeDto&gt;.</returns>
        [ServiceRoute("{scopeId}")]
        [HttpGet(true)]
        Task<ApiScopeDto> GetScopeAsync(string scopeId);

        /// <summary>
        /// 创建许可范围
        /// </summary>
        /// <param name="request">创建许可范围参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPost(true)]
        Task<int> CreateScopeAsync([Valid] ApiScopeCreateRequest request);

        /// <summary>
        /// 更新许可范围
        /// </summary>
        /// <param name="request">许可范围</param>
        /// <returns>Task.</returns>
        [HttpPut(true)]
        Task UpdateScopeAsync([Valid] ApiScopeDto request);

        /// <summary>
        /// 删除许可范围
        /// </summary>
        /// <param name="scopeId">许可范围编号</param>
        /// <returns>Task.</returns>
        [ServiceRoute("{scopeId}")]
        [HttpDelete(true)]
        Task DeleteScopeAsync(string scopeId);

        #endregion

        #region 密钥

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="id">资源编号</param>
        /// <returns>Task&lt;List&lt;ApiSecretDto&gt;&gt;.</returns>
        [ServiceRoute("{id}")]
        [HttpGet(true)]
        Task<List<ApiSecretDto>> GetSecretsAsync(string id);

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns>Task&lt;ApiSecretDto&gt;.</returns>
        [ServiceRoute("{secretId}")]
        [HttpGet(true)]
        Task<ApiSecretDto> GetSecretAsync(string secretId);

        /// <summary>
        /// 创建密钥
        /// </summary>
        /// <param name="request">创建密钥参数</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPost(true)]
        Task<int> CreateSecretAsync([Valid] ApiSecretCreateRequest request);

        /// <summary>
        /// 删除密钥
        /// </summary>
        /// <param name="secretId">密钥编号</param>
        /// <returns>Task.</returns>
        [ServiceRoute("{secretId}")]
        [HttpDelete(true)]
        Task DeleteSecretAsync(string secretId);

        #endregion
    }
}