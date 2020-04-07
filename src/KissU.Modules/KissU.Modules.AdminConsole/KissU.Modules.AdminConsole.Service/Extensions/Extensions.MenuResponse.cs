﻿using System.Collections.Generic;
using KissU.Modules.AdminConsole.Service.Contracts.Dtos.NgAlain;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Responses;

namespace KissU.Modules.AdminConsole.Service.Extensions
{
    /// <summary>
    /// 菜单参数扩展
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// 转成NgAlain菜单
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>List&lt;MenuInfo&gt;.</returns>
        public static List<MenuInfo> ToNgAlainMenus(this IEnumerable<MenuResponse> data)
        {
            return new MenuResult(data).GetResult();
        }
    }
}