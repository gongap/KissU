using Util.Domains.Repositories;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Systems.Domain.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role> {
    }
}
