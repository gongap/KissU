using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Datas;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public class QueryApplicationService : ProxyServiceBase, IQueryApplicationService
    {
        private readonly IQueryApplicationAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public QueryApplicationService(IQueryApplicationAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;ApplicationDto&gt;.</returns>
        public async Task<ApplicationDto> GetByIdAsync(string id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;ApplicationDto&gt;&gt;.</returns>
        public async Task<List<ApplicationDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;ApplicationDto&gt;&gt;.</returns>
        public async Task<List<ApplicationDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;ApplicationDto&gt;&gt;.</returns>
        public async Task<List<ApplicationDto>> QueryAsync(ApplicationQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;ApplicationDto&gt;&gt;.</returns>
        public async Task<PagerList<ApplicationDto>> PagerQueryAsync(ApplicationQuery parameter)
        {
            return await _appService.PagerQueryAsync(parameter);
        }

        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        /// <returns>Task&lt;ApplicationDto&gt;.</returns>
        public async Task<ApplicationDto> GetByCodeAsync(string code)
        {
            return await _appService.GetByCodeAsync(code);
        }
    }
}