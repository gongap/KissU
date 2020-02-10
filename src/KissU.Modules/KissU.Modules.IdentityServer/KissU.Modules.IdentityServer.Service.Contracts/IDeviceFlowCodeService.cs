using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Applications;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Service.Contracts
{
    /// <summary>
    /// 认证操作数据服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IDeviceFlowCodeService : IService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;DeviceFlowCodeDto&gt;.</returns>
        [HttpGet(true)]
        Task<DeviceFlowCodeDto> GetByIdAsync(int id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<DeviceFlowCodeDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<DeviceFlowCodeDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<DeviceFlowCodeDto>> QueryAsync(DeviceFlowCodeQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;DeviceFlowCodeDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<PagerList<DeviceFlowCodeDto>> PagerQueryAsync(DeviceFlowCodeQuery parameter);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task DeleteAsync(string ids);
    }
}