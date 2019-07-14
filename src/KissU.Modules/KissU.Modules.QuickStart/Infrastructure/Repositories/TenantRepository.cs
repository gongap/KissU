using KissU.Modules.QuickStart.Domain.Models;
using KissU.Modules.QuickStart.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Modules.QuickStart.Infrastructure.Repositories {
    /// <summary>
    /// 租户仓储
    /// </summary>
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository {
        /// <summary>
        /// 初始化租户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public TenantRepository(IQuickStartUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}