﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreatWall.Domain.Models;
using Util.Domains.Trees;

namespace GreatWall.Domain.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role> {
        /// <summary>
        /// 获取已添加的用户标识列表
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="userIds">用户标识列表</param>
        Task<List<Guid>> GetExistsUserIdsAsync( Guid roleId, List<Guid> userIds );
        /// <summary>
        /// 添加用户角色列表
        /// </summary>
        /// <param name="userRoles">用户角色列表</param>
        Task AddUserRolesAsync( IEnumerable<UserRole> userRoles );
        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="userRoles">用户角色列表</param>
        void RemoveUserRoles( IEnumerable<UserRole> userRoles );
    }
}
