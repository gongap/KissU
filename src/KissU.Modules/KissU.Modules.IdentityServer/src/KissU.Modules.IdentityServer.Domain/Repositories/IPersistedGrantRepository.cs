// <copyright file="IPersistedGrantRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;
    using Util.Domains.Repositories;

    /// <summary>
    ///     认证操作数据仓储
    /// </summary>
    public interface IPersistedGrantRepository : IRepository<PersistedGrant>
    {
    }
}
