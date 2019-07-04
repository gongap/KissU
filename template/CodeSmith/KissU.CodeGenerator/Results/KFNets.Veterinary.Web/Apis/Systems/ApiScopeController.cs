using Util.Webs.Controllers;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Queries.Systems;
using KFNets.Veterinary.Service.Abstractions.Systems;

namespace KFNets.Veterinary.Web.Apis.Systems 
{
    /// <summary>
    /// Api许可范围控制器
    /// </summary>
    public class ApiScopeController : CrudControllerBase<ApiScopeDto, ApiScopeQuery> 
	{
        
        /// <summary>
        /// 初始化Api许可范围控制器
        /// </summary>
		/// <param name="service">Api许可范围服务</param>
        public ApiScopeController( IApiScopeService service ) : base( service ) 
		{
            ApiScopeService = service;
        }

        /// <summary>
        /// Api许可范围服务
        /// </summary>
        public IApiScopeService ApiScopeService { get; }
    }
}