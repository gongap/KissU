﻿using KissU.Modules.GreatWall.Domain.Enums;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Helpers;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Data.Pos.Extensions
{
    /// <summary>
    /// 资源持久化对象扩展
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        /// 转换为模块
        /// </summary>
        public static Module ToModule(this ResourcePo po)
        {
            if (po == null)
                return null;
            if (po.Type != ResourceType.Module)
                return null;
            var result = po.MapTo(new Module(po.Id, po.Path, po.Level));
            result.Url = po.Uri;
            var extend = Json.ToObject<Models.ModuleExtend>(po.Extend);
            extend.MapTo(result);
            return result;
        }

        /// <summary>
        /// 转换为资源持久化对象
        /// </summary>
        public static ResourcePo ToPo(this Module entity)
        {
            if (entity == null)
                return null;
            var result = entity.MapTo<ResourcePo>();
            result.Type = ResourceType.Module;
            result.Uri = entity.Url;
            result.Extend = Json.ToJson(CreateExtend(entity));
            return result;
        }

        /// <summary>
        /// 创建模块扩展对象
        /// </summary>
        private static Models.ModuleExtend CreateExtend(Module entity)
        {
            return new Models.ModuleExtend
            {
                Icon = entity.Icon,
                Expanded = entity.Expanded
            };
        }
    }
}