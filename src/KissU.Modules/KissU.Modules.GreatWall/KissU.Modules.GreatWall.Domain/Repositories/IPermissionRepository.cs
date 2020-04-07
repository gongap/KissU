﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Ddd.Domain.Datas.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    /// <summary>
    /// 权限仓储
    /// </summary>
    public interface IPermissionRepository : IRepository<Permission>
    {
        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleId">角色标识</param>
        /// <param name="isDeny">是否拒绝</param>
        /// <returns>Task&lt;List&lt;Guid&gt;&gt;.</returns>
        Task<List<Guid>> GetResourceIdsAsync(Guid applicationId, Guid roleId, bool isDeny);

        /// <summary>
        /// 获取权限标识列表
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="resourceIds">资源标识列表</param>
        /// <returns>Task&lt;List&lt;Guid&gt;&gt;.</returns>
        Task<List<Guid>> GetPermissionIdsAsync(Guid roleId, List<Guid> resourceIds);

        /// <summary>
        /// 移除权限
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="resourceIds">资源标识列表</param>
        /// <returns>Task.</returns>
        Task RemoveAsync(Guid roleId, List<Guid> resourceIds);
    }
}