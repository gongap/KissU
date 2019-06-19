using Util.Webs.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    public class ApplicationController : CrudControllerBase<ApplicationDto, ApplicationQuery> {

        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
        /// <param name="service">应用程序服务</param>
        public ApplicationController( IApplicationService service ) : base( service ) {
            ApplicationService = service;
        }

        /// <summary>
        /// 应用程序服务
        /// </summary>
        public IApplicationService ApplicationService { get; }
    }
}