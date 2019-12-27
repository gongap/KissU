// <copyright file="IModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleService : IModuleService
    {
        private readonly IModuleAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        public ModuleService(IModuleAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="request">创建模块参数</param>
        public async Task<Guid> CreateAsync(CreateModuleRequest request)
        {
            return await _appService.CreateAsync(request);
        }

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="request">模块参数</param>
        public async Task UpdateAsync(ModuleDto request)
        {
            await _appService.UpdateAsync(request);
        }
    }
}
