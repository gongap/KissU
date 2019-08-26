using KissU.IModuleServices.GreatWall.Dtos;
using KissU.IModuleServices.GreatWall.Dtos.Requests;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Pos.Models;
using KissU.Modules.GreatWall.Domain.Models;
using Util.Helpers;
using Util.Maps;

namespace KissU.Modules.GreatWall.Dtos.Extensions {
    /// <summary>
    /// 资源参数扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转成模块参数
        /// </summary>
        public static ModuleDto ToModuleDto( this ResourcePo po ) {
            if ( po == null )
                return null;
            var result = po.MapTo<ModuleDto>();
            result.Url = po.Uri;
            var extend = Json.ToObject<ModuleExtend>( po.Extend );
            extend.MapTo( result );
            return result;
        }

        /// <summary>
        /// 转成模块
        /// </summary> 
        public static Module ToModule( this CreateModuleRequest request ) {
            return request?.MapTo<Module>();
        }
    }
}