using Util.Domains.Trees;
using KissU.JobScheduler.Domain.Systems.Models;

namespace KissU.JobScheduler.Domain.Systems.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role> {
    }
}
