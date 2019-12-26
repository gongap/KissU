// <copyright file="QueryModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Shared.Enums;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications.Trees;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public class QueryModuleService : IQueryModuleService
    {
        public async Task<ModuleDto> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ModuleDto>> GetByIdsAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ModuleDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ModuleDto>> QueryAsync(ResourceQuery parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<PagerList<ModuleDto>> PagerQueryAsync(ResourceQuery parameter)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ModuleDto>> FindByIdsAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task EnableAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task DisableAsync(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task SwapSortAsync(Guid id, Guid swapId)
        {
            throw new NotImplementedException();
        }

        public async Task FixSortIdAsync(ResourceQuery parameter)
        {
            throw new NotImplementedException();
        }
    }
}
