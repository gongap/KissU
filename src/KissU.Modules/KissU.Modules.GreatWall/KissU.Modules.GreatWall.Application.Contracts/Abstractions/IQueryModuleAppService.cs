using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Util.Ddd.Application.Trees;

namespace KissU.Modules.GreatWall.Application.Contracts.Abstractions
{
    /// <summary>
    /// 模块查询服务
    /// </summary>
    public interface IQueryModuleAppService : ITreeService<ModuleDto, ResourceQuery>
    {
    }
}