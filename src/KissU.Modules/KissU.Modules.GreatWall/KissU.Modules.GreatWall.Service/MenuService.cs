// <copyright file="IMenuService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos.Responses;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : IMenuService
    {
        /// <summary>
        /// 获取菜单
        /// </summary>
        public async Task<List<MenuResponse>> GetMenusAsync()
        {
            return null;
        }
    }
}
