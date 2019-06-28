using Util.Domains.Repositories;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role> {
    }
}
