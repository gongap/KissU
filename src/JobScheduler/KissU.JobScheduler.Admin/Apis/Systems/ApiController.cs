using Util.Webs.Controllers;
using KissU.JobScheduler.Service.Dtos.Systems;
using KissU.JobScheduler.Service.Queries.Systems;
using KissU.JobScheduler.Service.Abstractions.Systems;

namespace KissU.JobScheduler.Admin.Apis.Systems
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