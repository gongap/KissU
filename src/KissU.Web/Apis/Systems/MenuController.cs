using Util.Ui.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    public class MenuController : TreeControllerBase<MenuDto, MenuQuery>
    {
        /// <summary>
        /// 初始化菜单控制器
        /// </summary>
        /// <param name="service">菜单服务</param>
        public MenuController(IMenuService service) : base(service)
        {
            MenuService = service;
        }

        /// <summary>
        /// 菜单服务
        /// </summary>
        public IMenuService MenuService { get; }
    }

    /// <summary>
    /// 菜单控制器
    /// </summary>
    public class MenuTableController : TreeTableControllerBase<MenuDto, MenuQuery>
    {
        /// <summary>
        /// 初始化菜单控制器
        /// </summary>
        /// <param name="service">菜单服务</param>
        public MenuTableController(IMenuService service) : base(service)
        {
            MenuService = service;
        }

        /// <summary>
        /// 菜单服务
        /// </summary>
        public IMenuService MenuService { get; }
    }
}