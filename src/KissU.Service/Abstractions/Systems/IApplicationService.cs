using Util.Applications;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}