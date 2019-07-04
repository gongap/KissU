using KissU.GreatWall.Domain.Models;
using KissU.GreatWall.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.GreatWall.Data.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IGreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}