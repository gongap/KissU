using Surging.Core.ProxyGenerator;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System;
using System.Linq;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Datas.Ef;
using KissU.IModuleServices.QuickStart;
using KissU.IModuleServices.QuickStart.Dtos;
using KissU.IModuleServices.QuickStart.Queries;
using KissU.Modules.QuickStart.Infrastructure;
using KissU.Modules.QuickStart.Domain.Models;
using KissU.Modules.QuickStart.Domain.Repositories;
using GreatWall.Service.Dtos.Requests;
using GreatWall.Service.Queries;

namespace KissU.Modules.QuickStart.Application.Implements.Systems
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserManageService : ProxyServiceBase, IUserManageService
    {
        private readonly IUserService _service;

        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="service"></param>
        public UserManageService(IUserService service)
        {
            _service = service;
        }

        public Task<UserDto> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagerList<UserDto>> PagerQuery(UserQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> Query(UserQuery query)
        {
            return await _service.QueryAsync(query);
        }

        public Task<Guid> Create(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string ids)
        {
            throw new NotImplementedException();
        }
    }
}