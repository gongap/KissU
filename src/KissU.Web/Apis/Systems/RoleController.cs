using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Ui.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems 
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : TreeTableControllerBase<RoleDto, RoleQuery> 
	{
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
        /// <param name="request">创建请求参数</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]RoleDto request)
        {
            var id = await RoleService.CreateAsync(request);
            return Success(id);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改请求参数</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoleDto request)
        {
            await RoleService.UpdateAsync(request);
            return Success();
        }
    }
}