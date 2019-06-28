using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems {
    /// <summary>
    /// 链接仓储
    /// </summary>
    public class LinkRepository : RepositoryBase<Link>, ILinkRepository {
        /// <summary>
        /// 初始化链接仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public LinkRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}