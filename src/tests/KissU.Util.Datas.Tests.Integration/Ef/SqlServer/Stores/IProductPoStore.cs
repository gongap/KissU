using KissU.Core.Datas.Stores;
using KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos;

namespace KissU.Util.Datas.Tests.Integration.Ef.SqlServer.Stores
{
    /// <summary>
    /// 商品持久化存储
    /// </summary>
    public interface IProductPoStore : IStore<ProductPo, int>
    {
    }
}