using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository {
        /// <summary>
        /// 初始化用户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public UserRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}