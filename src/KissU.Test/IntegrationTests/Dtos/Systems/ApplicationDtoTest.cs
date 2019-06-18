using System;
using System.Collections.Generic;
using Xunit;
using KissU.Service.Dtos.Systems;
using KissU.Test.Models.Systems;

namespace KissU.Test.Integration.Dtos.Systems {
    /// <summary>
    /// 应用程序数据传输对象测试
    /// </summary>
    public class ApplicationDtoTest {
        /// <summary>
        /// 创建应用程序数据传输对象
        /// </summary>
        public static ApplicationDto Create(string id = "") {
            return ApplicationTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建应用程序数据传输对象2
        /// </summary>
        /// <param name="id">应用程序编号</param>
        public static ApplicationDto Create2( string id = "" ) {
            return ApplicationTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建应用程序数据传输对象列表
        /// </summary>
        public static List<ApplicationDto> CreateList() {
            return new List<ApplicationDto>() {
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
            Assert.Equal( ApplicationTest.Id.ToString(),dto.Id );
            Assert.Equal( ApplicationTest.Code,dto.Code );
            Assert.Equal( ApplicationTest.Name,dto.Name );
            Assert.Equal( ApplicationTest.Comment,dto.Comment );
            Assert.Equal( ApplicationTest.Enabled,dto.Enabled );
            Assert.Equal( ApplicationTest.RegisterEnabled,dto.RegisterEnabled );
            Assert.Equal( ApplicationTest.CreationTime,dto.CreationTime );
            Assert.Equal( ApplicationTest.CreatorId,dto.CreatorId );
            Assert.Equal( ApplicationTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( ApplicationTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( ApplicationTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( ApplicationTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.Equal( ApplicationTest.Id,entity.Id );
            Assert.Equal( ApplicationTest.Code,entity.Code );
            Assert.Equal( ApplicationTest.Name,entity.Name );
            Assert.Equal( ApplicationTest.Comment,entity.Comment );
            Assert.Equal( ApplicationTest.Enabled,entity.Enabled );
            Assert.Equal( ApplicationTest.RegisterEnabled,entity.RegisterEnabled );
            Assert.Equal( ApplicationTest.CreationTime,entity.CreationTime );
            Assert.Equal( ApplicationTest.CreatorId,entity.CreatorId );
            Assert.Equal( ApplicationTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( ApplicationTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( ApplicationTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( ApplicationTest.Version,entity.Version );
        }
    }
}