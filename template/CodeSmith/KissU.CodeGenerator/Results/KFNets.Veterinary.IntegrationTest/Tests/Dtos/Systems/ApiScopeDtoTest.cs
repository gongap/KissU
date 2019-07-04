using System;
using System.Collections.Generic;
using Xunit;
using Util;
using KFNets.Veterinary.Service.Dtos.Systems;
using KFNets.Veterinary.Service.Dtos.Systems.Extensions;
using KFNets.Veterinary.IntegrationTest.Tests.Models.Systems;

namespace KFNets.Veterinary.IntegrationTest.Tests.Dtos.Systems 
{
    /// <summary>
    /// Api许可范围数据传输对象测试
    /// </summary>
    public class ApiScopeDtoTest 
	{
        /// <summary>
        /// 创建Api许可范围数据传输对象
        /// </summary>
        public static ApiScopeDto Create(string id = "") 
		{
            return ApiScopeTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建Api许可范围数据传输对象2
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        public static ApiScopeDto Create2( string id = "" ) 
		{
            return ApiScopeTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建Api许可范围数据传输对象列表
        /// </summary>
        public static List<ApiScopeDto> CreateList() 
		{
            return new List<ApiScopeDto>() {
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
            Assert.Equal( ApiScopeTest.Id.ToString(),dto.Id );
            Assert.Equal( ApiScopeTest.ApiId,dto.ApiId );
            Assert.Equal( ApiScopeTest.Name,dto.Name );
            Assert.Equal( ApiScopeTest.DisplayName,dto.DisplayName );
            Assert.Equal( ApiScopeTest.Description,dto.Description );
            Assert.Equal( ApiScopeTest.ClaimTypes,dto.ClaimTypes );
            Assert.Equal( ApiScopeTest.Required,dto.Required );
            Assert.Equal( ApiScopeTest.Emphasize,dto.Emphasize );
            Assert.Equal( ApiScopeTest.ShowInDiscoveryDocument,dto.ShowInDiscoveryDocument );
            Assert.Equal( ApiScopeTest.CreationTime,dto.CreationTime );
            Assert.Equal( ApiScopeTest.CreatorId,dto.CreatorId );
            Assert.Equal( ApiScopeTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( ApiScopeTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( ApiScopeTest.IsDeleted,dto.IsDeleted );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() 
		{
            var entity = Create().ToEntity();
            Assert.Equal( ApiScopeTest.Id,entity.Id );
            Assert.Equal( ApiScopeTest.ApiId,entity.ApiId );
            Assert.Equal( ApiScopeTest.Name,entity.Name );
            Assert.Equal( ApiScopeTest.DisplayName,entity.DisplayName );
            Assert.Equal( ApiScopeTest.Description,entity.Description );
            Assert.Equal( ApiScopeTest.ClaimTypes,entity.ClaimTypes );
            Assert.Equal( ApiScopeTest.Required,entity.Required );
            Assert.Equal( ApiScopeTest.Emphasize,entity.Emphasize );
            Assert.Equal( ApiScopeTest.ShowInDiscoveryDocument,entity.ShowInDiscoveryDocument );
            Assert.Equal( ApiScopeTest.CreationTime,entity.CreationTime );
            Assert.Equal( ApiScopeTest.CreatorId,entity.CreatorId );
            Assert.Equal( ApiScopeTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( ApiScopeTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( ApiScopeTest.IsDeleted,entity.IsDeleted );
        }
    }
}