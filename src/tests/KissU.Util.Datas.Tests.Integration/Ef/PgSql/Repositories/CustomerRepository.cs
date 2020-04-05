using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.Ef.PgSql.UnitOfWorks;
using KissU.Util.EntityFrameworkCore.Core;

namespace KissU.Util.Datas.Tests.Integration.Ef.PgSql.Repositories
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
        public CustomerRepository(IPgSqlUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}