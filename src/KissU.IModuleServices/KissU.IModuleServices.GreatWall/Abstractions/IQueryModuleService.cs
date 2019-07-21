using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Util.Applications.Trees;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 模块查询服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IQueryModuleService : ITreeService<ModuleDto, ResourceQuery> {
    }
}