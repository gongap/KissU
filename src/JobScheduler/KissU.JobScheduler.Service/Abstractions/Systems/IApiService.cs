using Util.Applications;
using KissU.JobScheduler.Service.Dtos.Systems;
using KissU.JobScheduler.Service.Queries.Systems;

namespace KissU.JobScheduler.Service.Abstractions.Systems
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public interface IApiService : ICrudService<ApiDto, ApiUpdateRequest, ApiCreateRequest, ApiUpdateRequest, ApiQuery>
    {
    }
}