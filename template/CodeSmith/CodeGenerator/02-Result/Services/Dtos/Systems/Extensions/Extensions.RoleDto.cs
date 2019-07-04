using Util;
using Util.Maps;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Service.Dtos.Systems.Extensions {
    /// <summary>
    /// 角色参数扩展
    /// </summary>
    public static class RoleDtoExtension {
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="dto">角色参数</param>
        public static Role ToEntity( this RoleDto dto ) {
            if ( dto == null )
                return new Role();
            return dto.MapTo( new Role( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="dto">角色参数</param>
        public static Role ToEntity2( this RoleDto dto ) {
            if( dto == null )
                return new Role();
            return new Role( dto.Id.ToGuid() ) {
                Code = dto.Code,
                Name = dto.Name,
                NormalizedName = dto.NormalizedName,
                Type = dto.Type,
                IsAdmin = dto.IsAdmin.SafeValue(),
                ParentId = dto.ParentId,
                Path = dto.Path,
                Level = dto.Level,
                SortId = dto.SortId,
                Enabled = dto.Enabled.SafeValue(),
                Remark = dto.Remark,
                PinYin = dto.PinYin,
                Sign = dto.Sign,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version,
            };
        }
        
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="dto">角色参数</param>
        public static Role ToEntity3( this RoleDto dto ) {
            if( dto == null )
                return new Role();
            return RoleFactory.Create(
                roleId : dto.Id.ToGuid(),
                code : dto.Code,
                name : dto.Name,
                normalizedName : dto.NormalizedName,
                type : dto.Type,
                isAdmin : dto.IsAdmin,
                parentId : dto.ParentId,
                path : dto.Path,
                level : dto.Level,
                sortId : dto.SortId,
                enabled : dto.Enabled,
                remark : dto.Remark,
                pinYin : dto.PinYin,
                sign : dto.Sign,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为角色参数
        /// </summary>
        /// <param name="entity">角色实体</param>
        public static RoleDto ToDto(this Role entity) {
            if( entity == null )
                return new RoleDto();
            return entity.MapTo<RoleDto>();
        }

        /// <summary>
        /// 转换为角色参数
        /// </summary>
        /// <param name="entity">角色实体</param>
        public static RoleDto ToDto2( this Role entity ) {
            if( entity == null )
                return new RoleDto();
            return new RoleDto {
                Id = entity.Id.ToString(),
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
                Version = entity.Version,
            };
        }
    }
}