using Util.Datas.Ef.Core;
using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;
using GreatWall.Data.Pos.Systems.Extensions;

namespace GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// Api资源仓储
    /// </summary>
    public class ApiRepository : CompactRepositoryBase<Api,ApiPo>, IApiRepository {
        /// <summary>
        /// 初始化Api资源仓储
        /// </summary>
        /// <param name="store">Api资源存储器</param>
        public ApiRepository( IApiPoStore store ) : base( store ) {
        }
        
        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Api ToEntity( ApiPo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ApiPo ToPo( Api entity ) {
            return entity.ToPo();
        }
    }
}