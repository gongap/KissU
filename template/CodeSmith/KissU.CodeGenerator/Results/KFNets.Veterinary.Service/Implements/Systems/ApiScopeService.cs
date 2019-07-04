using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KFNets.Veterinary.Data;
using KFNets.Veterinary.Domain.Systems.Models;
using KFNets.Veterinary.Domain.Systems.Repositories;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Queries.Systems;
using KFNets.Veterinary.Service.Abstractions.Systems;

namespace KFNets.Veterinary.Service.Implements.Systems {
    /// <summary>
    /// Api许可范围服务
    /// </summary>
    public class ApiScopeService : CrudServiceBase<ApiScope, ApiScopeDto, ApiScopeQuery>, IApiScopeService {
        /// <summary>
        /// 初始化Api许可范围服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiScopeRepository">Api许可范围仓储</param>
        public ApiScopeService( IKFNetsUnitOfWork unitOfWork, IApiScopeRepository apiScopeRepository )
            : base( unitOfWork, apiScopeRepository ) {
            ApiScopeRepository = apiScopeRepository;
        }
        
        /// <summary>
        /// Api许可范围仓储
        /// </summary>
        public IApiScopeRepository ApiScopeRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ApiScope> CreateQuery( ApiScopeQuery param ) {
            return new Query<ApiScope>( param );
        }
    }
}