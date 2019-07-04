using Util.Applications.Trees;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;

namespace GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleService : ITreeService<RoleDto, RoleQuery> {
    }
}