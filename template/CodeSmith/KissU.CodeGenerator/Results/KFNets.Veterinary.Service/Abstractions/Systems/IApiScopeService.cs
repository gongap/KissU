using Util.Applications;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Queries.Systems;

namespace KFNets.Veterinary.Service.Abstractions.Systems {
    /// <summary>
    /// Api许可范围服务
    /// </summary>
    public interface IApiScopeService : ICrudService<ApiScopeDto, ApiScopeQuery> {
    }
}