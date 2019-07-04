using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public class ResourceRepository : TreeRepositoryBase<Resource>, IResourceRepository {
        /// <summary>
        /// 初始化资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourceRepository( IKissU.GreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
