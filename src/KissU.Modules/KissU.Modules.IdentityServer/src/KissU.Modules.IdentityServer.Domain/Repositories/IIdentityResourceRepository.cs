// <copyright file="IIdentityResourceRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    using KissU.Modules.IdentityServer.Domain.Models.IdentityResourceAggregate;
    using Util.Domains.Repositories;

    /// <summary>
    ///     身份资源仓储
    /// </summary>
    public interface IIdentityResourceRepository : IRepository<IdentityResource>
    {
    }
}
