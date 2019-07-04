using Util.Webs.Controllers;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;
using GreatWall.Service.Abstractions.Systems;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// Api资源控制器
    /// </summary>
    public class ApiController : CrudControllerBase<ApiDto, ApiQuery> {
        /// <summary>
        /// 初始化Api资源控制器
        /// </summary>
        /// <param name="service">Api资源服务</param>
        public ApiController( IApiService service ) : base( service ) {
            ApiService = service;
        }
        
        /// <summary>
        /// Api资源服务
        /// </summary>
        public IApiService ApiService { get; }
    }
}