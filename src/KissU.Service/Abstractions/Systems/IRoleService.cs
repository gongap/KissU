using Util.Applications.Trees;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleService : ITreeService<RoleDto, RoleQuery> {
    }
}