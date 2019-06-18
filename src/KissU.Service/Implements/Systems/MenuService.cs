using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using KissU.Data;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Service.Implements.Systems {
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : TreeServiceBase<Menu, MenuDto, MenuQuery>, IMenuService {
        /// <summary>
        /// 初始化菜单服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="menuRepository">菜单仓储</param>
        public MenuService( IKissUUnitOfWork unitOfWork, IMenuRepository menuRepository )
            : base( unitOfWork, menuRepository ) {
            MenuRepository = menuRepository;
        }
        
        /// <summary>
        /// 菜单仓储
        /// </summary>
        public IMenuRepository MenuRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Menu> CreateQuery( MenuQuery param ) {
            return new Query<Menu>( param );
        }
    }
}