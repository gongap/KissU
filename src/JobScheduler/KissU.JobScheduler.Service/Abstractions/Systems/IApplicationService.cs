using Util.Applications;
using KissU.JobScheduler.Service.Dtos.Systems;
using KissU.JobScheduler.Service.Queries.Systems;

namespace KissU.JobScheduler.Service.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}