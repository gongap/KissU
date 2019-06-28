using System;
using System.Collections.Generic;
using Xunit;
using Util;
using KissU.Service.Dtos.Systems;
using KissU.Service.Dtos.Systems.Extensions;
using KissU.IntegrationTest.Tests.Models.Systems;

namespace KissU.IntegrationTest.Tests.Dtos.Systems 
{
    /// <summary>
    /// 企业数据传输对象测试
    /// </summary>
    public class EnterpriseDtoTest 
	{
        /// <summary>
        /// 创建企业数据传输对象
        /// </summary>
        public static EnterpriseDto Create(string id = "") 
		{
            return EnterpriseTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建企业数据传输对象2
        /// </summary>
        /// <param name="id">企业编号</param>
        public static EnterpriseDto Create2( string id = "" ) 
		{
            return EnterpriseTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建企业数据传输对象列表
        /// </summary>
        public static List<EnterpriseDto> CreateList() 
		{
            return new List<EnterpriseDto>() {
                Create(),
                Create2()
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [Fact]
        public void TestToDto() 
		{
            var dto = Create();
            Assert.Equal( EnterpriseTest.Id.ToString(),dto.Id );
            Assert.Equal( EnterpriseTest.Name,dto.Name );
            Assert.Equal( EnterpriseTest.Enabled,dto.Enabled );
            Assert.Equal( EnterpriseTest.PinYin,dto.PinYin );
            Assert.Equal( EnterpriseTest.WcfAddress,dto.WcfAddress );
            Assert.Equal( EnterpriseTest.Note,dto.Note );
            Assert.Equal( EnterpriseTest.CreationTime,dto.CreationTime );
            Assert.Equal( EnterpriseTest.CreatorId,dto.CreatorId );
            Assert.Equal( EnterpriseTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( EnterpriseTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( EnterpriseTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( EnterpriseTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() 
		{
            var entity = Create().ToEntity();
            Assert.Equal( EnterpriseTest.Id,entity.Id );
            Assert.Equal( EnterpriseTest.Name,entity.Name );
            Assert.Equal( EnterpriseTest.Enabled,entity.Enabled );
            Assert.Equal( EnterpriseTest.PinYin,entity.PinYin );
            Assert.Equal( EnterpriseTest.WcfAddress,entity.WcfAddress );
            Assert.Equal( EnterpriseTest.Note,entity.Note );
            Assert.Equal( EnterpriseTest.CreationTime,entity.CreationTime );
            Assert.Equal( EnterpriseTest.CreatorId,entity.CreatorId );
            Assert.Equal( EnterpriseTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( EnterpriseTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( EnterpriseTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( EnterpriseTest.Version,entity.Version );
        }
    }
}