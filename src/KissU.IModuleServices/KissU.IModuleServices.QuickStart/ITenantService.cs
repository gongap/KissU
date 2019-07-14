using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using Surging.Core.Caching;
using Surging.Core.System.Intercept;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domains.Repositories;
using KissU.IModuleServices.QuickStart.Dtos;
using KissU.IModuleServices.QuickStart.Queries;

namespace KissU.IModuleServices.QuickStart
{

    [ServiceBundle("api/{Service}")]
    public interface ITenantService : IServiceKey
    {
        /// <summary>
        /// 获取全部
        /// </summary>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;", RequestCacheEnabled = true)]
        [InterceptMethod(CachingMethod.Get, Key = "GetTenantAll", CacheSectionType = SectionType.ddlCache, Mode = CacheTargetType.Redis, Time = 480)]
        Task<List<TenantDto>> GetAll();

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        Task<TenantDto> GetById(string id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task<List<TenantDto>> GetByIds(string ids);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        Task<List<TenantDto>> Query(TenantQuery parameter);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        Task<PagerList<TenantDto>> PagerQuery(TenantQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        Task<string> Create(TenantCreateRequest request);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        Task Update(TenantUpdateRequest request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task Delete(string ids);
    }
}
