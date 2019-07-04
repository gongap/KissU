using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository {
        /// <summary>
        /// 初始化用户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public UserRepository( IKissU.GreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}