// <copyright file="IMenuService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Contracts.Abstractions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos.Responses;
    using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
    using Util.Applications;

    /// <summary>
    /// 菜单服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IMenuService : IService
    {
        /// <summary>
        /// 获取菜单
        /// </summary>
        [HttpGet(true)]
        Task<List<MenuResponse>> GetMenusAsync();
    }
}
