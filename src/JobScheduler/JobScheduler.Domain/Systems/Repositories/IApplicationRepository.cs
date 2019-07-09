using Util.Domains.Repositories;
using JobScheduler.Domain.Systems.Models;

namespace JobScheduler.Domain.Systems.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : IRepository<Application> {
    }
}