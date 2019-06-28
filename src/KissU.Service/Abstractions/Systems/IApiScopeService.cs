using Util.Applications;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems {
    /// <summary>
    /// Api许可范围服务
    /// </summary>
    public interface IApiScopeService : ICrudService<ApiScopeDto, ApiScopeQuery> {
    }
}