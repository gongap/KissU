using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Service.Contracts.Dtos;
using KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Service.Contracts.Queries;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Util.Applications;
using Util.Aspects;
using Util.Domains.Repositories;
using Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service.Contracts.Abstractions
{
    /// <summary>
    /// 角色服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IRoleService : IService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        [HttpGet(true)]
        Task<RoleDto> GetByIdAsync(object id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpGet(true)]
        Task<List<RoleDto>> GetByIdsAsync(string ids);

        /// <summary>
        /// 获取全部
        /// </summary>
        [HttpGet(true)]
        Task<List<RoleDto>> GetAllAsync();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<List<RoleDto>> QueryAsync(RoleQuery parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        [HttpGet(true)]
        Task<PagerList<RoleDto>> PagerQueryAsync(RoleQuery parameter);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        [HttpPost(true)]
        Task DeleteAsync(string ids);

        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        [HttpGet(true)]
        Task<List<RoleDto>> GetRolesAsync(Guid userId);

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        [HttpPost(true)]
        Task<Guid> CreateAsync([NotNull] [Valid] CreateRoleRequest request);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        [HttpPut(true)]
        Task UpdateAsync([NotNull] [Valid] UpdateRoleRequest request);

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        [HttpPost(true)]
        Task AddUsersToRoleAsync(UserRoleRequest request);

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        [HttpPost(true)]
        Task RemoveUsersFromRoleAsync(UserRoleRequest request);
    }
}