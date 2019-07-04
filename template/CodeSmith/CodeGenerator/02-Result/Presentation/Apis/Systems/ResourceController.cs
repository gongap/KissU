using Util.Ui.Controllers;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;
using GreatWall.Service.Abstractions.Systems;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// 资源控制器
    /// </summary>
    public class ResourceController : TreeControllerBase<ResourceDto, ResourceQuery> {
        /// <summary>
        /// 初始化资源控制器
        /// </summary>
        /// <param name="service">资源服务</param>
        public ResourceController( IResourceService service ) : base( service ) {
            ResourceService = service;
        }

        /// <summary>
        /// 资源服务
        /// </summary>
        public IResourceService ResourceService { get; }
    }
}