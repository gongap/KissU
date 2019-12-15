// <copyright file="IPermissionService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.GreatWall.Service.Contracts.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests;
    using KissU.Modules.GreatWall.Service.Contracts.Queries;
    using Util.Applications;

    /// <summary>
    /// 权限服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IPermissionService : IService
    {
        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        [HttpGet(true)]
        Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query);

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        [HttpPost(true)]
        Task SaveAsync(SavePermissionRequest request);
    }
}
