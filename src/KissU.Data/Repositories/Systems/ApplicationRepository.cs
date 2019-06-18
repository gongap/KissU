using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}