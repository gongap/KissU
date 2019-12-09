// <copyright file="ModuleRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using KissU.Modules.GreatWall.Data.Pos;
    using KissU.Modules.GreatWall.Data.Pos.Extensions;
    using KissU.Modules.GreatWall.Data.Stores.Abstractions;
    using KissU.Modules.GreatWall.Domain.Models;
    using KissU.Modules.GreatWall.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Util;
    using Util.Datas.Ef.Core;

    /// <summary>
    /// 模块仓储
    /// </summary>
    public class ModuleRepository : TreeCompactRepositoryBase<Module, ResourcePo>, IModuleRepository
    {
        /// <summary>
        /// 资源存储器
        /// </summary>
        private readonly IResourcePoStore _store;

        /// <summary>
        /// 初始化模块仓储
        /// </summary>
        /// <param name="store">资源存储器</param>
        public ModuleRepository(IResourcePoStore store) : base(store)
        {
            _store = store;
        }

        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Module ToEntity(ResourcePo po)
        {
            return po.ToModule();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourcePo ToPo(Module entity)
        {
            return entity.ToPo();
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="parentId">父标识</param>
        public async Task<int> GenerateSortIdAsync(Guid applicationId, Guid? parentId)
        {
            var maxSortId = await _store.Find(t => t.ApplicationId == applicationId && t.ParentId == parentId)
                .MaxAsync(t => t.SortId);
            return maxSortId.SafeValue() + 1;
        }

        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleIds">角色标识列表</param>
        public async Task<List<Module>> GetModulesAsync(Guid applicationId, List<Guid> roleIds)
        {
            var pos = await _store.GetModulesAsync(applicationId, roleIds);
            return pos.Select(ToEntity).ToList();
        }
    }
}
