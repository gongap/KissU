using Util;
using Util.Maps;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Service.Dtos.Systems.Extensions {
    /// <summary>
    /// 应用程序参数扩展
    /// </summary>
    public static class ApplicationDtoExtension {
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        public static Application ToEntity( this ApplicationDto dto ) {
            if ( dto == null )
                return new Application();
            return dto.MapTo( new Application( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        public static Application ToEntity2( this ApplicationDto dto ) {
            if( dto == null )
                return new Application();
            return new Application( dto.Id.ToGuid() ) {
                Code = dto.Code,
                Name = dto.Name,
                Enabled = dto.Enabled.SafeValue(),
                RegisterEnabled = dto.RegisterEnabled.SafeValue(),
                Remark = dto.Remark,
                Extend = dto.Extend,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version,
            };
        }
        
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序参数</param>
        public static Application ToEntity3( this ApplicationDto dto ) {
            if( dto == null )
                return new Application();
            return ApplicationFactory.Create(
                applicationId : dto.Id.ToGuid(),
                code : dto.Code,
                name : dto.Name,
                enabled : dto.Enabled,
                registerEnabled : dto.RegisterEnabled,
                remark : dto.Remark,
                extend : dto.Extend,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为应用程序参数
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationDto ToDto(this Application entity) {
            if( entity == null )
                return new ApplicationDto();
            return entity.MapTo<ApplicationDto>();
        }

        /// <summary>
        /// 转换为应用程序参数
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationDto ToDto2( this Application entity ) {
            if( entity == null )
                return new ApplicationDto();
            return new ApplicationDto {
                Id = entity.Id.ToString(),
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
                Version = entity.Version,
            };
        }
    }
}