// <copyright file="ISecurityService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 安全服务
    /// </summary>
    public class SecurityService : ISecurityService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        public async Task<SignInResult> SignInAsync(LoginRequest request)
        {
            return null;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public async Task SignOutAsync()
        {
        }
    }
}
