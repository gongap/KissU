﻿using System;
using System.Threading.Tasks;
using GreatWall.Data;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Domain.Services.Abstractions;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Dtos.Requests;
using GreatWall.Service.Queries;
using Util;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Maps;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : DeleteServiceBase<Role, RoleDto, RoleQuery>, IRoleService {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleRepository">角色仓储</param>
        /// <param name="roleManager">角色服务</param>
        public RoleService( IGreatWallUnitOfWork unitOfWork, IRoleRepository roleRepository, IRoleManager roleManager )
            : base( unitOfWork, roleRepository ) {
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
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Role> CreateQuery( RoleQuery param ) {
            return new Query<Role>( param )
                .WhereIfNotEmpty( t => t.Code.Contains( param.Code ) )
                .WhereIfNotEmpty( t => t.Name.Contains( param.Name ) )
                .WhereIfNotEmpty( t => t.Type.Contains( param.Type ) )
                .WhereIfNotEmpty( t => t.IsAdmin == param.IsAdmin )
                .WhereIfNotEmpty( t => t.Enabled == param.Enabled );
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        public async Task<Guid> CreateAsync( CreateRoleRequest request ) {
            var role = request.MapTo<Role>();
            await RoleManager.CreateAsync( role );
            await UnitOfWork.CommitAsync();
            return role.Id;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        public async Task UpdateAsync( UpdateRoleRequest request ) {
            var entity = await RoleRepository.FindAsync( request.Id.ToGuid() );
            request.MapTo( entity );
            await RoleManager.UpdateAsync( entity );
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        public async Task AddUsersToRoleAsync( UserRoleRequest request ) {
            await RoleManager.AddUsersToRoleAsync( request.RoleId, request.UserIds.ToGuidList() );
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        public async Task RemoveUsersFromRoleAsync( UserRoleRequest request ) {
            await RoleManager.RemoveUsersFromRoleAsync( request.RoleId, request.UserIds.ToGuidList() );
            await UnitOfWork.CommitAsync();
        }
    }
}