using System;
using System.Threading.Tasks;
using KissU.GreatWall.Data;
using KissU.GreatWall.Domain.Repositories;
using KissU.GreatWall.Service.Abstractions;
using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Dtos.Extensions;
using KissU.GreatWall.Service.Dtos.Requests;
using Util;
using Util.Applications;
using Util.Maps;

namespace KissU.GreatWall.Service.Implements {
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleService : ServiceBase, IModuleService {
        /// <summary>
        /// 初始化模块服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="moduleRepository">模块仓储</param>
        public ModuleService( IGreatWallUnitOfWork unitOfWork, IModuleRepository moduleRepository ) {
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
        public async Task<Guid> CreateAsync( CreateModuleRequest request ) {
            var module = request.ToModule();
            module.CheckNull( nameof( module ) );
            module.Init();
            var parent = await ModuleRepository.FindAsync( module.ParentId );
            module.InitPath( parent );
            module.SortId = await ModuleRepository.GenerateSortIdAsync( module.ApplicationId.SafeValue(), module.ParentId );
            await ModuleRepository.AddAsync( module );
            await UnitOfWork.CommitAsync();
            return module.Id;
        }

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="request">模块参数</param>
        public async Task UpdateAsync( ModuleDto request ) {
            var module = await ModuleRepository.FindAsync( request.Id.ToGuid() );
            request.MapTo( module );
            module.InitPinYin();
            await ModuleRepository.UpdatePathAsync( module );
            await ModuleRepository.UpdateAsync( module );
            await UnitOfWork.CommitAsync();
        }
    }
}