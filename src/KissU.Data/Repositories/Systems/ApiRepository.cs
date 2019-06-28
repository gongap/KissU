using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems {
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