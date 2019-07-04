using Util.Webs.Controllers;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Queries.Systems;
using KFNets.Veterinary.Service.Abstractions.Systems;

namespace KFNets.Veterinary.Web.Apis.Systems 
{
    /// <summary>
    /// Api资源控制器
    /// </summary>
    public class ApiController : CrudControllerBase<ApiDto, ApiQuery> 
	{
        
        /// <summary>
        /// 初始化Api资源控制器
        /// </summary>
		/// <param name="service">Api资源服务</param>
        public ApiController( IApiService service ) : base( service ) 
		{
            ApiService = service;
        }

        /// <summary>
        /// Api资源服务
        /// </summary>
        public IApiService ApiService { get; }
    }
}