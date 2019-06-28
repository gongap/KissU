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
using KissU.Service.Dtos.Systems.Extensions;

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
        public ApiService(IKissUUnitOfWork unitOfWork, IApiRepository apiRepository)
            : base(unitOfWork, apiRepository)
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
        protected override IQueryBase<Api> CreateQuery(ApiQuery param)
        {
            return new Query<Api>(param);
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ApiDto ToDto(Api entity)
        {
            return entity.ToDto2();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="request">参数</param>
        protected override Api ToEntity(ApiDto request)
        {
            return request.ToEntity2();
        }
    }
}