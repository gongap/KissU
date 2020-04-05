using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 角色服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IRoleService : IServiceKey
    {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>Task&lt;RoleDto&gt;.</returns>
        [HttpGet(true)]
        Task<RoleDto> GetByIdAsync(string id);

        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task&lt;List&lt;RoleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<RoleDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns>Task&lt;List&lt;RoleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<RoleDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;List&lt;RoleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<RoleDto>> QueryAsync(RoleQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>Task&lt;PagerList&lt;RoleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<PagerList<RoleDto>> PagerQueryAsync(RoleQuery parameter);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>Task&lt;List&lt;RoleDto&gt;&gt;.</returns>
        Task<List<RoleDto>> GetRolesAsync(Guid userId);

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        Task<Guid> CreateAsync(CreateRoleRequest request);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        /// <returns>Task.</returns>
        Task UpdateAsync(UpdateRoleRequest request);

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        /// <returns>Task.</returns>
        Task AddUsersToRoleAsync(UserRoleRequest request);

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        /// <returns>Task.</returns>
        Task RemoveUsersFromRoleAsync(UserRoleRequest request);
    }
}