using KissU.Systems.Domain.Models;
using KissU.Systems.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems {
    /// <summary>
    /// 仓储
    /// </summary>
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public MenuRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}