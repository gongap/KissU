using Util.Applications.Trees;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems {
    /// <summary>
    /// 菜单服务
    /// </summary>
    public interface IMenuService : ITreeService<MenuDto, MenuQuery> {
    }
}