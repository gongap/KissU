using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Responses;
using KissU.Util.Ddd.Application.Contracts;

namespace KissU.Modules.GreatWall.Application.Contracts.Abstractions
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public interface IMenuAppService : IService
    {
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns>Task&lt;List&lt;MenuResponse&gt;&gt;.</returns>
        Task<List<MenuResponse>> GetMenusAsync();
    }
}