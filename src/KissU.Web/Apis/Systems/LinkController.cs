using Util.Webs.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems 
{
    /// <summary>
    /// 链接控制器
    /// </summary>
    public class LinkController : CrudControllerBase<LinkDto, LinkQuery> 
	{
        
        /// <summary>
        /// 初始化链接控制器
        /// </summary>
		/// <param name="service">链接服务</param>
        public LinkController( ILinkService service ) : base( service ) 
		{
            LinkService = service;
        }

        /// <summary>
        /// 链接服务
        /// </summary>
        public ILinkService LinkService { get; }
    }
}