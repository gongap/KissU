using Util.Datas.Ef.Core;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;

namespace GreatWall.Data.Stores.Implements.Systems{
    /// <summary>
    /// 角色存储器
    /// </summary>
    public class RolePoStore : StoreBase<RolePo>, IRolePoStore {
        /// <summary>
        /// 初始化角色存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RolePoStore( IKissU.GreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}