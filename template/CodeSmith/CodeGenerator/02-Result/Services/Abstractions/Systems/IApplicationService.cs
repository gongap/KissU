using Util.Applications;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Service.Queries.Systems;

namespace KissU.GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}