using Util.Datas.Ef.Core;
using KFNets.Veterinary.Data.Pos.Systems;
using KFNets.Veterinary.Data.Stores.Abstractions.Systems;

namespace KFNets.Veterinary.Data.Stores.Implements.Systems{
    /// <summary>
    /// 角色存储器
    /// </summary>
    public class RolePoStore : StoreBase<RolePo>, IRolePoStore {
        /// <summary>
        /// 初始化角色存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RolePoStore( IKFNetsUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}