using Util.Datas.Ef.Core;
using KissU.GreatWall.Data.Pos.Systems;
using KissU.GreatWall.Data.Stores.Abstractions.Systems;

namespace KissU.GreatWall.Data.Stores.Implements.Systems{
    /// <summary>
    /// 用户存储器
    /// </summary>
    public class UserPoStore : StoreBase<UserPo>, IUserPoStore {
        /// <summary>
        /// 初始化用户存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public UserPoStore( IKissU.GreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}