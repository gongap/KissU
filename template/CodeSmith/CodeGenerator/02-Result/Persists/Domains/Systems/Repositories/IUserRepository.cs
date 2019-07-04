using Util.Domains.Repositories;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Systems.Domain.Repositories {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : ICompactRepository<User> {
    }
}