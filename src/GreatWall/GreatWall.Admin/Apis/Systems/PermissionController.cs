using System.Threading.Tasks;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos.Requests;
using GreatWall.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// 权限控制器
    /// </summary>
    public class PermissionController : WebApiControllerBase {
        /// <summary>
        /// 初始化权限控制器
        /// </summary>
        /// <param name="service">权限服务</param>
        public PermissionController( IPermissionService service ) {
            PermissionService = service;
        }

        /// <summary>
        /// 权限服务
        /// </summary>
        public IPermissionService PermissionService { get; }

        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet("resourceIds")]
        public virtual async Task<IActionResult> GetResourceIdsAsync( PermissionQuery query ) {
            var result = await PermissionService.GetResourceIdsAsync( query );
            return Success( result );
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        [HttpPost]
        public async Task<IActionResult> SaveAsync( [FromBody] SavePermissionRequest request ) {
            await PermissionService.SaveAsync( request );
            return Success();
        }
    }
}