using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.GreatWall.Data;
using KissU.GreatWall.Systems.Domain.Models;
using KissU.GreatWall.Systems.Domain.Repositories;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;
using KissU.GreatWall.Service.Abstractions.Systems;

namespace KissU.GreatWall.Service.Implements.Systems {
    /// <summary>
    /// Api许可范围服务
    /// </summary>
    public class ApiScopeService : CrudServiceBase<ApiScope, ApiScopeDto, ApiScopeQuery>, IApiScopeService {
        /// <summary>
        /// 初始化Api许可范围服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiScopeRepository">Api许可范围仓储</param>
        public ApiScopeService( IKissUUnitOfWork unitOfWork, IApiScopeRepository apiScopeRepository )
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