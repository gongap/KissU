using System;
using System.Threading.Tasks;
using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Dtos.Requests;
using Util.Applications;
using Util.Aspects;
using Util.Validations.Aspects;

namespace KissU.GreatWall.Service.Abstractions {
    /// <summary>
    /// 模块服务
    /// </summary>
    public interface IModuleService : IService {
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