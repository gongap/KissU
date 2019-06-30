using Util;
using Util.Maps;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Factories;
using System.Linq;

namespace KissU.Service.Dtos.Systems.Extensions 
{
    /// <summary>
    /// Api资源数据传输对象扩展
    /// </summary>
    public static class ApiDtoExtension 
	{
        /// <summary>
        /// 转换为Api资源实体
        /// </summary>
        /// <param name="dto">Api资源数据传输对象</param>
        public static Api ToEntity( this ApiDto dto ) 
		{
            if ( dto == null )
                return new Api();
				return dto.MapTo( new Api( dto.Id.ToGuid() ) );
        }

        /// <summary>
        /// 转换为Api资源实体
        /// </summary>
        /// <param name="dto">Api资源数据传输对象</param>
        public static Api ToEntity2(this ApiDto dto)
        {
            if (dto == null)
                return new Api();
            var api = new Api(dto.Id.ToGuid()) {
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Description = dto.Description,
                ClaimTypes = dto.ClaimTypes,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version
            };
            var apiScopes = dto.ApiScopes?.Select(x => x.ToEntity2()).ToList();
            apiScopes.ForEach(x=> api.AddApiScope(x));
            return api;
        }
        
        /// <summary>
        /// 转换为Api资源实体
        /// </summary>
        /// <param name="dto">Api资源数据传输对象</param>
        public static Api ToEntity3( this ApiDto dto ) 
		{
            if( dto == null )
                return new Api();
            return ApiFactory.Create(
                apiId : dto.Id.ToGuid(),
                name : dto.Name,
                displayName : dto.DisplayName,
                description : dto.Description,
                claimTypes : dto.ClaimTypes,
                enabled : dto.Enabled.SafeValue(),
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为Api资源数据传输对象
        /// </summary>
        /// <param name="entity">Api资源实体</param>
        public static ApiDto ToDto(this Api entity) 
		{
            if( entity == null )
                return new ApiDto();
            return entity.MapTo<ApiDto>();
        }

        /// <summary>
        /// 转换为Api资源数据传输对象
        /// </summary>
        /// <param name="entity">Api资源实体</param>
        public static ApiDto ToDto2( this Api entity ) 
		{
            if( entity == null )
                return new ApiDto();
            return new ApiDto {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                ClaimTypes = entity.ClaimTypes,
                Enabled = entity.Enabled,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                Version = entity.Version,
                ApiScopes = entity.ApiScopes?.Select(x=>x.ToDto2()).ToList()
            };
        }
    }
}