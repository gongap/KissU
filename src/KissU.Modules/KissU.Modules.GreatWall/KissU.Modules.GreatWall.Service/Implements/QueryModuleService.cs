using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public class QueryModuleService : ProxyServiceBase, IQueryModuleService
    {
        private readonly IQueryModuleAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public QueryModuleService(IQueryModuleAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;ModuleDto&gt;.</returns>
        public async Task<ModuleDto> GetByIdAsync(string id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        public async Task<List<ModuleDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        public async Task<List<ModuleDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        public async Task<List<ModuleDto>> QueryAsync(ResourceQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;ModuleDto&gt;&gt;.</returns>
        public async Task<PagerList<ModuleDto>> PagerQueryAsync(ResourceQuery parameter)
        {
            return await _appService.PagerQueryAsync(parameter);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
            await _appService.DeleteAsync(ids);
        }

        /// <summary>
        /// 通过标识查找列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <returns>Task&lt;List&lt;ModuleDto&gt;&gt;.</returns>
        public async Task<List<ModuleDto>> FindByIdsAsync(string ids)
        {
            return await _appService.FindByIdsAsync(ids);
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        public async Task EnableAsync(string ids)
        {
            await _appService.EnableAsync(ids);
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        public async Task DisableAsync(string ids)
        {
            await _appService.DisableAsync(ids);
        }

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="swapId">目标标识</param>
        public async Task SwapSortAsync(Guid id, Guid swapId)
        {
            await _appService.SwapSortAsync(id, swapId);
        }

        /// <summary>
        /// 修正排序
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task FixSortIdAsync(ResourceQuery parameter)
        {
            await _appService.FixSortIdAsync(parameter);
        }
    }
}