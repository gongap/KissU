using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.Ddd.Domain.Datas.Repositories;

namespace KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories
{
    /// <summary>
    /// 订单仓储
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
    }
}