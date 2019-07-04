using Util;
using KissU.GreatWall.Systems.Domain.Models;
using Util.Maps;

namespace KissU.GreatWall.Data.Pos.Systems.Extensions {
    /// <summary>
    /// 应用程序持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="po">应用程序持久化对象</param>
        public static Application ToEntity( this ApplicationPo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new Application( po.Id ) );
        }
        
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="po">应用程序持久化对象</param>
        private static Application ToEntity2( this ApplicationPo po ) {
            if( po == null )
                return null;
            return new Application( po.Id ) {
                Code = po.Code,
                Name = po.Name,
                Enabled = po.Enabled,
                RegisterEnabled = po.RegisterEnabled,
                Remark = po.Remark,
                Extend = po.Extend,
                CreationTime = po.CreationTime,
                CreatorId = po.CreatorId,
                LastModificationTime = po.LastModificationTime,
                LastModifierId = po.LastModifierId,
                IsDeleted = po.IsDeleted,
                Version = po.Version,
            };
        }
        
        /// <summary>
        /// 转换为应用程序持久化对象
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationPo ToPo(this Application entity) {
            if( entity == null )
                return null;
            return entity.MapTo<ApplicationPo>();
        }

        /// <summary>
        /// 转换为应用程序持久化对象
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        private static ApplicationPo ToPo2( this Application entity ) {
            if( entity == null )
                return null;
            return new ApplicationPo {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Enabled = entity.Enabled,
                RegisterEnabled = entity.RegisterEnabled,
                Remark = entity.Remark,
                Extend = entity.Extend,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                IsDeleted = entity.IsDeleted,
                Version = entity.Version,
            };
        }
    }
}
