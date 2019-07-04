using KissU.JobScheduler.Domain.Systems.Models;
using KissU.JobScheduler.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.JobScheduler.Data.Repositories.Systems {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public class RoleRepository : TreeRepositoryBase<Role>, IRoleRepository {
        /// <summary>
        /// 初始化角色仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RoleRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
