// <copyright file="IClaimService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Applications.Aspects;
using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 声明服务
    /// </summary>
    public class ClaimService : IClaimService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<ClaimDto> GetByIdAsync(object id)
        {
            return null;
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<ClaimDto>> GetByIdsAsync(string ids)
        {
            return null;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<ClaimDto>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<ClaimDto>> QueryAsync(ClaimQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<ClaimDto>> PagerQueryAsync(ClaimQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        public async Task<string> CreateAsync(ClaimDto request)
        {
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public async Task UpdateAsync(ClaimDto request)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
        }

        /// <summary>
        /// 获取已启用的声明列表
        /// </summary>
        public async Task<List<ClaimDto>> GetEnabledClaimsAsync()
        {
            return null;
        }
    }
}
