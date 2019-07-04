using Util.Datas.Ef.Core;
using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;
using GreatWall.Data.Pos.Systems.Extensions;

namespace GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public class RoleRepository : CompactRepositoryBase<Role,RolePo>, IRoleRepository {
        /// <summary>
        /// 初始化角色仓储
        /// </summary>
        /// <param name="store">角色存储器</param>
        public RoleRepository( IRolePoStore store ) : base( store ) {
        }
        
        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Role ToEntity( RolePo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override RolePo ToPo( Role entity ) {
            return entity.ToPo();
        }
    }
}