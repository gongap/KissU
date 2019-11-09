using System.Collections.Generic;
using KissU.Modules.Admin.Service.Contracts.Dtos.NgAlain;
using KissU.Modules.GreatWall.Service.Contracts.Dtos.Responses;

namespace KissU.Modules.Admin.Service.Extensions
{
    /// <summary>
    /// 菜单参数扩展
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        /// 转成NgAlain菜单
        /// </summary>
        public static List<MenuInfo> ToNgAlainMenus(this IEnumerable<MenuResponse> data)
        {
            return new MenuResult(data).GetResult();
        }
    }
}
