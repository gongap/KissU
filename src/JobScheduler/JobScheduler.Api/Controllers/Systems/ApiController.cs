using Util.Webs.Controllers;
using JobScheduler.Service.Dtos.Systems;
using JobScheduler.Service.Queries.Systems;
using JobScheduler.Service.Abstractions.Systems;

namespace JobScheduler.Api.Controllers.Systems
{
    /// <summary>
    /// Api资源控制器
    /// </summary>
    public class ApiController : CrudControllerBase<ApiDto, ApiCreateRequest, ApiUpdateRequest, ApiQuery>
    {

        /// <summary>
        /// 初始化Api资源控制器
        /// </summary>
        /// <param name="service">Api资源服务</param>
        public ApiController(IApiService service) : base(service)
        {
            ApiService = service;
        }

        /// <summary>
        /// Api资源服务
        /// </summary>
        public IApiService ApiService { get; }
    }
}