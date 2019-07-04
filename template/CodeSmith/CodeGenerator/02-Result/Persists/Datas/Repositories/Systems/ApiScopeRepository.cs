using Util.Datas.Ef.Core;
using KissU.GreatWall.Systems.Domain.Models;
using KissU.GreatWall.Systems.Domain.Repositories;
using KissU.GreatWall.Data.Pos.Systems;
using KissU.GreatWall.Data.Stores.Abstractions.Systems;
using KissU.GreatWall.Data.Pos.Systems.Extensions;

namespace KissU.GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// Api许可范围仓储
    /// </summary>
    public class ApiScopeRepository : CompactRepositoryBase<ApiScope,ApiScopePo>, IApiScopeRepository {
        /// <summary>
        /// 初始化Api许可范围仓储
        /// </summary>
        /// <param name="store">Api许可范围存储器</param>
        public ApiScopeRepository( IApiScopePoStore store ) : base( store ) {
        }
        
        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override ApiScope ToEntity( ApiScopePo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ApiScopePo ToPo( ApiScope entity ) {
            return entity.ToPo();
        }
    }
}