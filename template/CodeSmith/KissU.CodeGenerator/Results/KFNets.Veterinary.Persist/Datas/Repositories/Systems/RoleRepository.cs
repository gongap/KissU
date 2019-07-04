using Util.Datas.Ef.Core;
using KFNets.Veterinary.Domain.Systems.Models;
using KFNets.Veterinary.Domain.Systems.Repositories;
using KFNets.Veterinary.Data.Pos.Systems;
using KFNets.Veterinary.Data.Stores.Abstractions.Systems;
using KFNets.Veterinary.Data.Pos.Systems.Extensions;

namespace KFNets.Veterinary.Data.Repositories.Systems {
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