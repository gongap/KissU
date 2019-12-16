// <copyright file="QueryModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Linq;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Stores.Abstractions;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Shared.Enums;
using KissU.Modules.GreatWall.Service.Contracts.Abstractions;
using KissU.Modules.GreatWall.Service.Contracts.Dtos;
using KissU.Modules.GreatWall.Service.Contracts.Queries;
using KissU.Modules.GreatWall.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using KissU.Util.Applications.Trees;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public class QueryModuleService : TreeServiceBase<ResourcePo, ModuleDto, ResourceQuery>, IQueryModuleService
    {
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="resourceStore">资源存储器</param>
        /// <param name="moduleRepository">模块仓储</param>
        public QueryModuleService(IGreatWallUnitOfWork unitOfWork, IResourcePoStore resourceStore,
            IModuleRepository moduleRepository)
            : base(unitOfWork, resourceStore)
        {
            UnitOfWork = unitOfWork;
            ResourceStore = resourceStore;
            ModuleRepository = moduleRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 资源存储器
        /// </summary>
        public IResourcePoStore ResourceStore { get; set; }

        /// <summary>
        /// 模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ResourcePo> CreateQuery(ResourceQuery param)
        {
            return new Query<ResourcePo>(param)
                .Where(t => t.Type == ResourceType.Module)
                .Where(t => t.ApplicationId == param.ApplicationId)
                .WhereIfNotEmpty(t => t.Name.Contains(param.Name))
                .WhereIfNotEmpty(t => t.Uri.Contains(param.Uri));
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<ResourcePo> Filter(IQueryable<ResourcePo> queryable, ResourceQuery parameter)
        {
            return base.Filter(queryable, parameter).Include(t => t.Application).Include(t => t.Parent);
        }

        /// <summary>
        /// 转成数据传输对象
        /// </summary>
        protected override ModuleDto ToDto(ResourcePo po)
        {
            return po.ToModuleDto();
        }
    }
}
