using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Ioc;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Responses;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

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