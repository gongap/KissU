using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 模块服务
    /// </summary>
    public interface IModuleAppService : IService {
        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="request">创建模块参数</param>
        Task<Guid> CreateAsync( [NotNull] [Valid] CreateModuleRequest request );
        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="request">模块参数</param>
        Task UpdateAsync( [NotNull] [Valid] ModuleDto request );
    }
}