using Util.Datas.Ef.Core;
using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;
using GreatWall.Data.Pos.Systems.Extensions;

namespace GreatWall.Data.Repositories.Systems {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : CompactRepositoryBase<Application,ApplicationPo>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="store">应用程序存储器</param>
        public ApplicationRepository( IApplicationPoStore store ) : base( store ) {
        }
        
        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Application ToEntity( ApplicationPo po ) {
            return po.ToEntity();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ApplicationPo ToPo( Application entity ) {
            return entity.ToPo();
        }
    }
}