using Util;
using GreatWall.Systems.Domain.Models;
using Util.Maps;

namespace GreatWall.Data.Pos.Systems.Extensions {
    /// <summary>
    /// 资源持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为资源实体
        /// </summary>
        /// <param name="po">资源持久化对象</param>
        public static Resource ToEntity( this ResourcePo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new Resource( po.Id ) );
        }
        
        /// <summary>
        /// 转换为资源实体
        /// </summary>
        /// <param name="po">资源持久化对象</param>
        private static Resource ToEntity2( this ResourcePo po ) {
            if( po == null )
                return null;
            return new Resource( po.Id ) {
                ApplicationId = po.ApplicationId,
                Uri = po.Uri,
                Name = po.Name,
                Type = po.Type,
                ParentId = po.ParentId,
                Path = po.Path,
                Level = po.Level,
                Remark = po.Remark,
                PinYin = po.PinYin,
                Enabled = po.Enabled,
                SortId = po.SortId,
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
        /// 转换为资源持久化对象
        /// </summary>
        /// <param name="entity">资源实体</param>
        public static ResourcePo ToPo(this Resource entity) {
            if( entity == null )
                return null;
            return entity.MapTo<ResourcePo>();
        }

        /// <summary>
        /// 转换为资源持久化对象
        /// </summary>
        /// <param name="entity">资源实体</param>
        private static ResourcePo ToPo2( this Resource entity ) {
            if( entity == null )
                return null;
            return new ResourcePo {
                Id = entity.Id,
                ApplicationId = entity.ApplicationId,
                Uri = entity.Uri,
                Name = entity.Name,
                Type = entity.Type,
                ParentId = entity.ParentId,
                Path = entity.Path,
                Level = entity.Level,
                Remark = entity.Remark,
                PinYin = entity.PinYin,
                Enabled = entity.Enabled,
                SortId = entity.SortId,
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
