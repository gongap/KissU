using Util.Applications;
using JobScheduler.Service.Dtos.Systems;
using JobScheduler.Service.Queries.Systems;

namespace JobScheduler.Service.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}