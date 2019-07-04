using Util.Applications.Trees;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;

namespace KissU.GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// 资源服务
    /// </summary>
    public interface IResourceService : ITreeService<ResourceDto, ResourceQuery> {
    }
}