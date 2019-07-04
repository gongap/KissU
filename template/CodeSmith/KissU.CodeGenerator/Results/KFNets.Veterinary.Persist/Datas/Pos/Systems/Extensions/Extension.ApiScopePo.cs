using Util;
using KFNets.Veterinary.Domain.Systems.Models;
using Util.Maps;

namespace KFNets.Veterinary.Data.Pos.Systems.Extensions {
    /// <summary>
    /// Api许可范围持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为Api许可范围实体
        /// </summary>
        /// <param name="po">Api许可范围持久化对象</param>
        public static ApiScope ToEntity( this ApiScopePo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new ApiScope( po.Id ) );
        }
        
        /// <summary>
        /// 转换为Api许可范围实体
        /// </summary>
        /// <param name="po">Api许可范围持久化对象</param>
        private static ApiScope ToEntity2( this ApiScopePo po ) {
            if( po == null )
                return null;
            return new ApiScope( po.Id ) {
                ApiId = po.ApiId,
                Name = po.Name,
                DisplayName = po.DisplayName,
                Description = po.Description,
                ClaimTypes = po.ClaimTypes,
                Required = po.Required,
                Emphasize = po.Emphasize,
                ShowInDiscoveryDocument = po.ShowInDiscoveryDocument,
                CreationTime = po.CreationTime,
                CreatorId = po.CreatorId,
                LastModificationTime = po.LastModificationTime,
                LastModifierId = po.LastModifierId,
                IsDeleted = po.IsDeleted,
            };
        }
        
        /// <summary>
        /// 转换为Api许可范围持久化对象
        /// </summary>
        /// <param name="entity">Api许可范围实体</param>
        public static ApiScopePo ToPo(this ApiScope entity) {
            if( entity == null )
                return null;
            return entity.MapTo<ApiScopePo>();
        }

        /// <summary>
        /// 转换为Api许可范围持久化对象
        /// </summary>
        /// <param name="entity">Api许可范围实体</param>
        private static ApiScopePo ToPo2( this ApiScope entity ) {
            if( entity == null )
                return null;
            return new ApiScopePo {
                Id = entity.Id,
                ApiId = entity.ApiId,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                ClaimTypes = entity.ClaimTypes,
                Required = entity.Required,
                Emphasize = entity.Emphasize,
                ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                IsDeleted = entity.IsDeleted,
            };
        }
    }
}
