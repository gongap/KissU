using Util.Domains.Trees;
using JobScheduler.Domain.Systems.Models;

namespace JobScheduler.Domain.Systems.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role> {
    }
}
