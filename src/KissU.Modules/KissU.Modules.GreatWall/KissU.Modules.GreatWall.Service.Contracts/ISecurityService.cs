// <copyright file="ISecurityService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service.Contracts
{
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
