// <copyright file="RoleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : IRoleService
    {
        public async Task<RoleDto> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDto>> GetByIdsAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDto>> QueryAsync(RoleQuery parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<PagerList<RoleDto>> PagerQueryAsync(RoleQuery parameter)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDto>> GetRolesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> CreateAsync(CreateRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task AddUsersToRoleAsync(UserRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveUsersFromRoleAsync(UserRoleRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
