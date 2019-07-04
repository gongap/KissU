using Util;
using GreatWall.Systems.Domain.Models;
using Util.Maps;

namespace GreatWall.Data.Pos.Systems.Extensions {
    /// <summary>
    /// Api资源持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为Api资源实体
        /// </summary>
        /// <param name="po">Api资源持久化对象</param>
        public static Api ToEntity( this ApiPo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new Api( po.Id ) );
        }
        
        /// <summary>
        /// 转换为Api资源实体
        /// </summary>
        /// <param name="po">Api资源持久化对象</param>
        private static Api ToEntity2( this ApiPo po ) {
            if( po == null )
                return null;
            return new Api( po.Id ) {
                Name = po.Name,
                DisplayName = po.DisplayName,
                Description = po.Description,
                ClaimTypes = po.ClaimTypes,
                Enabled = po.Enabled,
                CreationTime = po.CreationTime,
                CreatorId = po.CreatorId,
                LastModificationTime = po.LastModificationTime,
                LastModifierId = po.LastModifierId,
                IsDeleted = po.IsDeleted,
                Version = po.Version,
            };
        }
        
        /// <summary>
        /// 转换为Api资源持久化对象
        /// </summary>
        /// <param name="entity">Api资源实体</param>
        public static ApiPo ToPo(this Api entity) {
            if( entity == null )
                return null;
            return entity.MapTo<ApiPo>();
        }

        /// <summary>
        /// 转换为Api资源持久化对象
        /// </summary>
        /// <param name="entity">Api资源实体</param>
        private static ApiPo ToPo2( this Api entity ) {
            if( entity == null )
                return null;
            return new ApiPo {
                Id = entity.Id,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                ClaimTypes = entity.ClaimTypes,
                Enabled = entity.Enabled,
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
