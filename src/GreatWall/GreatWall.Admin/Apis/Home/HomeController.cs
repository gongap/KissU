using System.Collections.Generic;
using System.Threading.Tasks;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos.Extensions;
using GreatWall.Service.Dtos.NgAlain;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace GreatWall.Apis.Home {
    /// <summary>
    /// 主控制器
    /// </summary>
    public class HomeController : WebApiControllerBase {
        /// <summary>
        /// 初始化主控制器
        /// </summary>
        /// <param name="menuService">菜单服务</param>
        public HomeController( IMenuService menuService ) {
            MenuService = menuService;
        }

        /// <summary>
        /// 菜单服务
        /// </summary>
        public IMenuService MenuService { get; set; }

        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAppDataAsync() {
            var data = new AppData {
                App = { Name = "GreatWall", Description = ".Net Core权限系统" },
                User = { Name = "何镇汐", Avatar = "/assets/img/avatar.jpg", Email = "xiadao521@qq.com" },
                Menu = await GetMenus()
            };
            return Success( data );
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        private async Task<List<MenuInfo>> GetMenus() {
            var result = await MenuService.GetMenusAsync();
            return result.ToNgAlainMenus();
        }
    }
}