// <copyright file="Extensions.MenuResponse.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Service.Contracts.Dtos.Responses;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Service.Extensions
{
    /// <summary>
    /// 菜单参数扩展
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        /// 转成菜单参数
        /// </summary>
        public static MenuResponse ToMenuResponse(this Module entity)
        {
            if (entity == null)
            {
                return null;
            }

            var result = entity.MapTo<MenuResponse>();
            result.External = entity.IsExternalUrl();
            return result;
        }
    }
}
