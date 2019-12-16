// <copyright file="IPersistedGrantRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;
using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 认证操作数据仓储
    /// </summary>
    public interface IPersistedGrantRepository : IRepository<PersistedGrant>
    {
    }
}
