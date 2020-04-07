using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Ioc;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 用户服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IServiceKey
    {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;UserDto&gt;.</returns>
        [HttpGet(true)]
        Task<UserDto> GetByIdAsync(string id);

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;UserDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<UserDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;UserDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<UserDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;UserDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<UserDto>> QueryAsync(UserQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;UserDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<PagerList<UserDto>> PagerQueryAsync(UserQuery parameter);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        [HttpPost(true)]
        Task<Guid> CreateAsync(CreateUserRequest request);
    }
}