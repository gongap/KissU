using System;
using System.Threading.Tasks;
using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Dtos.Requests;
using KissU.GreatWall.Service.Queries;
using Util.Applications;
using Util.Aspects;
using Util.Validations.Aspects;

namespace KissU.GreatWall.Service.Abstractions {
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService : IDeleteService<UserDto, UserQuery> {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        Task<Guid> CreateAsync( [NotNull] [Valid] CreateUserRequest request );
    }
}