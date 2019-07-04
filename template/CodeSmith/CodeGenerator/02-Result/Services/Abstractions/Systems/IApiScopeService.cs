using Util.Applications;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;

namespace GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// Api许可范围服务
    /// </summary>
    public interface IApiScopeService : ICrudService<ApiScopeDto, ApiScopeQuery> {
    }
}