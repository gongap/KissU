using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Extensions;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util;
using KissU.Util.Applications;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleAppService : ServiceBase, IModuleAppService
    {
        /// <summary>
        /// 初始化模块服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="moduleRepository">模块仓储</param>
        public ModuleAppService(IGreatWallUnitOfWork unitOfWork, IModuleRepository moduleRepository)
        {
            UnitOfWork = unitOfWork;
            ModuleRepository = moduleRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; set; }

        /// <summary>
        /// 创建模块
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
        /// 修改模块
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