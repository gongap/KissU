using System;
using KissU.GreatWall.Data.Pos.Models;
using KissU.GreatWall.Domain.Enums;
using KissU.GreatWall.Domain.Models;
using Util.Helpers;
using Util.Maps;

namespace KissU.GreatWall.Data.Pos.Extensions {
    /// <summary>
    /// 资源持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为模块
        /// </summary>
        /// <param name="po">资源持久化对象</param>
        public static Module ToModule( this ResourcePo po ) {
            if( po == null )
                return null;
            if ( po.Type != ResourceType.Module )
                return null;
            var result = po.MapTo( new Module( po.Id, po.Path, po.Level ) );
            result.Url = po.Uri;
            var extend = Json.ToObject<ModuleExtend>( po.Extend );
            result.Icon = extend?.Icon;
            result.Expanded = extend?.Expanded;
            return result;
        }

        /// <summary>
        /// 转换为资源持久化对象
        /// </summary>
        /// <param name="entity">模块</param>
        public static ResourcePo ToPo( this Module entity ) {
            if( entity == null )
                return null;
            var result = entity.MapTo<ResourcePo>();
            result.Type = ResourceType.Module;
            result.Uri = entity.Url;
            result.Extend = Json.ToJson( CreateExtend( entity ) );
            return result;
        }

        /// <summary>
        /// 创建扩展
        /// </summary>
        /// <param name="entity">模块</param>
        private static ModuleExtend CreateExtend( Module entity ) {
            return new ModuleExtend {
                Icon = entity.Icon,
                Expanded = entity.Expanded
            };
        }
    }
}
