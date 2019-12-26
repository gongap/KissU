using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Pos.Extensions;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Helpers;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Application.Dtos.Extensions {
    /// <summary>
    /// Api资源参数扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转成Api资源参数
        /// </summary>
        public static ApiResourceDto ToApiResourceDto( this ResourcePo po ) {
            if( po == null )
                return null;
            var result = po.MapTo<ApiResourceDto>();
            var extend = Json.ToObject<ApiResourceExtend>( po.Extend );
            extend.MapTo( result );
            return result;
        }

        /// <summary>
        /// 转成Api资源
        /// </summary> 
        public static ApiResource ToEntity( this ApiResourceDto dto ) {
            return dto?.MapTo<ApiResource>();
        }
    }
}