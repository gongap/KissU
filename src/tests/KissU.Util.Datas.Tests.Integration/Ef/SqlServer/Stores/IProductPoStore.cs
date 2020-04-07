using KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos;
using KissU.Util.Ddd.Domain.Datas.Stores;

namespace KissU.Util.Datas.Tests.Integration.Ef.SqlServer.Stores
{
    /// <summary>
    /// 商品持久化存储
    /// </summary>
    public interface IProductPoStore : IStore<ProductPo, int>
    {
    }
}