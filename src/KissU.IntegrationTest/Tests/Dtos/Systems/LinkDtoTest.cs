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
    /// 链接数据传输对象测试
    /// </summary>
    public class LinkDtoTest 
	{
        /// <summary>
        /// 创建链接数据传输对象
        /// </summary>
        public static LinkDto Create(string id = "") 
		{
            return LinkTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建链接数据传输对象2
        /// </summary>
        /// <param name="id">链接编号</param>
        public static LinkDto Create2( string id = "" ) 
		{
            return LinkTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建链接数据传输对象列表
        /// </summary>
        public static List<LinkDto> CreateList() 
		{
            return new List<LinkDto>() {
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
            Assert.Equal( LinkTest.Id.ToString(),dto.Id );
            Assert.Equal( LinkTest.Code,dto.Code );
            Assert.Equal( LinkTest.Title,dto.Title );
            Assert.Equal( LinkTest.Address,dto.Address );
            Assert.Equal( LinkTest.Image,dto.Image );
            Assert.Equal( LinkTest.Comment,dto.Comment );
            Assert.Equal( LinkTest.Enabled,dto.Enabled );
            Assert.Equal( LinkTest.Status,dto.Status );
            Assert.Equal( LinkTest.CreationTime,dto.CreationTime );
            Assert.Equal( LinkTest.CreatorId,dto.CreatorId );
            Assert.Equal( LinkTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( LinkTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( LinkTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( LinkTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() 
		{
            var entity = Create().ToEntity();
            Assert.Equal( LinkTest.Id,entity.Id );
            Assert.Equal( LinkTest.Code,entity.Code );
            Assert.Equal( LinkTest.Title,entity.Title );
            Assert.Equal( LinkTest.Address,entity.Address );
            Assert.Equal( LinkTest.Image,entity.Image );
            Assert.Equal( LinkTest.Comment,entity.Comment );
            Assert.Equal( LinkTest.Enabled,entity.Enabled );
            Assert.Equal( LinkTest.Status,entity.Status );
            Assert.Equal( LinkTest.CreationTime,entity.CreationTime );
            Assert.Equal( LinkTest.CreatorId,entity.CreatorId );
            Assert.Equal( LinkTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( LinkTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( LinkTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( LinkTest.Version,entity.Version );
        }
    }
}