using System;
using System.Threading.Tasks;
using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Dtos.Requests;
using KissU.GreatWall.Service.Queries;
using Util.Applications;
using Util.Aspects;
using Util.Validations.Aspects;

namespace KissU.GreatWall.Service.Abstractions {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleService : IDeleteService<RoleDto, RoleQuery> {
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