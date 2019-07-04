using Util.Applications;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;

namespace GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService : ICrudService<UserDto, UserQuery> {
    }
}