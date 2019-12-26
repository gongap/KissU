// <copyright file="IQueryApplicationService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public class QueryApplicationService: IQueryApplicationService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<ApplicationDto> GetByIdAsync(object id)
        {
            return null;
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<ApplicationDto>> GetByIdsAsync(string ids)
        {
            return null;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<ApplicationDto>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<ApplicationDto>> QueryAsync(ApplicationQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<ApplicationDto>> PagerQueryAsync(ApplicationQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        public async Task<ApplicationDto> GetByCodeAsync(string code)
        {
            return null;
        }

        /// <summary>
        /// 是否允许跨域访问
        /// </summary>
        /// <param name="origin">来源</param>
        public async Task<bool> IsOriginAllowedAsync(string origin)
        {
            return false;
        }

        /// <summary>
        /// 获取作用域
        /// </summary>
        public async Task<List<Item>> GetScopes()
        {
            return null;
        }
    }
}
