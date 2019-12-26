// <copyright file="IRoleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Domains.Repositories;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<RoleDto> GetByIdAsync(object id)
        {
            return null;
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<RoleDto>> GetByIdsAsync(string ids)
        {
            return null;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<RoleDto>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<RoleDto>> QueryAsync(RoleQuery parameter)
        {
            return null;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<RoleDto>> PagerQueryAsync(RoleQuery parameter)
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
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        public async Task<List<RoleDto>> GetRolesAsync(Guid userId)
        {
            return null;
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        public async Task<Guid> CreateAsync(CreateRoleRequest request)
        {
            return default;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        public async Task UpdateAsync(UpdateRoleRequest request)
        {
        }

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        public async Task AddUsersToRoleAsync(UserRoleRequest request)
        {
        }

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        public async Task RemoveUsersFromRoleAsync(UserRoleRequest request)
        {
        }
    }
}
