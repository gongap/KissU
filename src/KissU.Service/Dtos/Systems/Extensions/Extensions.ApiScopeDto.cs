using Util;
using Util.Maps;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Factories;

namespace KissU.Service.Dtos.Systems.Extensions 
{
    /// <summary>
    /// Api许可范围数据传输对象扩展
    /// </summary>
    public static class ApiScopeDtoExtension 
	{
        /// <summary>
        /// 转换为Api许可范围实体
        /// </summary>
        /// <param name="dto">Api许可范围数据传输对象</param>
        public static ApiScope ToEntity( this ApiScopeDto dto ) 
		{
            if ( dto == null )
                return new ApiScope();
				return dto.MapTo( new ApiScope( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为Api许可范围实体
        /// </summary>
        /// <param name="dto">Api许可范围数据传输对象</param>
        public static ApiScope ToEntity2( this ApiScopeDto dto ) 
		{
            if( dto == null )
                return new ApiScope();
            return 
				new ApiScope( dto.Id.ToGuid() ) {
                ApiId = dto.ApiId,
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Description = dto.Description,
                ClaimTypes = dto.ClaimTypes,
                Required = dto.Required.SafeValue(),
                Emphasize = dto.Emphasize.SafeValue(),
                ShowInDiscoveryDocument = dto.ShowInDiscoveryDocument.SafeValue(),
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version
            };
        }
        
        /// <summary>
        /// 转换为Api许可范围实体
        /// </summary>
        /// <param name="dto">Api许可范围数据传输对象</param>
        public static ApiScope ToEntity3( this ApiScopeDto dto ) 
		{
            if( dto == null )
                return new ApiScope();
            return ApiScopeFactory.Create(
                apiScopeId : dto.Id.ToGuid(),
                apiId : dto.ApiId,
                name : dto.Name,
                displayName : dto.DisplayName,
                description : dto.Description,
                claimTypes : dto.ClaimTypes,
                required : dto.Required.SafeValue(),
                emphasize : dto.Emphasize.SafeValue(),
                showInDiscoveryDocument : dto.ShowInDiscoveryDocument.SafeValue(),
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为Api许可范围数据传输对象
        /// </summary>
        /// <param name="entity">Api许可范围实体</param>
        public static ApiScopeDto ToDto(this ApiScope entity) 
		{
            if( entity == null )
                return new ApiScopeDto();
            return entity.MapTo<ApiScopeDto>();
        }

        /// <summary>
        /// 转换为Api许可范围数据传输对象
        /// </summary>
        /// <param name="entity">Api许可范围实体</param>
        public static ApiScopeDto ToDto2( this ApiScope entity ) 
		{
            if( entity == null )
                return new ApiScopeDto();
            return new ApiScopeDto {
                Id = entity.Id.ToString(),
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
                Version = entity.Version
            };
        }
    }
}