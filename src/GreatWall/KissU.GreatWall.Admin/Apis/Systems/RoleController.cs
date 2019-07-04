using System.Threading.Tasks;
using KissU.GreatWall.Service.Abstractions;
using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Dtos.Requests;
using KissU.GreatWall.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Util;
using Util.Webs.Controllers;

namespace KissU.GreatWall.Apis.Systems {
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : QueryControllerBase<RoleDto, RoleQuery> {
        /// <summary>
        /// 初始化角色控制器
        /// </summary>
        /// <param name="service">角色服务</param>
        public RoleController( IRoleService service ) : base( service ) {
            RoleService = service;
        }

        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleService RoleService { get; }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync( [FromBody] CreateRoleRequest request ) {
            var id = await RoleService.CreateAsync( request );
            return Success( id );
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync( [FromBody] UpdateRoleRequest request ) {
            await RoleService.UpdateAsync( request );
            return Success();
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ids">标识列表，多个Id用逗号分隔，范例：1,2,3</param>
        [HttpPost( "delete" )]
        public virtual async Task<IActionResult> DeleteAsync( [FromBody] string ids ) {
            await RoleService.DeleteAsync( ids );
            return Success();
        }

        /// <summary>
        /// 添加用户列表到角色
        /// </summary>
        [HttpPost( "AddUsersToRole" )]
        public async Task<IActionResult> AddUsersToRoleAsync( [FromBody] UserRoleRequest request ) {
            await RoleService.AddUsersToRoleAsync( request );
            return Success();
        }

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        [HttpPost( "RemoveUsersFromRole" )]
        public async Task<IActionResult> RemoveUsersFromRole( [FromBody] UserRoleRequest request ) {
            await RoleService.RemoveUsersFromRoleAsync( request );
            return Success();
        }
    }
}