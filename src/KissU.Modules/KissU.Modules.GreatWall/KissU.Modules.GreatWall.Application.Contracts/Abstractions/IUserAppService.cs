using System;
using System.Threading.Tasks;
using KissU.Core.Aspects;
using KissU.Core.Validations.Aspects;
using KissU.Modules.GreatWall.Application.Contracts.Dtos;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Util.Ddd.Application.Contracts;

namespace KissU.Modules.GreatWall.Application.Contracts.Abstractions
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserAppService : IDeleteService<UserDto, UserQuery>
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        Task<Guid> CreateAsync([NotNull] [Valid] CreateUserRequest request);
    }
}