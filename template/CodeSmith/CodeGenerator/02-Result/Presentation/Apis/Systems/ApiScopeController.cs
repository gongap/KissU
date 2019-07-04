using Util.Webs.Controllers;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;
using KissU.GreatWall.Service.Abstractions.Systems;

namespace KissU.GreatWall.Apis.Systems {
    /// <summary>
    /// Api许可范围控制器
    /// </summary>
    public class ApiScopeController : CrudControllerBase<ApiScopeDto, ApiScopeQuery> {
        /// <summary>
        /// 初始化Api许可范围控制器
        /// </summary>
        /// <param name="service">Api许可范围服务</param>
        public ApiScopeController( IApiScopeService service ) : base( service ) {
            ApiScopeService = service;
        }
        
        /// <summary>
        /// Api许可范围服务
        /// </summary>
        public IApiScopeService ApiScopeService { get; }
    }
}