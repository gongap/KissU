using Util.Applications;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;

namespace KissU.GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// Api许可范围服务
    /// </summary>
    public interface IApiScopeService : ICrudService<ApiScopeDto, ApiScopeQuery> {
    }
}