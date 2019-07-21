using System;
using System.Threading.Tasks;
using GreatWall.Service.Dtos;
using GreatWall.Service.Dtos.Requests;
using GreatWall.Service.Queries;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Util.Applications;
using Util.Aspects;
using Util.Validations.Aspects;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 用户服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IDeleteService<UserDto, UserQuery> {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        Task<Guid> CreateAsync( [NotNull] [Valid] CreateUserRequest request );
    }
}