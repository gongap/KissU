using Util.Domains.Repositories;
using KissU.JobScheduler.Domain.Systems.Models;

namespace KissU.JobScheduler.Domain.Systems.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : IRepository<Application> {
    }
}