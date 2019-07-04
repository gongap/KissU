using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IKissU.GreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}