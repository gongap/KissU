using Util;
using Util.Maps;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Factories;

namespace KissU.Service.Dtos.Systems.Extensions 
{
    /// <summary>
    /// 企业数据传输对象扩展
    /// </summary>
    public static class EnterpriseDtoExtension 
	{
        /// <summary>
        /// 转换为企业实体
        /// </summary>
        /// <param name="dto">企业数据传输对象</param>
        public static Enterprise ToEntity( this EnterpriseDto dto ) 
		{
            if ( dto == null )
                return new Enterprise();
				return dto.MapTo( new Enterprise( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为企业实体
        /// </summary>
        /// <param name="dto">企业数据传输对象</param>
        public static Enterprise ToEntity2( this EnterpriseDto dto ) 
		{
            if( dto == null )
                return new Enterprise();
            return 
				new Enterprise( dto.Id.ToGuid() ) {
                Name = dto.Name,
                PinYin = dto.PinYin,
                WcfAddress = dto.WcfAddress,
                Note = dto.Note,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                Version = dto.Version
            };
        }
        
        /// <summary>
        /// 转换为企业实体
        /// </summary>
        /// <param name="dto">企业数据传输对象</param>
        public static Enterprise ToEntity3( this EnterpriseDto dto ) 
		{
            if( dto == null )
                return new Enterprise();
            return EnterpriseFactory.Create(
                enterpriseId : dto.Id.ToGuid(),
                name : dto.Name,
                enabled : dto.Enabled.SafeValue(),
                pinYin : dto.PinYin,
                wcfAddress : dto.WcfAddress,
                note : dto.Note,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为企业数据传输对象
        /// </summary>
        /// <param name="entity">企业实体</param>
        public static EnterpriseDto ToDto(this Enterprise entity) 
		{
            if( entity == null )
                return new EnterpriseDto();
            return entity.MapTo<EnterpriseDto>();
        }

        /// <summary>
        /// 转换为企业数据传输对象
        /// </summary>
        /// <param name="entity">企业实体</param>
        public static EnterpriseDto ToDto2( this Enterprise entity ) 
		{
            if( entity == null )
                return new EnterpriseDto();
            return new EnterpriseDto {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Enabled = entity.Enabled,
                PinYin = entity.PinYin,
                WcfAddress = entity.WcfAddress,
                Note = entity.Note,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                Version = entity.Version
            };
        }
    }
}