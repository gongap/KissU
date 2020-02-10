using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Application.Abstractions
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleAppService : IDeleteService<RoleDto, RoleQuery>
    {
        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>Task&lt;List&lt;RoleDto&gt;&gt;.</returns>
        Task<List<RoleDto>> GetRolesAsync(Guid userId);

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        Task<Guid> CreateAsync([NotNull] [Valid] CreateRoleRequest request);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        /// <returns>Task.</returns>
        Task UpdateAsync([NotNull] [Valid] UpdateRoleRequest request);

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        /// <returns>Task.</returns>
        Task AddUsersToRoleAsync(UserRoleRequest request);

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        /// <returns>Task.</returns>
        Task RemoveUsersFromRoleAsync(UserRoleRequest request);
    }
}