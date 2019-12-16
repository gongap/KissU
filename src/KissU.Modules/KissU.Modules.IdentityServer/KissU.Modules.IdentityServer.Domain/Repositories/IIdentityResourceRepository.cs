// <copyright file="IIdentityResourceRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;
using KissU.Modules.IdentityServer.Domain.Models.IdentityResourceAggregate;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public interface IIdentityResourceRepository : IRepository<IdentityResource>
    {
    }
}
