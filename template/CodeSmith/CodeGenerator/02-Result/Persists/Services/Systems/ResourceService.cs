using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using GreatWall.Data;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;
using GreatWall.Service.Abstractions.Systems;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;

namespace GreatWall.Service.Implements.Systems {
    /// <summary>
    /// 资源服务
    /// </summary>
    public class ResourceService : TreeServiceBase<ResourcePo, ResourceDto, ResourceQuery>, IResourceService {
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="resourceStore">资源存储器</param>
        public ResourceService( IKissU.GreatWallUnitOfWork unitOfWork, IResourcePoStore resourceStore )
            : base( unitOfWork, resourceStore ) {
            ResourceStore = resourceStore;
        }
        
        /// <summary>
        /// 资源存储器
        /// </summary>
        public IResourcePoStore ResourceStore { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ResourcePo> CreateQuery( ResourceQuery param ) {
            return new Query<ResourcePo>( param );
        }
    }
}