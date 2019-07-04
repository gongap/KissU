using System;
using System.Collections.Generic;
using Xunit;
using KissU.GreatWall.Service.Dtos.Systems;
using KissU.GreatWall.Test.Models.Systems;

namespace KissU.GreatWall.Test.Integration.Dtos.Systems {
    /// <summary>
    /// 角色数据传输对象测试
    /// </summary>
    public class RoleDtoTest {
        /// <summary>
        /// 创建角色数据传输对象
        /// </summary>
        public static RoleDto Create(string id = "") {
            return RoleTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建角色数据传输对象2
        /// </summary>
        /// <param name="id">角色编号</param>
        public static RoleDto Create2( string id = "" ) {
            return RoleTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建角色数据传输对象列表
        /// </summary>
        public static List<RoleDto> CreateList() {
            return new List<RoleDto>() {
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
            Assert.Equal( RoleTest.Id.ToString(),dto.Id );
            Assert.Equal( RoleTest.Code,dto.Code );
            Assert.Equal( RoleTest.Name,dto.Name );
            Assert.Equal( RoleTest.NormalizedName,dto.NormalizedName );
            Assert.Equal( RoleTest.Type,dto.Type );
            Assert.Equal( RoleTest.IsAdmin,dto.IsAdmin );
            Assert.Equal( RoleTest.ParentId,dto.ParentId );
            Assert.Equal( RoleTest.Path,dto.Path );
            Assert.Equal( RoleTest.Level,dto.Level );
            Assert.Equal( RoleTest.SortId,dto.SortId );
            Assert.Equal( RoleTest.Enabled,dto.Enabled );
            Assert.Equal( RoleTest.Remark,dto.Remark );
            Assert.Equal( RoleTest.PinYin,dto.PinYin );
            Assert.Equal( RoleTest.Sign,dto.Sign );
            Assert.Equal( RoleTest.CreationTime,dto.CreationTime );
            Assert.Equal( RoleTest.CreatorId,dto.CreatorId );
            Assert.Equal( RoleTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( RoleTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( RoleTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( RoleTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.Equal( RoleTest.Id,entity.Id );
            Assert.Equal( RoleTest.Code,entity.Code );
            Assert.Equal( RoleTest.Name,entity.Name );
            Assert.Equal( RoleTest.NormalizedName,entity.NormalizedName );
            Assert.Equal( RoleTest.Type,entity.Type );
            Assert.Equal( RoleTest.IsAdmin,entity.IsAdmin );
            Assert.Equal( RoleTest.ParentId,entity.ParentId );
            Assert.Equal( RoleTest.Path,entity.Path );
            Assert.Equal( RoleTest.Level,entity.Level );
            Assert.Equal( RoleTest.SortId,entity.SortId );
            Assert.Equal( RoleTest.Enabled,entity.Enabled );
            Assert.Equal( RoleTest.Remark,entity.Remark );
            Assert.Equal( RoleTest.PinYin,entity.PinYin );
            Assert.Equal( RoleTest.Sign,entity.Sign );
            Assert.Equal( RoleTest.CreationTime,entity.CreationTime );
            Assert.Equal( RoleTest.CreatorId,entity.CreatorId );
            Assert.Equal( RoleTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( RoleTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( RoleTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( RoleTest.Version,entity.Version );
        }
    }
}