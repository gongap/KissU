using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Pos.Extensions;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Helpers;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Application.Dtos.Extensions {
    /// <summary>
    /// 身份资源参数扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转成身份资源参数
        /// </summary>
        public static IdentityResourceDto ToIdentityResourceDto( this ResourcePo po ) {
            if( po == null )
                return null;
            var result = po.MapTo<IdentityResourceDto>();
            var extend = Json.ToObject<IdentityResourceExtend>( po.Extend );
            extend.MapTo( result );
            return result;
        }

        /// <summary>
        /// 转成身份资源
        /// </summary> 
        public static IdentityResource ToEntity( this IdentityResourceDto dto ) {
            return dto?.MapTo<IdentityResource>();
        }
    }
}