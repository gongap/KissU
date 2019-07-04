using Util.Domains.Repositories;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.Domain.Systems.Repositories {
    /// <summary>
    /// Api资源仓储
    /// </summary>
    public interface IApiRepository : ICompactRepository<Api> {
    }
}