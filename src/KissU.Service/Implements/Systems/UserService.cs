using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.Data;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Service.Implements.Systems {
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : CrudServiceBase<User, UserDto, UserQuery>, IUserService {
        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userRepository">用户仓储</param>
        public UserService( IKissUUnitOfWork unitOfWork, IUserRepository userRepository )
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