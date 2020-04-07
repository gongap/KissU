using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Core.Maps;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util.Ddd.Application;
using KissU.Util.Ddd.Domain.Datas.Queries;
using KissU.Util.Ddd.Domain.Domains.Repositories;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleAppService : DeleteServiceBase<Role, RoleDto, RoleQuery>, IRoleAppService
    {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleRepository">角色仓储</param>
        /// <param name="roleManager">角色服务</param>
        public RoleAppService(IGreatWallUnitOfWork unitOfWork, IRoleRepository roleRepository, IRoleManager roleManager)
            : base(unitOfWork, roleRepository)
        {
            UnitOfWork = unitOfWork;
            RoleRepository = roleRepository;
            RoleManager = roleManager;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }

        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleManager RoleManager { get; set; }

        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns>Task&lt;List&lt;RoleDto&gt;&gt;.</returns>
        public async Task<List<RoleDto>> GetRolesAsync(Guid userId)
        {
            var result = await RoleRepository.GetRolesAsync(userId);
            return result.MapToList<RoleDto>();
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        public async Task<Guid> CreateAsync(CreateRoleRequest request)
        {
            var role = request.MapTo<Role>();
            await RoleManager.CreateAsync(role);
            await UnitOfWork.CommitAsync();
            return role.Id;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        /// <returns>Task.</returns>
        public async Task UpdateAsync(UpdateRoleRequest request)
        {
            var entity = await RoleRepository.FindAsync(request.Id.ToGuid());
            request.MapTo(entity);
            await RoleManager.UpdateAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        /// <returns>Task.</returns>
        public async Task AddUsersToRoleAsync(UserRoleRequest request)
        {
            await RoleManager.AddUsersToRoleAsync(request.RoleId, request.UserIds.ToGuidList());
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        /// <returns>Task.</returns>
        public async Task RemoveUsersFromRoleAsync(UserRoleRequest request)
        {
            await RoleManager.RemoveUsersFromRoleAsync(request.RoleId, request.UserIds.ToGuidList());
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        /// <returns>IQueryBase&lt;Role&gt;.</returns>
        protected override IQueryBase<Role> CreateQuery(RoleQuery param)
        {
            return new Query<Role>(param)
                .WhereIfNotEmpty(t => t.Code.Contains(param.Code))
                .WhereIfNotEmpty(t => t.Name.Contains(param.Name))
                .WhereIfNotEmpty(t => t.Type.Contains(param.Type))
                .WhereIfNotEmpty(t => t.IsAdmin == param.IsAdmin)
                .WhereIfNotEmpty(t => t.Enabled == param.Enabled);
        }
    }
}