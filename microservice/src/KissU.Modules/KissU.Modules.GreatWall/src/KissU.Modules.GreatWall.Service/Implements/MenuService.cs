using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Responses;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : ProxyServiceBase, IMenuService
    {
        private readonly IMenuAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public MenuService(IMenuAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns>Task&lt;List&lt;MenuResponse&gt;&gt;.</returns>
        public async Task<List<MenuResponse>> GetMenusAsync()
        {
            return await _appService.GetMenusAsync();
        }
    }
}