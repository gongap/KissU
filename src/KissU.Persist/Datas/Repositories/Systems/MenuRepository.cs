using Util.Datas.Ef.Core;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using KissU.Data.Pos.Systems;
using KissU.Data.Stores.Abstractions.Systems;
using KissU.Data.Pos.Systems.Extensions;

namespace KissU.Data.Repositories.Systems {
    /// <summary>
    /// 菜单仓储
    /// </summary>
    public class MenuRepository : CompactRepositoryBase<Menu,MenuPo>, IMenuRepository {
        /// <summary>
        /// 初始化菜单仓储
        /// </summary>
        /// <param name="store">菜单存储器</param>
        public MenuRepository( IMenuPoStore store ) : base( store ) {
        }
        
        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Menu ToEntity( MenuPo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override MenuPo ToPo( Menu entity ) {
            return entity.ToPo();
        }
    }
}