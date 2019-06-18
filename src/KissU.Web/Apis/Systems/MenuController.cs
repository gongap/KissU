using Util.Ui.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems {
    /// <summary>
    /// 控制器
    /// </summary>
    public class MenuController : TreeControllerBase<MenuDto, MenuQuery> {
        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        public MenuController( IMenuService service ) : base( service ) {
            MenuService = service;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public IMenuService MenuService { get; }
    }
}