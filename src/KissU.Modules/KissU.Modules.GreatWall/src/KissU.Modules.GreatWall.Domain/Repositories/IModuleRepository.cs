// <copyright file="IModuleRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Domain.Models;
    using Util.Domains.Trees;

    /// <summary>
    /// 模块仓储
    /// </summary>
    public interface IModuleRepository : ITreeCompactRepository<Module>
    {
        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="parentId">父标识</param>
        Task<int> GenerateSortIdAsync(Guid applicationId, Guid? parentId);

        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleIds">角色标识列表</param>
        Task<List<Module>> GetModulesAsync(Guid applicationId, List<Guid> roleIds);
    }
}
