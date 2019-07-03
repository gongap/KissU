using Util.Applications;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public interface IApiService : ICrudService<ApiDto, ApiUpdateRequest, ApiCreateRequest, ApiUpdateRequest, ApiQuery>
    {
    }
}