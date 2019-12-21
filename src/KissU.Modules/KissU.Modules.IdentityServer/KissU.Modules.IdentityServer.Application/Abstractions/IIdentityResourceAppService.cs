// <copyright file="IIdentityResourceService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Dtos.Requests;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.IdentityServer.Application.Abstractions
{
    /// <summary>
    /// 身份资源服务
    /// </summary>
    public interface IIdentityResourceAppService : ICrudService<IdentityResourceDto, IdentityResourceDto, IdentityResourceCreateRequest, IdentityResourceDto, IdentityResourceQuery>
    {
    }
}
