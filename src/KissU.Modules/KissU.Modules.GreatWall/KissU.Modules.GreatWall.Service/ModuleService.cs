// <copyright file="ModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleService : IModuleService
    {
        public async Task<Guid> CreateAsync(CreateModuleRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ModuleDto request)
        {
            throw new NotImplementedException();
        }
    }
}
