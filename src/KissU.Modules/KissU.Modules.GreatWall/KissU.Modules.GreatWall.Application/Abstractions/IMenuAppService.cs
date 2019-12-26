using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos.Responses;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 菜单服务
    /// </summary>
    public interface IMenuAppService : IService {
        /// <summary>
        /// 获取菜单
        /// </summary>
        Task<List<MenuResponse>> GetMenusAsync();
    }
}
