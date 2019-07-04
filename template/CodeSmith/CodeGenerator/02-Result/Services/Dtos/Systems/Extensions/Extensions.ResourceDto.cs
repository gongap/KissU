using Util;
using Util.Maps;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Service.Dtos.Systems.Extensions {
    /// <summary>
    /// 资源参数扩展
    /// </summary>
    public static class ResourceDtoExtension {
        /// <summary>
        /// 转换为资源实体
        /// </summary>
        /// <param name="dto">资源参数</param>
        public static Resource ToEntity( this ResourceDto dto ) {
            if ( dto == null )
                return new Resource();
            return dto.MapTo( new Resource( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为资源实体
        /// </summary>
        /// <param name="dto">资源参数</param>
        public static Resource ToEntity2( this ResourceDto dto ) {
            if( dto == null )
                return new Resource();
            return new Resource( dto.Id.ToGuid() ) {
                ApplicationId = dto.ApplicationId,
                Uri = dto.Uri,
                Name = dto.Name,
                Type = dto.Type,
                ParentId = dto.ParentId,
                Path = dto.Path,
                Level = dto.Level,
                Remark = dto.Remark,
                PinYin = dto.PinYin,
                Enabled = dto.Enabled.SafeValue(),
                SortId = dto.SortId,
                Extend = dto.Extend,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version,
            };
        }
        
        /// <summary>
        /// 转换为资源实体
        /// </summary>
        /// <param name="dto">资源参数</param>
        public static Resource ToEntity3( this ResourceDto dto ) {
            if( dto == null )
                return new Resource();
            return ResourceFactory.Create(
                resourceId : dto.Id.ToGuid(),
                applicationId : dto.ApplicationId,
                uri : dto.Uri,
                name : dto.Name,
                type : dto.Type,
                parentId : dto.ParentId,
                path : dto.Path,
                level : dto.Level,
                remark : dto.Remark,
                pinYin : dto.PinYin,
                enabled : dto.Enabled,
                sortId : dto.SortId,
                extend : dto.Extend,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为资源参数
        /// </summary>
        /// <param name="entity">资源实体</param>
        public static ResourceDto ToDto(this Resource entity) {
            if( entity == null )
                return new ResourceDto();
            return entity.MapTo<ResourceDto>();
        }

        /// <summary>
        /// 转换为资源参数
        /// </summary>
        /// <param name="entity">资源实体</param>
        public static ResourceDto ToDto2( this Resource entity ) {
            if( entity == null )
                return new ResourceDto();
            return new ResourceDto {
                Id = entity.Id.ToString(),
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
                Version = entity.Version,
            };
        }
    }
}