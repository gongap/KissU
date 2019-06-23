using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.Data;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;
using KissU.Data.Pos.Systems;
using KissU.Data.Stores.Abstractions.Systems;

namespace KissU.Service.Implements.Systems 
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<ApplicationPo, ApplicationDto, ApplicationQuery>, IApplicationService 
	{
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationStore">应用程序存储器</param>
        public ApplicationService( IKissUUnitOfWork unitOfWork, IApplicationPoStore applicationStore )
            : base( unitOfWork, applicationStore ) 
		{
            ApplicationStore = applicationStore;
        }
        
        /// <summary>
        /// 应用程序存储器
        /// </summary>
        public IApplicationPoStore ApplicationStore { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ApplicationPo> CreateQuery( ApplicationQuery param ) 
		{
            return new Query<ApplicationPo>( param );
        }
    }
}