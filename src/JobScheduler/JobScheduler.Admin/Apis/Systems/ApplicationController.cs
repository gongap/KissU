using Util.Webs.Controllers;
using JobScheduler.Service.Dtos.Systems;
using JobScheduler.Service.Queries.Systems;
using JobScheduler.Service.Abstractions.Systems;

namespace JobScheduler.Admin.Apis.Systems 
{
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    public class ApplicationController : CrudControllerBase<ApplicationDto, ApplicationQuery> 
	{
        
        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
		/// <param name="service">应用程序服务</param>
        public ApplicationController( IApplicationService service ) : base( service ) 
		{
            ApplicationService = service;
        }

        /// <summary>
        /// 应用程序服务
        /// </summary>
        public IApplicationService ApplicationService { get; }
    }
}