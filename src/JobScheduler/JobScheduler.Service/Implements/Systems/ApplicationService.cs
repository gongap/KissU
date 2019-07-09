using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using JobScheduler.Data;
using JobScheduler.Domain.Systems.Models;
using JobScheduler.Domain.Systems.Repositories;
using JobScheduler.Service.Dtos.Systems;
using JobScheduler.Service.Queries.Systems;
using JobScheduler.Service.Abstractions.Systems;

namespace JobScheduler.Service.Implements.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<Application, ApplicationDto, ApplicationQuery>, IApplicationService {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        public ApplicationService( IJobSchedulerUnitOfWork unitOfWork, IApplicationRepository applicationRepository )
            : base( unitOfWork, applicationRepository ) {
            ApplicationRepository = applicationRepository;
        }
        
        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IApplicationRepository ApplicationRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Application> CreateQuery( ApplicationQuery param ) {
            return new Query<Application>( param );
        }
    }
}