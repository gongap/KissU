// <copyright file="IPermissionService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 权限服务
    /// </summary>
    public class PermissionService : IPermissionService
    {
        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        public async Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query)
        {
            return null;
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        public async Task SaveAsync(SavePermissionRequest request)
        {
        }
    }
}
