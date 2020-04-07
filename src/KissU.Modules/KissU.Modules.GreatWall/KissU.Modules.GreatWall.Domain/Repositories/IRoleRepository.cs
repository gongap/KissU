using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Ddd.Data.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role>
    {
        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>Task&lt;List&lt;Role&gt;&gt;.</returns>
        Task<List<Role>> GetRolesAsync(Guid userId);

        /// <summary>
        /// 获取用户的角色标识列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>Task&lt;List&lt;Guid&gt;&gt;.</returns>
        Task<List<Guid>> GetRoleIdsAsync(Guid userId);

        /// <summary>
        /// 获取已添加的用户标识列表
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="userIds">用户标识列表</param>
        /// <returns>Task&lt;List&lt;Guid&gt;&gt;.</returns>
        Task<List<Guid>> GetExistsUserIdsAsync(Guid roleId, List<Guid> userIds);

        /// <summary>
        /// 添加用户角色列表
        /// </summary>
        /// <param name="userRoles">用户角色列表</param>
        /// <returns>Task.</returns>
        Task AddUserRolesAsync(IEnumerable<UserRole> userRoles);

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="userRoles">用户角色列表</param>
        void RemoveUserRoles(IEnumerable<UserRole> userRoles);
    }
}