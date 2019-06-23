using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Ui.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems 
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    public class MenuController : TreeTableControllerBase<MenuDto, MenuQuery> 
	{
        /// <summary>
        /// 初始化菜单控制器
        /// </summary>
        /// <param name="service">菜单服务</param>
        public MenuController( IMenuService service ) : base( service ) {
            MenuService = service;
        }

        /// <summary>
        /// 菜单服务
        /// </summary>
        public IMenuService MenuService { get; }

		/// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="request">创建请求参数</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]MenuDto request)
        {
            var id = await MenuService.CreateAsync(request);
            return Success(id);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="request">修改请求参数</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] MenuDto request)
        {
            await MenuService.UpdateAsync(request);
            return Success();
        }
    }
}