using Util.Datas.Ef.Core;
using KissU.Domain.Models;
using KissU.Domain.Repositories;

namespace KissU.Data.Repositories.Systems {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( ISampleUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
