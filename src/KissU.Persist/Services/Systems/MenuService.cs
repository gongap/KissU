using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using KissU.Data;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;
using KissU.Data.Pos.Systems;
using KissU.Data.Stores.Abstractions.Systems;

namespace KissU.Service.Implements.Systems 
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : TreeServiceBase<MenuPo, MenuDto, MenuQuery>, IMenuService 
	{
        /// <summary>
        /// 初始化菜单服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="menuStore">菜单存储器</param>
        public MenuService( IKissUUnitOfWork unitOfWork, IMenuPoStore menuStore )
            : base( unitOfWork, menuStore ) 
		{
            MenuStore = menuStore;
        }
        
        /// <summary>
        /// 菜单存储器
        /// </summary>
        public IMenuPoStore MenuStore { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<MenuPo> CreateQuery( MenuQuery param ) 
		{
            return new Query<MenuPo>( param );
        }
    }
}