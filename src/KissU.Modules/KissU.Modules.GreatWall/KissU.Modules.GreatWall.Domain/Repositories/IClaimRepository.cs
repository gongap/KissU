// <copyright file="IClaimRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;
using KissU.Modules.GreatWall.Domain.Models;

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    /// <summary>
    /// 声明仓储
    /// </summary>
    public interface IClaimRepository : IRepository<Claim>
    {
    }
}
