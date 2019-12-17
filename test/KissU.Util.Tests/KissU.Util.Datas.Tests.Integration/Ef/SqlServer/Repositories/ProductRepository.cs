using KissU.Util.Datas.Ef.Core;
using KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Stores;

namespace KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Repositories {
    /// <summary>
    /// 商品仓储
    /// </summary>
    public class ProductRepository : CompactRepositoryBase<Product, ProductPo, int>, IProductRepository {
        /// <summary>
        /// 商品持久化存储
        /// </summary>
        private readonly IProductPoStore _store;

        /// <summary>
        /// 初始化商品仓储
        /// </summary>
        /// <param name="store">商品持久化存储</param>
        public ProductRepository( IProductPoStore store ) : base( store ) {
            _store = store;
        }

        /// <summary>
        /// 将持久化对象转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Product ToEntity( ProductPo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 将实体转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ProductPo ToPo( Product entity ) {
            return entity.ToPo();
        }

        /// <summary>
        /// 通过编号获取商品
        /// </summary>
        /// <param name="id">商品编号</param>
        public Product GetById( int id ) {
            return ToEntity( _store.Single( t => t.Id == id ) );
        }
    }
}
