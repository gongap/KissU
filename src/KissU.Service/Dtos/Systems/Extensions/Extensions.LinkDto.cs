using Util;
using Util.Maps;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Factories;

namespace KissU.Service.Dtos.Systems.Extensions 
{
    /// <summary>
    /// 链接数据传输对象扩展
    /// </summary>
    public static class LinkDtoExtension 
	{
        /// <summary>
        /// 转换为链接实体
        /// </summary>
        /// <param name="dto">链接数据传输对象</param>
        public static Link ToEntity( this LinkDto dto ) 
		{
            if ( dto == null )
                return new Link();
				return dto.MapTo( new Link( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为链接实体
        /// </summary>
        /// <param name="dto">链接数据传输对象</param>
        public static Link ToEntity2( this LinkDto dto ) 
		{
            if( dto == null )
                return new Link();
            return 
				new Link( dto.Id.ToGuid() ) {
                Code = dto.Code,
                Title = dto.Title,
                Address = dto.Address,
                Image = dto.Image,
                Comment = dto.Comment,
                Status = dto.Status,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version
            };
        }
        
        /// <summary>
        /// 转换为链接实体
        /// </summary>
        /// <param name="dto">链接数据传输对象</param>
        public static Link ToEntity3( this LinkDto dto ) 
		{
            if( dto == null )
                return new Link();
            return LinkFactory.Create(
                linkId : dto.Id.ToGuid(),
                code : dto.Code,
                title : dto.Title,
                address : dto.Address,
                image : dto.Image,
                comment : dto.Comment,
                enabled : dto.Enabled.SafeValue(),
                status : dto.Status.SafeValue(),
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为链接数据传输对象
        /// </summary>
        /// <param name="entity">链接实体</param>
        public static LinkDto ToDto(this Link entity) 
		{
            if( entity == null )
                return new LinkDto();
            return entity.MapTo<LinkDto>();
        }

        /// <summary>
        /// 转换为链接数据传输对象
        /// </summary>
        /// <param name="entity">链接实体</param>
        public static LinkDto ToDto2( this Link entity ) 
		{
            if( entity == null )
                return new LinkDto();
            return new LinkDto {
                Id = entity.Id.ToString(),
                Code = entity.Code,
                Title = entity.Title,
                Address = entity.Address,
                Image = entity.Image,
                Comment = entity.Comment,
                Enabled = entity.Enabled,
                Status = entity.Status,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                Version = entity.Version
            };
        }
    }
}