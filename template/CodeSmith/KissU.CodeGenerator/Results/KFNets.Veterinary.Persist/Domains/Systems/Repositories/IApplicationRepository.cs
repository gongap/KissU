using Util.Domains.Repositories;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.Domain.Systems.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : ICompactRepository<Application> {
    }
}