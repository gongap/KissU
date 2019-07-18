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

namespace KissU.Modules.QuickStart.Application.Implements.Systems
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserManageService : ProxyServiceBase, IUserManageService
    {
        private readonly IUserService _service;

        /// <summary>
        /// 初始化租户服务
        /// </summary>
        /// <param name="service"></param>
        public UserManageService(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<UserDto>> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return entities;
        }
    }
}