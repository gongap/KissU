using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.GreatWall.Data;
using KissU.GreatWall.Systems.Domain.Models;
using KissU.GreatWall.Systems.Domain.Repositories;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;
using KissU.GreatWall.Service.Abstractions.Systems;

namespace KissU.GreatWall.Service.Implements.Systems {
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : CrudServiceBase<User, UserDto, UserQuery>, IUserService {
        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userRepository">用户仓储</param>
        public UserService( IKissU.GreatWallUnitOfWork unitOfWork, IUserRepository userRepository )
            : base( unitOfWork, userRepository ) {
            UserRepository = userRepository;
        }
        
        /// <summary>
        /// 用户仓储
        /// </summary>
        public IUserRepository UserRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<User> CreateQuery( UserQuery param ) {
            return new Query<User>( param );
        }
    }
}