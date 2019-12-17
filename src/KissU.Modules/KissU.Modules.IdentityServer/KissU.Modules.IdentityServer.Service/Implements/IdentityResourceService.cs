// <copyright file="IdentityResourceService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Linq;
using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain.Models.IdentityResourceAggregate;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.Shared;
using KissU.Modules.IdentityServer.Service.Contracts.Abstractions;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests;
using KissU.Modules.IdentityServer.Service.Contracts.Queries;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;
using KissU.Util.Exceptions;

namespace KissU.Modules.IdentityServer.Service.Implements
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class IdentityResourceService :
        CrudServiceBase<IdentityResource, IdentityResourceDto, IdentityResourceDto, IdentityResourceCreateRequest,
            IdentityResourceDto, IdentityResourceQuery, Guid>, IIdentityResourceService
    {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="identityResourceRepository">应用程序仓储</param>
        public IdentityResourceService(IIdentityServerUnitOfWork unitOfWork,
            IIdentityResourceRepository identityResourceRepository)
            : base(unitOfWork, identityResourceRepository)
        {
            IdentityResourceRepository = identityResourceRepository;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IIdentityResourceRepository IdentityResourceRepository { get; set; }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        protected override IQueryBase<IdentityResource> CreateQuery(IdentityResourceQuery param)
        {
            var query = new Query<IdentityResource>(param).Or(t => t.Name.Contains(param.Keyword),
                t => t.DisplayName.Contains(param.Keyword));

            if (param.Enabled.HasValue)
            {
                query.And(t => t.Enabled == param.Enabled.Value);
            }

            if (string.IsNullOrWhiteSpace(param.Order))
            {
                query.OrderBy(x => x.CreationTime, true);
            }

            return query;
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected override void CreateBefore(IdentityResource entity)
        {
            base.CreateBefore(entity);
            if (IdentityResourceRepository.Exists(t => t.Name == entity.Name))
            {
                ThrowDuplicateNameException(entity.Name);
            }
        }

        /// <summary>
        /// 抛出Name重复异常
        /// </summary>
        private void ThrowDuplicateNameException(string name)
        {
            throw new Warning(string.Format("名称{0} 重复", name));
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore(IdentityResource entity)
        {
            base.UpdateBefore(entity);
            if (IdentityResourceRepository.Exists(t => t.Id != entity.Id && t.Name == entity.Name))
            {
                ThrowDuplicateNameException(entity.Name);
            }
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<IdentityResource> Filter(IQueryable<IdentityResource> queryable,
            IdentityResourceQuery parameter)
        {
            return base.Filter(queryable, parameter);
        }
    }
}
