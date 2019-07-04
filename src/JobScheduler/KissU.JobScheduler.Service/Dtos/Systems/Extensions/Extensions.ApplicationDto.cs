using Util;
using Util.Maps;
using KissU.JobScheduler.Domain.Systems.Models;
using KissU.JobScheduler.Domain.Systems.Factories;

namespace KissU.JobScheduler.Service.Dtos.Systems.Extensions 
{
    /// <summary>
    /// 应用程序数据传输对象扩展
    /// </summary>
    public static class ApplicationDtoExtension 
	{
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序数据传输对象</param>
        public static Application ToEntity( this ApplicationDto dto ) 
		{
            if ( dto == null )
                return new Application();
				return dto.MapTo( new Application( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序数据传输对象</param>
        public static Application ToEntity2( this ApplicationDto dto ) 
		{
            if( dto == null )
                return new Application();
            return 
				new Application( dto.Id.ToGuid() ) {
                Code = dto.Code,
                Name = dto.Name,
                Comment = dto.Comment,
                RegisterEnabled = dto.RegisterEnabled.SafeValue(),
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version
            };
        }
        
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序数据传输对象</param>
        public static Application ToEntity3( this ApplicationDto dto ) 
		{
            if( dto == null )
                return new Application();
            return ApplicationFactory.Create(
                applicationId : dto.Id.ToGuid(),
                code : dto.Code,
                name : dto.Name,
                comment : dto.Comment,
                enabled : dto.Enabled.SafeValue(),
                registerEnabled : dto.RegisterEnabled.SafeValue(),
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为应用程序数据传输对象
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationDto ToDto(this Application entity) 
		{
            if( entity == null )
                return new ApplicationDto();
            return entity.MapTo<ApplicationDto>();
        }

        /// <summary>
        /// 转换为应用程序数据传输对象
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationDto ToDto2( this Application entity ) 
		{
            if( entity == null )
                return new ApplicationDto();
            return new ApplicationDto {
                Id = entity.Id.ToString(),
                Code = entity.Code,
                Name = entity.Name,
                Comment = entity.Comment,
                Enabled = entity.Enabled,
                RegisterEnabled = entity.RegisterEnabled,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                Version = entity.Version
            };
        }
    }
}