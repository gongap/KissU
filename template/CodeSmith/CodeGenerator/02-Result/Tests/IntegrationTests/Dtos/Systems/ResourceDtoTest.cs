using System;
using System.Collections.Generic;
using Xunit;
using GreatWall.Service.Dtos.Systems;
using GreatWall.Test.Models.Systems;

namespace GreatWall.Test.Integration.Dtos.Systems {
    /// <summary>
    /// 资源数据传输对象测试
    /// </summary>
    public class ResourceDtoTest {
        /// <summary>
        /// 创建资源数据传输对象
        /// </summary>
        public static ResourceDto Create(string id = "") {
            return ResourceTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建资源数据传输对象2
        /// </summary>
        /// <param name="id">资源编号</param>
        public static ResourceDto Create2( string id = "" ) {
            return ResourceTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建资源数据传输对象列表
        /// </summary>
        public static List<ResourceDto> CreateList() {
            return new List<ResourceDto>() {
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
            Assert.Equal( ResourceTest.Id.ToString(),dto.Id );
            Assert.Equal( ResourceTest.ApplicationId,dto.ApplicationId );
            Assert.Equal( ResourceTest.Uri,dto.Uri );
            Assert.Equal( ResourceTest.Name,dto.Name );
            Assert.Equal( ResourceTest.Type,dto.Type );
            Assert.Equal( ResourceTest.ParentId,dto.ParentId );
            Assert.Equal( ResourceTest.Path,dto.Path );
            Assert.Equal( ResourceTest.Level,dto.Level );
            Assert.Equal( ResourceTest.Remark,dto.Remark );
            Assert.Equal( ResourceTest.PinYin,dto.PinYin );
            Assert.Equal( ResourceTest.Enabled,dto.Enabled );
            Assert.Equal( ResourceTest.SortId,dto.SortId );
            Assert.Equal( ResourceTest.Extend,dto.Extend );
            Assert.Equal( ResourceTest.CreationTime,dto.CreationTime );
            Assert.Equal( ResourceTest.CreatorId,dto.CreatorId );
            Assert.Equal( ResourceTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( ResourceTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( ResourceTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( ResourceTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.Equal( ResourceTest.Id,entity.Id );
            Assert.Equal( ResourceTest.ApplicationId,entity.ApplicationId );
            Assert.Equal( ResourceTest.Uri,entity.Uri );
            Assert.Equal( ResourceTest.Name,entity.Name );
            Assert.Equal( ResourceTest.Type,entity.Type );
            Assert.Equal( ResourceTest.ParentId,entity.ParentId );
            Assert.Equal( ResourceTest.Path,entity.Path );
            Assert.Equal( ResourceTest.Level,entity.Level );
            Assert.Equal( ResourceTest.Remark,entity.Remark );
            Assert.Equal( ResourceTest.PinYin,entity.PinYin );
            Assert.Equal( ResourceTest.Enabled,entity.Enabled );
            Assert.Equal( ResourceTest.SortId,entity.SortId );
            Assert.Equal( ResourceTest.Extend,entity.Extend );
            Assert.Equal( ResourceTest.CreationTime,entity.CreationTime );
            Assert.Equal( ResourceTest.CreatorId,entity.CreatorId );
            Assert.Equal( ResourceTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( ResourceTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( ResourceTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( ResourceTest.Version,entity.Version );
        }
    }
}