using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// Api资源查询服务
    /// </summary>
    public class QueryApiResourceService : IQueryApiResourceService
    {
        private readonly IQueryApiResourceAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        public QueryApiResourceService(IQueryApiResourceAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<ApiResourceDto> GetByIdAsync(string id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<ApiResourceDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<ApiResourceDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<ApiResourceDto>> QueryAsync(ResourceQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<ApiResourceDto>> PagerQueryAsync(ResourceQuery parameter)
        {
            return await _appService.PagerQueryAsync(parameter);
        }

        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="uri">资源标识列表</param>
        public async Task<List<ApiResourceDto>> GetResources(List<string> uri)
        {
            return await _appService.GetResources(uri);
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="uri">资源标识</param>
        public async Task<ApiResourceDto> GetResource(string uri)
        {
            return await _appService.GetResource(uri);
        }
    }
}