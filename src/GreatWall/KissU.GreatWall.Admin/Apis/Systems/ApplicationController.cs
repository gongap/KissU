using System.Threading.Tasks;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace GreatWall.Apis.Systems {
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

        /// <summary>
        /// 获取全部应用程序
        /// </summary>
        [HttpGet( "all" )]
        public async Task<IActionResult> GetAllAsync() {
            var result = await ApplicationService.GetAllAsync();
            return Success( result );
        }
    }
}