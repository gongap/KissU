using Util.Domains.Repositories;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Systems.Domain.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role> {
    }
}
