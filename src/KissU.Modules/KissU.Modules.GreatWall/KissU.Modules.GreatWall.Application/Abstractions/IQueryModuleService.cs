using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications.Trees;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public interface IQueryModuleService : ITreeService<ModuleDto, ResourceQuery> {
    }
}