// <copyright file="Extension.ApplicationPo.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Data.Pos.Extensions
{
    using KissU.Modules.GreatWall.Data.Pos.Models;
    using KissU.Modules.GreatWall.Domain.Models;
    using Util.Helpers;
    using Util.Maps;

    /// <summary>
    ///     应用程序持久化对象扩展
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        ///     转换为应用程序实体
        /// </summary>
        /// <param name="po">应用程序持久化对象</param>
        public static Application ToEntity(this ApplicationPo po)
        {
            if (po == null)
            {
                return null;
            }

            var result = po.MapTo(new Application(po.Id));
            var extend = Json.ToObject<ApplicationExtend>(po.Extend);
            extend.MapTo(result);
            return result;
        }

        /// <summary>
        ///     转换为应用程序持久化对象
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationPo ToPo(this Application entity)
        {
            if (entity == null)
            {
                return null;
            }

            var result = entity.MapTo<ApplicationPo>();
            result.Extend = Json.ToJson(CreateExtend(entity));
            return result;
        }

        /// <summary>
        ///     创建扩展
        /// </summary>
        private static ApplicationExtend CreateExtend(Application entity)
        {
            return entity.MapTo<ApplicationExtend>();
        }
    }
}
