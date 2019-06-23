using Util.Domains.Trees;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Repositories {
    /// <summary>
    /// 菜单仓储
    /// </summary>
    public interface IMenuRepository : ITreeRepository<Menu> {
    }
}