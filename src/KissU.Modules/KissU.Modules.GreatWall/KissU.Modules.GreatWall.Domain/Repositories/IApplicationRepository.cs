// <copyright file="IApplicationRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Domain.Models;

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
