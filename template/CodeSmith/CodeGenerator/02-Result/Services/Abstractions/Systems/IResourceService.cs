using Util.Applications.Trees;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;

namespace GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// 资源服务
    /// </summary>
    public interface IResourceService : ITreeService<ResourceDto, ResourceQuery> {
    }
}