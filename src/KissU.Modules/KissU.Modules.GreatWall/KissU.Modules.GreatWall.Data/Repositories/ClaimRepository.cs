using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Util.Datas.Ef.Core;

namespace KissU.Modules.GreatWall.Data.Repositories {
    /// <summary>
    /// 声明仓储
    /// </summary>
    public class ClaimRepository : RepositoryBase<Claim>, IClaimRepository {
        /// <summary>
        /// 初始化声明仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ClaimRepository( IGreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}