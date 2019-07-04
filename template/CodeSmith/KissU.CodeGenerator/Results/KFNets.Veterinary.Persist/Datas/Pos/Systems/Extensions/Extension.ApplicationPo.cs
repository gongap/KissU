using Util;
using KFNets.Veterinary.Domain.Systems.Models;
using Util.Maps;

namespace KFNets.Veterinary.Data.Pos.Systems.Extensions {
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
                Comment = po.Comment,
                Enabled = po.Enabled,
                RegisterEnabled = po.RegisterEnabled,
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
                Comment = entity.Comment,
                Enabled = entity.Enabled,
                RegisterEnabled = entity.RegisterEnabled,
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
