using KissU.Core.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;

namespace KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories
{
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer, string>
    {
    }
}