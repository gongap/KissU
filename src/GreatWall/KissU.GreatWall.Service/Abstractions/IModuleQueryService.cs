using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Queries;
using Util.Applications.Trees;

namespace KissU.GreatWall.Service.Abstractions {
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public interface IModuleQueryService : ITreeService<ModuleDto, ResourceQuery> {
    }
}