using KissU.Util.Datas.Ef.Core;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.SqlServer.Ef.UnitOfWorks;

namespace KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Repositories {
    /// <summary>
    /// 订单仓储
    /// </summary>
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository {
        /// <summary>
        /// 初始化订单仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public OrderRepository( ISqlServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
