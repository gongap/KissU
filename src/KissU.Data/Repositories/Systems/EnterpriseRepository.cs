using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems {
    /// <summary>
    /// 企业仓储
    /// </summary>
    public class EnterpriseRepository : RepositoryBase<Enterprise>, IEnterpriseRepository {
        /// <summary>
        /// 初始化企业仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public EnterpriseRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}