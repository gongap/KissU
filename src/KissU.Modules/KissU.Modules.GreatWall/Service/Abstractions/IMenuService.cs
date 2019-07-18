using System.Collections.Generic;
using System.Threading.Tasks;
using GreatWall.Service.Dtos.Responses;
using Util.Applications;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 菜单服务
    /// </summary>
    public interface IMenuService : IService {
        /// <summary>
        /// 获取菜单
        /// </summary>
        Task<List<MenuResponse>> GetMenusAsync();
    }
}
