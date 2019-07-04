using Util.Applications;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;

namespace KissU.GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService : ICrudService<UserDto, UserQuery> {
    }
}