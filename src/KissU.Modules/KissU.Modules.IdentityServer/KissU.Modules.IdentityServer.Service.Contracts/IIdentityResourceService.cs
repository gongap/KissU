using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Applications.Aspects;
using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.IdentityServer.Service.Contracts
{
    /// <summary>
    /// 身份资源服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IIdentityResourceService : IServiceKey
    {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;IdentityResourceDto&gt;.</returns>
        [HttpGet(true)]
        Task<IdentityResourceDto> GetByIdAsync(int id);

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;IdentityResourceDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<IdentityResourceDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;IdentityResourceDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<IdentityResourceDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;IdentityResourceDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<IdentityResourceDto>> QueryAsync(IdentityResourceQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;IdentityResourceDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<PagerList<IdentityResourceDto>> PagerQueryAsync(IdentityResourceQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        [HttpPost(true)]
        Task<string> CreateAsync([Valid] IdentityResourceCreateRequest request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>Task.</returns>
        [HttpPut(true)]
        Task UpdateAsync([Valid] IdentityResourceDto request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task DeleteAsync(string ids);
    }
}