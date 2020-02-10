using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Application.Abstractions;
using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Modules.IdentityServer.Service.Contracts;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class IdentityResourceService : IIdentityResourceService
    {
        private readonly IIdentityResourceAppService _appService;

        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="appService">应用服务</param>
        public IdentityResourceService(IIdentityResourceAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;IdentityResourceDto&gt;.</returns>
        public async Task<IdentityResourceDto> GetByIdAsync(int id)
        {
            return await _appService.GetByIdAsync(id);
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;IdentityResourceDto&gt;&gt;.</returns>
        public async Task<List<IdentityResourceDto>> GetByIdsAsync(string ids)
        {
            return await _appService.GetByIdsAsync(ids);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;IdentityResourceDto&gt;&gt;.</returns>
        public async Task<List<IdentityResourceDto>> GetAllAsync()
        {
            return await _appService.GetAllAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;IdentityResourceDto&gt;&gt;.</returns>
        public async Task<List<IdentityResourceDto>> QueryAsync(IdentityResourceQuery parameter)
        {
            return await _appService.QueryAsync(parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;IdentityResourceDto&gt;&gt;.</returns>
        public async Task<PagerList<IdentityResourceDto>> PagerQueryAsync(IdentityResourceQuery parameter)
        {
            return await _appService.PagerQueryAsync(parameter);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> CreateAsync(IdentityResourceCreateRequest request)
        {
            return await _appService.CreateAsync(request);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public async Task UpdateAsync(IdentityResourceDto request)
        {
            await _appService.UpdateAsync(request);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
            await _appService.DeleteAsync(ids);
        }
    }
}