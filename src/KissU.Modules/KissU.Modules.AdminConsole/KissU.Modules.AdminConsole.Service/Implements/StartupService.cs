using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.AdminConsole.Service.Contracts.Abstractions;
using KissU.Modules.AdminConsole.Service.Contracts.Dtos.NgAlain;
using KissU.Modules.AdminConsole.Service.Extensions;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.KestrelHttpServer.Internal;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.AdminConsole.Service.Implements
{
    /// <summary>
    /// 启动服务
    /// </summary>
    public class StartupService : ProxyServiceBase, IStartupService
    {
        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        /// <returns>Task&lt;AppData&gt;.</returns>
        [HttpGet(true)]
        public async Task<AppData> GetAppDataAsync()
        {
            var data = new AppData
            {
                App = { Name = "KissU", Description = ".Net Core权限系统" },
                User = { Name = RestContext.Identity.Name, Avatar = "/assets/tmp/img/avatar.jpg", Email = "gongap@qq.com" },
                Menu = await GetMenus()
            };
            return data;
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        private async Task<List<MenuInfo>> GetMenus()
        {
            var result = await GetService<IMenuService>().GetMenusAsync();
            return result.ToNgAlainMenus();
        }
    }
}