// <copyright file="IQueryModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public class QueryModuleService : IQueryModuleService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<ModuleDto> GetByIdAsync(object id)
        {
            return null;
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<ModuleDto>> GetByIdsAsync(string ids)
        {
            return null;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<ModuleDto>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<ModuleDto>> QueryAsync(ResourceQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<ModuleDto>> PagerQueryAsync(ResourceQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
        }

        /// <summary>
        /// 通过标识查找列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public async Task<List<ModuleDto>> FindByIdsAsync(string ids)
        {
            return null;
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        public async Task EnableAsync(string ids)
        {
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        public async Task DisableAsync(string ids)
        {
        }

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="swapId">目标标识</param>
        public async Task SwapSortAsync(Guid id, Guid swapId)
        {
        }

        /// <summary>
        /// 修正排序
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task FixSortIdAsync(ResourceQuery parameter)
        {
        }
    }
}
