using Util.Applications;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;

namespace KissU.GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// Api资源服务
    /// </summary>
    public interface IApiService : ICrudService<ApiDto, ApiQuery> {
    }
}