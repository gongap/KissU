// <copyright file="IClaimRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    using KissU.Modules.GreatWall.Domain.Models;
    using Util.Domains.Repositories;

    /// <summary>
    /// 声明仓储
    /// </summary>
    public interface IClaimRepository : IRepository<Claim>
    {
    }
}
