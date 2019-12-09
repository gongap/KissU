// <copyright file="IApplicationRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    using KissU.Modules.GreatWall.Domain.Models;
    using Util.Domains.Repositories;

    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : ICompactRepository<Application>
    {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        Task<Application> GetByCodeAsync(string code);
    }
}
