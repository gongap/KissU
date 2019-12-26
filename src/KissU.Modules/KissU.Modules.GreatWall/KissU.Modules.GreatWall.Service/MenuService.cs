// <copyright file="MenuService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos.Responses;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util;
using KissU.Util.Applications;
using KissU.Util.Security;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : IMenuService
    {
        public async Task<List<MenuResponse>> GetMenusAsync()
        {
            throw new NotImplementedException();
        }
    }
}
