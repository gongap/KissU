using Util.Applications;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;

namespace GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// Api资源服务
    /// </summary>
    public interface IApiService : ICrudService<ApiDto, ApiQuery> {
    }
}