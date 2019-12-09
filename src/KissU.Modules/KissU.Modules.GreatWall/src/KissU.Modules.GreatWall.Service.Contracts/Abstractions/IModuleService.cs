// <copyright file="IModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Contracts.Abstractions
{
    using System;
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests;
    using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
    using Util.Applications;
    using Util.Aspects;
    using Util.Validations.Aspects;

    /// <summary>
    /// 模块服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IModuleService : IService
    {
        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="request">创建模块参数</param>
        [HttpPost(true)]
        Task<Guid> CreateAsync([NotNull] [Valid] CreateModuleRequest request);

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="request">模块参数</param>
        [HttpPut(true)]
        Task UpdateAsync([NotNull] [Valid] ModuleDto request);
    }
}
