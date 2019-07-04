using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// Api资源仓储
    /// </summary>
    public class ApiRepository : RepositoryBase<Api>, IApiRepository {
        /// <summary>
        /// 初始化Api资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}