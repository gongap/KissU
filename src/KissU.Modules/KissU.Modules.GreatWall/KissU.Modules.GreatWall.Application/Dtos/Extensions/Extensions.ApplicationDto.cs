using System.Linq;
using KissU.Modules.GreatWall.Data.Pos;
using KissU.Modules.GreatWall.Data.Pos.Models;
using KissU.Modules.GreatWall.Domain.Enums;
using KissU.Util.Helpers;
using KissU.Util.Maps;

namespace KissU.Modules.GreatWall.Application.Dtos.Extensions
{
    /// <summary>
    /// 应用程序参数扩展
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        /// 转成应用程序参数
        /// </summary>
        public static ApplicationDto ToDto(this ApplicationPo po)
        {
            if (po == null)
                return null;
            var result = po.MapTo<ApplicationDto>();
            var extend = Json.ToObject<ApplicationExtend>(po.Extend);
            if (extend == null)
                return result;
            extend.MapTo(result);
            return result;
        }

        /// <summary>
        /// 转成应用程序实体
        /// </summary>
        public static Domain.Models.Application ToEntity(this ApplicationDto dto)
        {
            if (dto == null)
                return null;
            var result = dto.MapTo<Domain.Models.Application>();
            result.IsClient = dto.ApplicationType == ApplicationType.Client;
            return result;
        }
    }
}