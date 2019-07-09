using Util.Applications;
using JobScheduler.Service.Dtos.Systems;
using JobScheduler.Service.Queries.Systems;

namespace JobScheduler.Service.Abstractions.Systems
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public interface IApiService : ICrudService<ApiDto, ApiUpdateRequest, ApiCreateRequest, ApiUpdateRequest, ApiQuery>
    {
    }
}