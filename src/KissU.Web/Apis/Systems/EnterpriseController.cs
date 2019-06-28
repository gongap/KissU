using Util.Webs.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems 
{
    /// <summary>
    /// 企业控制器
    /// </summary>
    public class EnterpriseController : CrudControllerBase<EnterpriseDto, EnterpriseQuery> 
	{
        
        /// <summary>
        /// 初始化企业控制器
        /// </summary>
		/// <param name="service">企业服务</param>
        public EnterpriseController( IEnterpriseService service ) : base( service ) 
		{
            EnterpriseService = service;
        }

        /// <summary>
        /// 企业服务
        /// </summary>
        public IEnterpriseService EnterpriseService { get; }
    }
}