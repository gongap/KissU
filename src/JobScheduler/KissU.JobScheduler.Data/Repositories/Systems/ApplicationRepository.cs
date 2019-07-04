using KissU.JobScheduler.Domain.Systems.Models;
using KissU.JobScheduler.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.JobScheduler.Data.Repositories.Systems {
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