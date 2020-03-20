using KissU.Core.Helpers;
using KissU.Core.Maps;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Pos.Models;
using KissU.Modules.GreatWall.Domain.Models;

namespace KissU.Modules.GreatWall.Application.Dtos.Extensions
{
    /// <summary>
    /// 模块资源参数扩展
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        /// 转成模块参数
        /// </summary>
        /// <param name="po">The po.</param>
        /// <returns>ModuleDto.</returns>
        public static ModuleDto ToModuleDto(this ResourcePo po)
        {
            if (po == null)
                return null;
            var result = po.MapTo<ModuleDto>();
            result.Url = po.Uri;
            var extend = Json.ToObject<ModuleExtend>(po.Extend);
            extend.MapTo(result);
            return result;
        }

        /// <summary>
        /// 转成模块
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Module.</returns>
        public static Module ToModule(this CreateModuleRequest request)
        {
            return request?.MapTo<Module>();
        }
    }
}