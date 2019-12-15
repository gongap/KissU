// <copyright file="IClaimRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    using KissU.Modules.GreatWall.Domain.Models;

    /// <summary>
    /// 声明仓储
    /// </summary>
    public interface IClaimRepository : IRepository<Claim>
    {
    }
}
