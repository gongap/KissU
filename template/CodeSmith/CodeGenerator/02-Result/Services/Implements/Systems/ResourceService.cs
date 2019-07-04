using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using KissU.GreatWall.Data;
using KissU.GreatWall.Systems.Domain.Models;
using KissU.GreatWall.Systems.Domain.Repositories;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;
using KissU.GreatWall.Service.Abstractions.Systems;

namespace KissU.GreatWall.Service.Implements.Systems {
    /// <summary>
    /// 资源服务
    /// </summary>
    public class ResourceService : TreeServiceBase<Resource, ResourceDto, ResourceQuery>, IResourceService {
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="resourceRepository">资源仓储</param>
        public ResourceService( IKissU.GreatWallUnitOfWork unitOfWork, IResourceRepository resourceRepository )
            : base( unitOfWork, resourceRepository ) {
            ResourceRepository = resourceRepository;
        }
        
        /// <summary>
        /// 资源仓储
        /// </summary>
        public IResourceRepository ResourceRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Resource> CreateQuery( ResourceQuery param ) {
            return new Query<Resource>( param );
        }
    }
}