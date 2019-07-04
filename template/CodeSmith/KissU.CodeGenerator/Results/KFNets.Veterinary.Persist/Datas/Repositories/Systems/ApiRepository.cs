using Util.Datas.Ef.Core;
using KFNets.Veterinary.Domain.Systems.Models;
using KFNets.Veterinary.Domain.Systems.Repositories;
using KFNets.Veterinary.Data.Pos.Systems;
using KFNets.Veterinary.Data.Stores.Abstractions.Systems;
using KFNets.Veterinary.Data.Pos.Systems.Extensions;

namespace KFNets.Veterinary.Data.Repositories.Systems {
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