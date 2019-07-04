using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using GreatWall.Data;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;
using GreatWall.Service.Abstractions.Systems;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;

namespace GreatWall.Service.Implements.Systems {
    /// <summary>
    /// Api许可范围服务
    /// </summary>
    public class ApiScopeService : CrudServiceBase<ApiScopePo, ApiScopeDto, ApiScopeQuery>, IApiScopeService {
        /// <summary>
        /// 初始化Api许可范围服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiScopeStore">Api许可范围存储器</param>
        public ApiScopeService( IKissUUnitOfWork unitOfWork, IApiScopePoStore apiScopeStore )
            : base( unitOfWork, apiScopeStore ) {
            ApiScopeStore = apiScopeStore;
        }
        
        /// <summary>
        /// Api许可范围存储器
        /// </summary>
        public IApiScopePoStore ApiScopeStore { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ApiScopePo> CreateQuery( ApiScopeQuery param ) {
            return new Query<ApiScopePo>( param );
        }
    }
}