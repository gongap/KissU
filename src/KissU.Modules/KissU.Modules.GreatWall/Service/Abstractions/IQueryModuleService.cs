using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications.Trees;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public interface IQueryModuleService : ITreeService<ModuleDto, ResourceQuery> {
    }
}