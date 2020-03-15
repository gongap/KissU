using KissU.Util.Datas.Ef.Core;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.Ef.SqlServer.UnitOfWorks;

namespace KissU.Util.Datas.Tests.Integration.Ef.SqlServer.Repositories
{
    /// <summary>
    /// 客户仓储
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer, string>, ICustomerRepository
    {
        /// <summary>
        /// 初始化客户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public CustomerRepository(ISqlServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}