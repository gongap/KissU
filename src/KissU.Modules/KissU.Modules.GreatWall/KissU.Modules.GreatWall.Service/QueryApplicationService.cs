// <copyright file="QueryApplicationService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Applications.Operations;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 应用程序查询服务
    /// </summary>
    public class QueryApplicationService : IQueryApplicationService
    {
        public ApplicationDto GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public List<ApplicationDto> GetByIds(string ids)
        {
            throw new System.NotImplementedException();
        }

        async Task<ApplicationDto> IGetByIdAsync<ApplicationDto>.GetByIdAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        async Task<List<ApplicationDto>> IQueryApplicationService.GetByIdsAsync(string ids)
        {
            throw new System.NotImplementedException();
        }

        async Task<List<ApplicationDto>> IQueryApplicationService.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        async Task<List<ApplicationDto>> IQueryApplicationService.QueryAsync(ApplicationQuery parameter)
        {
            throw new System.NotImplementedException();
        }

        async Task<PagerList<ApplicationDto>> IQueryApplicationService.PagerQueryAsync(ApplicationQuery parameter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationDto> GetByCodeAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        async Task<ApplicationDto> IQueryApplicationService.GetByIdAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        async Task<List<ApplicationDto>> IGetByIdAsync<ApplicationDto>.GetByIdsAsync(string ids)
        {
            throw new System.NotImplementedException();
        }

        public List<ApplicationDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        async Task<List<ApplicationDto>> IGetAllAsync<ApplicationDto>.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public List<ApplicationDto> Query(ApplicationQuery parameter)
        {
            throw new System.NotImplementedException();
        }

        public PagerList<ApplicationDto> PagerQuery(ApplicationQuery parameter)
        {
            throw new System.NotImplementedException();
        }

        async Task<List<ApplicationDto>> IPageQueryAsync<ApplicationDto, ApplicationQuery>.QueryAsync(ApplicationQuery parameter)
        {
            throw new System.NotImplementedException();
        }

        async Task<PagerList<ApplicationDto>> IPageQueryAsync<ApplicationDto, ApplicationQuery>.PagerQueryAsync(ApplicationQuery parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}
