using Util.Domains.Repositories;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Systems.Domain.Repositories {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public interface IResourceRepository : ICompactRepository<Resource> {
    }
}