using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos.Responses;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IMenuService : IServiceKey
    {
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns>Task&lt;List&lt;MenuResponse&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<MenuResponse>> GetMenusAsync();
    }
}