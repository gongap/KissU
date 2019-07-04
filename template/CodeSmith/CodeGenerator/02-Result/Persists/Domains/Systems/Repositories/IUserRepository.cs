using Util.Domains.Repositories;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Systems.Domain.Repositories {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : ICompactRepository<User> {
    }
}