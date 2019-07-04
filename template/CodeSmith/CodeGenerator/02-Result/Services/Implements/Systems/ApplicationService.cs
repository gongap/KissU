using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using GreatWall.Data;
using GreatWall.Systems.Domain.Models;
using GreatWall.Systems.Domain.Repositories;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;
using GreatWall.Service.Abstractions.Systems;

namespace GreatWall.Service.Implements.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<Application, ApplicationDto, ApplicationQuery>, IApplicationService {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        public ApplicationService( IKissU.GreatWallUnitOfWork unitOfWork, IApplicationRepository applicationRepository )
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