using Util;
using KissU.GreatWall.Systems.Domain.Models;
using Util.Maps;

namespace KissU.GreatWall.Data.Pos.Systems.Extensions {
    /// <summary>
    /// 角色持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="po">角色持久化对象</param>
        public static Role ToEntity( this RolePo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new Role( po.Id ) );
        }
        
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="po">角色持久化对象</param>
        private static Role ToEntity2( this RolePo po ) {
            if( po == null )
                return null;
            return new Role( po.Id ) {
                Code = po.Code,
                Name = po.Name,
                NormalizedName = po.NormalizedName,
                Type = po.Type,
                IsAdmin = po.IsAdmin,
                ParentId = po.ParentId,
                Path = po.Path,
                Level = po.Level,
                SortId = po.SortId,
                Enabled = po.Enabled,
                Remark = po.Remark,
                PinYin = po.PinYin,
                Sign = po.Sign,
                CreationTime = po.CreationTime,
                CreatorId = po.CreatorId,
                LastModificationTime = po.LastModificationTime,
                LastModifierId = po.LastModifierId,
                IsDeleted = po.IsDeleted,
                Version = po.Version,
            };
        }
        
        /// <summary>
        /// 转换为角色持久化对象
        /// </summary>
        /// <param name="entity">角色实体</param>
        public static RolePo ToPo(this Role entity) {
            if( entity == null )
                return null;
            return entity.MapTo<RolePo>();
        }

        /// <summary>
        /// 转换为角色持久化对象
        /// </summary>
        /// <param name="entity">角色实体</param>
        private static RolePo ToPo2( this Role entity ) {
            if( entity == null )
                return null;
            return new RolePo {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                NormalizedName = entity.NormalizedName,
                Type = entity.Type,
                IsAdmin = entity.IsAdmin,
                ParentId = entity.ParentId,
                Path = entity.Path,
                Level = entity.Level,
                SortId = entity.SortId,
                Enabled = entity.Enabled,
                Remark = entity.Remark,
                PinYin = entity.PinYin,
                Sign = entity.Sign,
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
