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
    /// 企业服务
    /// </summary>
    public class EnterpriseService : CrudServiceBase<Enterprise, EnterpriseDto, EnterpriseQuery>, IEnterpriseService {
        /// <summary>
        /// 初始化企业服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="enterpriseRepository">企业仓储</param>
        public EnterpriseService( IKissUUnitOfWork unitOfWork, IEnterpriseRepository enterpriseRepository )
            : base( unitOfWork, enterpriseRepository ) {
            EnterpriseRepository = enterpriseRepository;
        }
        
        /// <summary>
        /// 企业仓储
        /// </summary>
        public IEnterpriseRepository EnterpriseRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Enterprise> CreateQuery( EnterpriseQuery param ) {
            return new Query<Enterprise>( param );
        }
    }
}