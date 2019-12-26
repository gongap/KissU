// <copyright file="UserService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
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

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : IUserService
    {
        public async Task<UserDto> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetByIdsAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> QueryAsync(UserQuery parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<PagerList<UserDto>> PagerQueryAsync(UserQuery parameter)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> CreateAsync(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
