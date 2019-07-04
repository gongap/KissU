using Util.Applications;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Queries.Systems;

namespace KFNets.Veterinary.Service.Abstractions.Systems {
    /// <summary>
    /// Api资源服务
    /// </summary>
    public interface IApiService : ICrudService<ApiDto, ApiQuery> {
    }
}