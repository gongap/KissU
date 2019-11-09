using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain.Models.EventLog;
using KissU.Modules.IdentityServer.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Modules.IdentityServer.Data.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public class EventLogRepository : RepositoryBase<EventLog>, IEventLogRepository {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public EventLogRepository( IIdentityServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}