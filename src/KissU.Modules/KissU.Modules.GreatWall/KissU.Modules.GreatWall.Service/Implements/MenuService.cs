using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos.Responses;
using KissU.Modules.GreatWall.Service.Contracts;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : IMenuService
    {
        private readonly IMenuAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        public MenuService(IMenuAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        public async Task<List<MenuResponse>> GetMenusAsync()
        {
            return await _appService.GetMenusAsync();
        }
    }
}