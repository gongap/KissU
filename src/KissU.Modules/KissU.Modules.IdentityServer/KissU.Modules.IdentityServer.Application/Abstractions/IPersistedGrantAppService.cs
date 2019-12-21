// <copyright file="IPersistedGrantService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.IdentityServer.Application.Abstractions
{
    /// <summary>
    /// 认证操作数据服务
    /// </summary>
    public interface IPersistedGrantAppService : IDeleteService<PersistedGrantDto, PersistedGrantQuery>
    {
    }
}
