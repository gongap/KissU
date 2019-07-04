using KissU.GreatWall.Service.Dtos;
using KissU.GreatWall.Service.Queries;
using Util.Applications;

namespace KissU.GreatWall.Service.Abstractions {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}