using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.GreatWall.Data;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;
using KissU.GreatWall.Service.Abstractions.Systems;
using KissU.GreatWall.Data.Pos.Systems;
using KissU.GreatWall.Data.Stores.Abstractions.Systems;

namespace KissU.GreatWall.Service.Implements.Systems {
    /// <summary>
    /// Api资源服务
    /// </summary>
    public class ApiService : CrudServiceBase<ApiPo, ApiDto, ApiQuery>, IApiService {
        /// <summary>
        /// 初始化Api资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiStore">Api资源存储器</param>
        public ApiService( IKissUUnitOfWork unitOfWork, IApiPoStore apiStore )
            : base( unitOfWork, apiStore ) {
            ApiStore = apiStore;
        }
        
        /// <summary>
        /// Api资源存储器
        /// </summary>
        public IApiPoStore ApiStore { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ApiPo> CreateQuery( ApiQuery param ) {
            return new Query<ApiPo>( param );
        }
    }
}