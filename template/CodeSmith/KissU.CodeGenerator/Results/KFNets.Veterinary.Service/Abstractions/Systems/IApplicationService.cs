using Util.Applications;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Queries.Systems;

namespace KFNets.Veterinary.Service.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}