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
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using GreatWall.Service.Dtos.Requests;

namespace KissU.IModuleServices.GreatWall
{

    [ServiceBundle("api/{Service}")]
    public interface IUserManageService : IServiceKey
    {
        /// <summary>
        /// 获取单个实例
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer/1 
        /// </remarks>
        /// <param name="id">标识</param>
        [ServiceRoute("{id}")]
        Task<UserDto> Get(string id);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer?name=a
        /// </remarks>
        /// <param name="query">查询参数</param>
        Task<PagerList<UserDto>> PagerQuery(UserQuery query);

        /// <summary>
        /// 查询
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer/query?name=a
        /// </remarks>
        /// <param name="query">查询参数</param>
        Task<List<UserDto>> Query(UserQuery query);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        Task<Guid> Create(CreateUserRequest request);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids">标识列表，多个Id用逗号分隔，范例：1,2,3</param>
        Task Delete(string ids);
    }
}
