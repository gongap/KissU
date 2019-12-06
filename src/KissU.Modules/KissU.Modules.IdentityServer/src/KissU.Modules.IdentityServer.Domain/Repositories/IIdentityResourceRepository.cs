﻿using KissU.Modules.IdentityServer.Domain.Models.IdentityResourceAggregate;
using Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public interface IIdentityResourceRepository : IRepository<IdentityResource>
    {

    }
}