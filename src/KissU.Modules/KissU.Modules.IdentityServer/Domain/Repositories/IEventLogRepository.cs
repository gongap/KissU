using KissU.Modules.IdentityServer.Domain.Models.EventLog;
using Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Domain.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IEventLogRepository : IRepository<EventLog>
    {
    }
}