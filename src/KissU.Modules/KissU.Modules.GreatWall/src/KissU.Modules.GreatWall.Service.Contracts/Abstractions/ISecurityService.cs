﻿// <copyright file="ISecurityService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.GreatWall.Service.Contracts.Abstractions
{
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Domain.Shared.Results;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests;
    using Util.Applications;
    using Util.Aspects;
    using Util.Validations.Aspects;

    /// <summary>
    /// 安全服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ISecurityService : IService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        [HttpPost(true)]
        Task<SignInResult> SignInAsync([NotNull] [Valid] LoginRequest request);

        /// <summary>
        /// 退出登录
        /// </summary>
        [HttpGet(true)]
        Task SignOutAsync();
    }
}
