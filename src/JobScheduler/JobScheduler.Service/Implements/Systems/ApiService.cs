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
using JobScheduler.Service.Dtos.Systems.Extensions;
using System;

namespace JobScheduler.Service.Implements.Systems
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public class ApiService : CrudServiceBase<Api, ApiDto, ApiUpdateRequest, ApiCreateRequest, ApiUpdateRequest, ApiQuery, Guid>, IApiService
    {
        /// <summary>
        /// 初始化Api资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="apiRepository">Api资源仓储</param>
        public ApiService(IJobSchedulerUnitOfWork unitOfWork, IApiRepository apiRepository)
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
            var query = new Query<Api>(param);
            query.WhereIfNotEmpty(x => x.Name.Contains(param.Keyword));
            return query;
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
        /// 创建参数转换为实体
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns></returns>
        protected override Api ToEntityFromCreateRequest(ApiCreateRequest request)
        {
            //return base.ToEntityFromCreateRequest(request);
            return request.ToEntityFromCreateRequest();
        }

        /// <summary>
        /// 修改参数转换为实体
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns></returns>
        protected override Api ToEntityFromUpdateRequest(ApiUpdateRequest request)
        {
            //return base.ToEntityFromUpdateRequest(request);
            return request.ToEntityFromUpdateRequest();
        }
    }
}