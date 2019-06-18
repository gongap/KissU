using Util.Domains.Repositories;
using KissU.Domain.Systems.Models;

namespace KissU.Domain.Systems.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : ICompactRepository<Application> {
    }
}