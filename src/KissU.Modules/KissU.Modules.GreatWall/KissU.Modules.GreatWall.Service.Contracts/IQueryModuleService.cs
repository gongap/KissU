// <copyright file="IQueryModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IQueryModuleService : IService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<ModuleDto> GetByIdAsync(string id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<ModuleDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<ModuleDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<ModuleDto>> QueryAsync(ResourceQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<ModuleDto>> PagerQueryAsync(ResourceQuery parameter);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        /// 通过标识查找列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        [HttpGet(true)]
        Task<List<ModuleDto>> FindByIdsAsync(string ids);

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        [HttpPost(true)]
        Task EnableAsync(string ids);

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        [HttpPost(true)]
        Task DisableAsync(string ids);

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="swapId">目标标识</param>
        [HttpGet(true)]
        Task SwapSortAsync(Guid id, Guid swapId);

        /// <summary>
        /// 修正排序
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task FixSortIdAsync(ResourceQuery parameter);
    }
}
