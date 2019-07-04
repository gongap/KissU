using Util.Domains.Repositories;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.Domain.Systems.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ICompactRepository<Role> {
    }
}