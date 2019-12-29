using KissU.Util.Datas.Stores;
using KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos;

namespace KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Stores
{
    /// <summary>
    /// 商品持久化存储
    /// </summary>
    public interface IProductPoStore : IStore<ProductPo, int>
    {
    }
}