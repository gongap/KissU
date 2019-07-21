using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreatWall.Service.Dtos;
using GreatWall.Service.Dtos.Requests;
using GreatWall.Service.Queries;
using Util.Applications;
using Util.Aspects;
using Util.Validations.Aspects;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleService : IDeleteService<RoleDto, RoleQuery> {
        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        Task<List<RoleDto>> GetRolesAsync( Guid userId );
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        Task<Guid> CreateAsync( [NotNull] [Valid] CreateRoleRequest request );
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        Task UpdateAsync( [NotNull] [Valid] UpdateRoleRequest request );
        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        Task AddUsersToRoleAsync( UserRoleRequest request );
        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        Task RemoveUsersFromRoleAsync( UserRoleRequest request );
    }
}