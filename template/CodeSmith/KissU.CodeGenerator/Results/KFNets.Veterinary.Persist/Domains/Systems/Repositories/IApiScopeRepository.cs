using Util.Domains.Repositories;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.Domain.Systems.Repositories {
    /// <summary>
    /// Api许可范围仓储
    /// </summary>
    public interface IApiScopeRepository : ICompactRepository<ApiScope> {
    }
}