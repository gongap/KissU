// <copyright file="PermissionService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 权限服务
    /// </summary>
    public class PermissionService : IPermissionService
    {
        public async Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(SavePermissionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
