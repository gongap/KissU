using Util.Domains.Repositories;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Systems.Domain.Repositories {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public interface IResourceRepository : ICompactRepository<Resource> {
    }
}