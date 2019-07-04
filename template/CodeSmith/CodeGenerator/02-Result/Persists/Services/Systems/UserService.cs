using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.GreatWall.Data;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;
using KissU.GreatWall.Service.Abstractions.Systems;
using KissU.GreatWall.Data.Pos.Systems;
using KissU.GreatWall.Data.Stores.Abstractions.Systems;

namespace KissU.GreatWall.Service.Implements.Systems {
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : CrudServiceBase<UserPo, UserDto, UserQuery>, IUserService {
        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userStore">用户存储器</param>
        public UserService( IKissU.GreatWallUnitOfWork unitOfWork, IUserPoStore userStore )
            : base( unitOfWork, userStore ) {
            UserStore = userStore;
        }
        
        /// <summary>
        /// 用户存储器
        /// </summary>
        public IUserPoStore UserStore { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<UserPo> CreateQuery( UserQuery param ) {
            return new Query<UserPo>( param );
        }
    }
}