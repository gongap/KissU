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
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KissU.Service.Dtos.Systems.Extensions;
using System.Threading.Tasks;
using Util.Domains;

namespace KissU.Service.Implements.Systems 
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public class ApiService : CrudServiceBase<Api, ApiDto, ApiQuery>, IApiService 
	{
        /// <summary>
        /// 初始化Api资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiRepository">Api资源仓储</param>
        public ApiService( IKissUUnitOfWork unitOfWork, IApiRepository apiRepository )
            : base( unitOfWork, apiRepository ) 
		{
            ApiRepository = apiRepository;
        }
        
        /// <summary>
        /// Api资源仓储
        /// </summary>
        public IApiRepository ApiRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Api> CreateQuery( ApiQuery param ) 
		{
            return new Query<Api>( param );
        }

        protected override Task UpdateAfterAsync(Api entity, ChangeValueCollection changeValues)
        {
            return base.UpdateAfterAsync(entity, changeValues);
        }

        protected override Api ToEntity(ApiDto request)
        {
            return request.ToEntity2();
        }

        protected override ApiDto ToDto(Api entity)
        {
            return entity.ToDto2();
        }

        protected override IQueryable<Api> Filter(IQueryable<Api> queryable, ApiQuery parameter)
        {
            return base.Filter(queryable, parameter).Include(x=>x.ApiScopes);
        }
    }
}