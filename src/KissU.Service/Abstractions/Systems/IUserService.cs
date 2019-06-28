using Util.Applications;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems {
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService : ICrudService<UserDto, UserQuery> {
    }
}