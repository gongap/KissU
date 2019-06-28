using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.Data;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Service.Implements.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<Application, ApplicationDto, ApplicationQuery>, IApplicationService {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        public ApplicationService( IKissUUnitOfWork unitOfWork, IApplicationRepository applicationRepository )
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