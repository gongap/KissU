using KissU.Util.Datas.Ef.Core;
using KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos;
using KissU.Util.Datas.Tests.Integration.Ef.SqlServer.UnitOfWorks;

namespace KissU.Util.Datas.Tests.Integration.Ef.SqlServer.Stores {
    /// <summary>
    /// 商品持久化存储
    /// </summary>
    public class ProductPoStore : StoreBase<ProductPo, int>, IProductPoStore {
        /// <summary>
        /// 初始化商品持久化存储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ProductPoStore( ISqlServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
