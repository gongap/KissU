using KFNets.Veterinary.Domain.Systems.Models;
using KFNets.Veterinary.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KFNets.Veterinary.Data.Repositories.Systems {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public class RoleRepository : TreeRepositoryBase<Role>, IRoleRepository {
        /// <summary>
        /// 初始化角色仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RoleRepository( IKFNetsUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
