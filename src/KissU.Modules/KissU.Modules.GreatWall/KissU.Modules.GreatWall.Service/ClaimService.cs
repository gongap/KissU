// <copyright file="ClaimService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 声明服务
    /// </summary>
    public class ClaimService : IClaimService
    {
        public async Task<ClaimDto> GetByIdAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ClaimDto>> GetByIdsAsync(string ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ClaimDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ClaimDto>> QueryAsync(ClaimQuery parameter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagerList<ClaimDto>> PagerQueryAsync(ClaimQuery parameter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> CreateAsync(ClaimDto request)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(ClaimDto request)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(string ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
