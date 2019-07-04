using KFNets.Veterinary.Domain.Systems.Models;
using KFNets.Veterinary.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KFNets.Veterinary.Data.Repositories.Systems {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IKFNetsUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}