using Util;
using Util.Maps;
using KissU.JobScheduler.Domain.Systems.Models;
using KissU.JobScheduler.Domain.Systems.Factories;

namespace KissU.JobScheduler.Service.Dtos.Systems.Extensions 
{
    /// <summary>
    /// 角色数据传输对象扩展
    /// </summary>
    public static class RoleDtoExtension 
	{
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="dto">角色数据传输对象</param>
        public static Role ToEntity( this RoleDto dto ) 
		{
            if ( dto == null )
                return new Role();
				return dto.MapTo( new Role( dto.Id.ToGuid(), dto.Path, dto.Level.SafeValue() ) );
        }
        
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="dto">角色数据传输对象</param>
        public static Role ToEntity2( this RoleDto dto ) 
		{
            if( dto == null )
                return new Role();
            return 
				new Role( dto.Id.ToGuid(),dto.Path, dto.Level.SafeValue() ) {
                Code = dto.Code,
                Name = dto.Name,
                NormalizedName = dto.NormalizedName,
                Type = dto.Type,
                IsAdmin = dto.IsAdmin.SafeValue(),
                Comment = dto.Comment,
                PinYin = dto.PinYin,
                Sign = dto.Sign,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version
            };
        }
        
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="dto">角色数据传输对象</param>
        public static Role ToEntity3( this RoleDto dto ) 
		{
            if( dto == null )
                return new Role();
            return RoleFactory.Create(
                roleId : dto.Id.ToGuid(),
                code : dto.Code,
                name : dto.Name,
                normalizedName : dto.NormalizedName,
                type : dto.Type,
                isAdmin : dto.IsAdmin.SafeValue(),
                parentId : dto.ParentId.ToGuidOrNull(),
                path : dto.Path,
                level : dto.Level.SafeValue(),
                sortId : dto.SortId.SafeValue(),
                enabled : dto.Enabled.SafeValue(),
                comment : dto.Comment,
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
        /// 转换为角色数据传输对象
        /// </summary>
        /// <param name="entity">角色实体</param>
        public static RoleDto ToDto(this Role entity) 
		{
            if( entity == null )
                return new RoleDto();
            return entity.MapTo<RoleDto>();
        }

        /// <summary>
        /// 转换为角色数据传输对象
        /// </summary>
        /// <param name="entity">角色实体</param>
        public static RoleDto ToDto2( this Role entity ) 
		{
            if( entity == null )
                return new RoleDto();
            return new RoleDto {
                Id = entity.Id.ToString(),
                Code = entity.Code,
                Name = entity.Name,
                NormalizedName = entity.NormalizedName,
                Type = entity.Type,
                IsAdmin = entity.IsAdmin,
                ParentId = entity.ParentId.SafeString(),
                Path = entity.Path,
                Level = entity.Level,
                SortId = entity.SortId,
                Enabled = entity.Enabled,
                Comment = entity.Comment,
                PinYin = entity.PinYin,
                Sign = entity.Sign,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                Version = entity.Version
            };
        }
    }
}