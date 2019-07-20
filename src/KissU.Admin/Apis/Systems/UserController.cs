using System.Threading.Tasks;
using GreatWall.Service.Abstractions;
using Util.Webs.Controllers;
using GreatWall.Service.Dtos;
using GreatWall.Service.Dtos.Requests;
using GreatWall.Service.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : QueryControllerBase<UserDto, UserQuery> {
        /// <summary>
        /// 初始化用户控制器
        /// </summary>
        /// <param name="service">用户服务</param>
        public UserController( IUserService service ) : base( service ) {
            UserService = service;
        }
        
        /// <summary>
        /// 用户服务
        /// </summary>
        public IUserService UserService { get; }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync( [FromBody] CreateUserRequest request ) {
            var id = await UserService.CreateAsync( request );
            return Success( id );
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids">标识列表，多个Id用逗号分隔，范例：1,2,3</param>
        [HttpPost( "delete" )]
        public virtual async Task<IActionResult> DeleteAsync( [FromBody] string ids ) {
            await UserService.DeleteAsync( ids );
            return Success();
        }
    }
}