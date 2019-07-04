using Util.Applications;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Service.Queries.Systems;

namespace GreatWall.Service.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}