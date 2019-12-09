// <copyright file="ModuleService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Implements
{
    using System;
    using System.Threading.Tasks;
    using KissU.Modules.GreatWall.Data;
    using KissU.Modules.GreatWall.Domain.Repositories;
    using KissU.Modules.GreatWall.Service.Contracts.Abstractions;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos;
    using KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests;
    using KissU.Modules.GreatWall.Service.Extensions;
    using Util;
    using Util.Applications;
    using Util.Maps;

    /// <summary>
    ///     模块服务
    /// </summary>
    public class ModuleService : ServiceBase, IModuleService
    {
        /// <summary>
        ///     初始化模块服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="moduleRepository">模块仓储</param>
        public ModuleService(IGreatWallUnitOfWork unitOfWork, IModuleRepository moduleRepository)
        {
            UnitOfWork = unitOfWork;
            ModuleRepository = moduleRepository;
        }

        /// <summary>
        ///     工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        ///     模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; set; }

        /// <summary>
        ///     创建模块
        /// </summary>
        /// <param name="request">创建模块参数</param>
        public async Task<Guid> CreateAsync(CreateModuleRequest request)
        {
            var module = request.ToModule();
            module.CheckNull(nameof(module));
            module.Init();
            var parent = await ModuleRepository.FindAsync(module.ParentId);
            module.InitPath(parent);
            module.SortId =
                await ModuleRepository.GenerateSortIdAsync(module.ApplicationId.SafeValue(), module.ParentId);
            await ModuleRepository.AddAsync(module);
            await UnitOfWork.CommitAsync();
            return module.Id;
        }

        /// <summary>
        ///     修改模块
        /// </summary>
        /// <param name="request">模块参数</param>
        public async Task UpdateAsync(ModuleDto request)
        {
            var module = await ModuleRepository.FindAsync(request.Id.ToGuid());
            request.MapTo(module);
            module.InitPinYin();
            await ModuleRepository.UpdatePathAsync(module);
            await ModuleRepository.UpdateAsync(module);
            await UnitOfWork.CommitAsync();
        }
    }
}
