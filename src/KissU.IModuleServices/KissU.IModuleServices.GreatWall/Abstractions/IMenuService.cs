using System.Collections.Generic;
using System.Threading.Tasks;
using GreatWall.Service.Dtos.Responses;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Util.Applications;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 菜单服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IMenuService : IService {
        /// <summary>
        /// 获取菜单
        /// </summary>
        Task<List<MenuResponse>> GetMenusAsync();
    }
}
