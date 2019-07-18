﻿using System.Collections.Generic;
using GreatWall.Domain.Models;
using GreatWall.Service.Dtos.NgAlain;
using GreatWall.Service.Dtos.Responses;
using Util.Maps;

namespace GreatWall.Service.Dtos.Extensions {
    /// <summary>
    /// 菜单参数扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转成NgAlain菜单
        /// </summary>
        public static List<MenuInfo> ToNgAlainMenus( this IEnumerable<MenuResponse> data ) {
            return new MenuResult( data ).GetResult();
        }

        /// <summary>
        /// 转成菜单参数
        /// </summary> 
        public static MenuResponse ToMenuResponse( this Module entity ) {
            if ( entity == null )
                return null;
            var result = entity.MapTo<MenuResponse>();
            result.External = entity.IsExternalUrl();
            return result;
        }
    }
}