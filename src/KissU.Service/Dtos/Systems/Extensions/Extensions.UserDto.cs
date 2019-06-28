using Util;
using Util.Maps;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Factories;

namespace KissU.Service.Dtos.Systems.Extensions 
{
    /// <summary>
    /// 用户数据传输对象扩展
    /// </summary>
    public static class UserDtoExtension 
	{
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="dto">用户数据传输对象</param>
        public static User ToEntity( this UserDto dto ) 
		{
            if ( dto == null )
                return new User();
				return dto.MapTo( new User( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="dto">用户数据传输对象</param>
        public static User ToEntity2( this UserDto dto ) 
		{
            if( dto == null )
                return new User();
            return 
				new User( dto.Id.ToGuid() ) {
                UserName = dto.UserName,
                RealName = dto.RealName,
                NickName = dto.NickName,
                Email = dto.Email,
                EmailConfirmed = dto.EmailConfirmed.SafeValue(),
                PhoneNumber = dto.PhoneNumber,
                PhoneNumberConfirmed = dto.PhoneNumberConfirmed.SafeValue(),
                Password = dto.Password,
                PasswordHash = dto.PasswordHash,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version
            };
        }
        
        /// <summary>
        /// 转换为用户实体
        /// </summary>
        /// <param name="dto">用户数据传输对象</param>
        public static User ToEntity3( this UserDto dto ) 
		{
            if( dto == null )
                return new User();
            return UserFactory.Create(
                userId : dto.Id.ToGuid(),
                userName : dto.UserName,
                realName : dto.RealName,
                nickName : dto.NickName,
                email : dto.Email,
                emailConfirmed : dto.EmailConfirmed.SafeValue(),
                phoneNumber : dto.PhoneNumber,
                phoneNumberConfirmed : dto.PhoneNumberConfirmed.SafeValue(),
                password : dto.Password,
                passwordHash : dto.PasswordHash,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为用户数据传输对象
        /// </summary>
        /// <param name="entity">用户实体</param>
        public static UserDto ToDto(this User entity) 
		{
            if( entity == null )
                return new UserDto();
            return entity.MapTo<UserDto>();
        }

        /// <summary>
        /// 转换为用户数据传输对象
        /// </summary>
        /// <param name="entity">用户实体</param>
        public static UserDto ToDto2( this User entity ) 
		{
            if( entity == null )
                return new UserDto();
            return new UserDto {
                Id = entity.Id.ToString(),
                UserName = entity.UserName,
                RealName = entity.RealName,
                NickName = entity.NickName,
                Email = entity.Email,
                EmailConfirmed = entity.EmailConfirmed,
                PhoneNumber = entity.PhoneNumber,
                PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                Password = entity.Password,
                PasswordHash = entity.PasswordHash,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                Version = entity.Version
            };
        }
    }
}