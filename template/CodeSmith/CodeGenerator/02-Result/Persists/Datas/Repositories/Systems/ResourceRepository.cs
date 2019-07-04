using Util.Datas.Ef.Core;
using KissU.GreatWall.Systems.Domain.Models;
using KissU.GreatWall.Systems.Domain.Repositories;
using KissU.GreatWall.Data.Pos.Systems;
using KissU.GreatWall.Data.Stores.Abstractions.Systems;
using KissU.GreatWall.Data.Pos.Systems.Extensions;

namespace KissU.GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public class ResourceRepository : CompactRepositoryBase<Resource,ResourcePo>, IResourceRepository {
        /// <summary>
        /// 初始化资源仓储
        /// </summary>
        /// <param name="store">资源存储器</param>
        public ResourceRepository( IResourcePoStore store ) : base( store ) {
        }
        
        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Resource ToEntity( ResourcePo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourcePo ToPo( Resource entity ) {
            return entity.ToPo();
        }
    }
}