using System.Collections.Generic;
using System.Threading.Tasks;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos.Extensions;
using GreatWall.Service.Dtos.NgAlain;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.ProxyGenerator;
using Surging.IModuleServices.User;

namespace KissU.Modules.Admin
{
    /// <summary>
    /// 启动服务
    /// </summary>
    public class StartupService : ProxyServiceBase, IStartupService
    {
        /// <summary>
        /// 初始化主控制器
        /// </summary>
        /// <param name="menuService">菜单服务</param>
        public StartupService(IMenuService menuService)
        {
            MenuService = menuService;
        }

        /// <summary>
        /// 菜单服务
        /// </summary>
        public IMenuService MenuService { get; set; }

        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        [HttpGet(true)]
        public async Task<AppData> GetAppDataAsync()
        {
            var data = new AppData
            {
                App = { Name = "GreatWall", Description = ".Net Core权限系统" },
                User = { Name = "", Avatar = "/assets/tmp/img/avatar.jpg", Email = "xiadao521@qq.com" },
                Menu = await GetMenus()
            };
            return data;
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        private async Task<List<MenuInfo>> GetMenus()
        {
            var result = await MenuService.GetMenusAsync();
            return result.ToNgAlainMenus();
        }
    }
}
