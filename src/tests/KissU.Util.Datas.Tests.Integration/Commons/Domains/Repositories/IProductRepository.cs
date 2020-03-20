using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.Domains.Repositories;

namespace KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories
{
    /// <summary>
    /// 商品仓储
    /// </summary>
    public interface IProductRepository : ICompactRepository<Product, int>
    {
        /// <summary>
        /// 通过标识获取商品 - 内部采用FirstOrDefault方法获取
        /// </summary>
        /// <param name="id">商品编号</param>
        /// <returns>Product.</returns>
        Product GetById(int id);
    }
}