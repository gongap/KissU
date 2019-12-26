using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserAppService : IDeleteService<UserDto, UserQuery> {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        Task<Guid> CreateAsync( [NotNull] [Valid] CreateUserRequest request );
    }
}