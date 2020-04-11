using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Datas;
using KissU.Core.Ioc;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IQueryModuleService : IServiceKey
    {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;ModuleDto&gt;.</returns>
        [HttpGet(true)]
        Task<ModuleDto> GetByIdAsync(string id);

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ModuleDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ModuleDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ModuleDto>> QueryAsync(ResourceQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;ModuleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<PagerList<ModuleDto>> PagerQueryAsync(ResourceQuery parameter);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        /// 通过标识查找列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<ModuleDto>> FindByIdsAsync(string ids);

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task EnableAsync(string ids);

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task DisableAsync(string ids);

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="swapId">目标标识</param>
        /// <returns>Task.</returns>
        [HttpGet(true)]
        Task SwapSortAsync(Guid id, Guid swapId);

        /// <summary>
        /// 修正排序
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task.</returns>
        [HttpGet(true)]
        Task FixSortIdAsync(ResourceQuery parameter);
    }
}