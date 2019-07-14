using Util;
using Util.Maps;
using KissU.IModuleServices.QuickStart.Dtos;
using KissU.Modules.QuickStart.Domain.Models;
using KissU.Modules.QuickStart.Domain.Factories;

namespace KissU.Modules.QuickStart.Application.Extensions {
    /// <summary>
    /// 租户数据传输对象扩展
    /// </summary>
    public static class TenantDtoExtension {
        /// <summary>
        /// 转换为租户实体
        /// </summary>
        /// <param name="dto">租户数据传输对象</param>
        public static Tenant ToEntity( this TenantDto dto ) {
            if ( dto == null )
                return new Tenant();
            return dto.MapTo( new Tenant( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为租户实体
        /// </summary>
        /// <param name="dto">租户数据传输对象</param>
        public static Tenant ToEntity2( this TenantDto dto ) {
            if( dto == null )
                return new Tenant();
            return new Tenant( dto.Id.ToGuid() ) {
                Code = dto.Code,
                Name = dto.Name,
                Comment = dto.Comment,
                    Enabled = dto.Enabled.SafeValue(),
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                    IsDeleted = dto.IsDeleted.SafeValue(),
                Version = dto.Version,
            };
        }
        
        /// <summary>
        /// 转换为租户实体
        /// </summary>
        /// <param name="dto">租户数据传输对象</param>
        public static Tenant ToEntity3( this TenantDto dto ) {
            if( dto == null )
                return new Tenant();
            return TenantFactory.Create(
                clientId : dto.Id.ToGuid(),
                code : dto.Code,
                name : dto.Name,
                comment : dto.Comment,
                enabled : dto.Enabled.SafeValue(),
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                isDeleted : dto.IsDeleted.SafeValue(),
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为租户数据传输对象
        /// </summary>
        /// <param name="entity">租户实体</param>
        public static TenantDto ToDto(this Tenant entity) {
            if( entity == null )
                return new TenantDto();
            return entity.MapTo<TenantDto>();
        }

        /// <summary>
        /// 转换为租户数据传输对象
        /// </summary>
        /// <param name="entity">租户实体</param>
        public static TenantDto ToDto2( this Tenant entity ) {
            if( entity == null )
                return new TenantDto();
            return new TenantDto {
                Id = entity.Id.ToString(),
                Code = entity.Code,
                Name = entity.Name,
                Comment = entity.Comment,
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