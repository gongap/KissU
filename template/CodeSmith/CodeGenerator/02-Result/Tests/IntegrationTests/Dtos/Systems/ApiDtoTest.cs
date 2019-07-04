using System;
using System.Collections.Generic;
using Xunit;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Test.Models.Systems;

namespace KissU.GreatWall.Test.Integration.Dtos.Systems {
    /// <summary>
    /// Api资源数据传输对象测试
    /// </summary>
    public class ApiDtoTest {
        /// <summary>
        /// 创建Api资源数据传输对象
        /// </summary>
        public static ApiDto Create(string id = "") {
            return ApiTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建Api资源数据传输对象2
        /// </summary>
        /// <param name="id">Api资源编号</param>
        public static ApiDto Create2( string id = "" ) {
            return ApiTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建Api资源数据传输对象列表
        /// </summary>
        public static List<ApiDto> CreateList() {
            return new List<ApiDto>() {
                Create(),
                Create2()
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [Fact]
        public void TestToDto() {
            var dto = Create();
            Assert.Equal( ApiTest.Id.ToString(),dto.Id );
            Assert.Equal( ApiTest.Name,dto.Name );
            Assert.Equal( ApiTest.DisplayName,dto.DisplayName );
            Assert.Equal( ApiTest.Description,dto.Description );
            Assert.Equal( ApiTest.ClaimTypes,dto.ClaimTypes );
            Assert.Equal( ApiTest.Enabled,dto.Enabled );
            Assert.Equal( ApiTest.CreationTime,dto.CreationTime );
            Assert.Equal( ApiTest.CreatorId,dto.CreatorId );
            Assert.Equal( ApiTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( ApiTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( ApiTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( ApiTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.Equal( ApiTest.Id,entity.Id );
            Assert.Equal( ApiTest.Name,entity.Name );
            Assert.Equal( ApiTest.DisplayName,entity.DisplayName );
            Assert.Equal( ApiTest.Description,entity.Description );
            Assert.Equal( ApiTest.ClaimTypes,entity.ClaimTypes );
            Assert.Equal( ApiTest.Enabled,entity.Enabled );
            Assert.Equal( ApiTest.CreationTime,entity.CreationTime );
            Assert.Equal( ApiTest.CreatorId,entity.CreatorId );
            Assert.Equal( ApiTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( ApiTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( ApiTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( ApiTest.Version,entity.Version );
        }
    }
}