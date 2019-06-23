using System;
using System.Collections.Generic;
using Xunit;
using Util;
using KissU.Service.Dtos.Systems;
using KissU.Service.Dtos.Systems.Extensions;
using KissU.IntegrationTest.Tests.Models.Systems;

namespace KissU.IntegrationTest.Tests.Dtos.Systems {
    /// <summary>
    /// 菜单数据传输对象测试
    /// </summary>
    public class MenuDtoTest {
        /// <summary>
        /// 创建菜单数据传输对象
        /// </summary>
        public static MenuDto Create(string id = "") {
            return MenuTest.Create(id).ToDto(); 
        }
        
        /// <summary>
        /// 创建菜单数据传输对象2
        /// </summary>
        /// <param name="id">菜单编号</param>
        public static MenuDto Create2( string id = "" ) {
            return MenuTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建菜单数据传输对象列表
        /// </summary>
        public static List<MenuDto> CreateList() {
            return new List<MenuDto>() {
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
            Assert.Equal( MenuTest.Id.ToString(),dto.Id );
            Assert.Equal( MenuTest.Code,dto.Code );
            Assert.Equal( MenuTest.Name,dto.Name );
            Assert.Equal( MenuTest.PinYin,dto.PinYin );
            Assert.Equal( MenuTest.Enabled,dto.Enabled );
            Assert.Equal( MenuTest.SortId,dto.SortId );
            Assert.Equal( MenuTest.ParentId,dto.ParentId.ToGuidOrNull() );
            Assert.Equal( MenuTest.Path,dto.Path );
            Assert.Equal( MenuTest.Level,dto.Level );
            Assert.Equal( MenuTest.I18n,dto.I18n );
            Assert.Equal( MenuTest.Group,dto.Group );
            Assert.Equal( MenuTest.Link,dto.Link );
            Assert.Equal( MenuTest.LinkExact,dto.LinkExact );
            Assert.Equal( MenuTest.ExternalLink,dto.ExternalLink );
            Assert.Equal( MenuTest.Target,dto.Target );
            Assert.Equal( MenuTest.Icon,dto.Icon );
            Assert.Equal( MenuTest.Badge,dto.Badge );
            Assert.Equal( MenuTest.BadgeDot,dto.BadgeDot );
            Assert.Equal( MenuTest.BadgeStatus,dto.BadgeStatus );
            Assert.Equal( MenuTest.Disabled,dto.Disabled );
            Assert.Equal( MenuTest.Hide,dto.Hide );
            Assert.Equal( MenuTest.HideInBreadcrumb,dto.HideInBreadcrumb );
            Assert.Equal( MenuTest.Acl,dto.Acl );
            Assert.Equal( MenuTest.Shortcut,dto.Shortcut );
            Assert.Equal( MenuTest.ShortcutRoot,dto.ShortcutRoot );
            Assert.Equal( MenuTest.Reuse,dto.Reuse );
            Assert.Equal( MenuTest.Open,dto.Open );
            Assert.Equal( MenuTest.Note,dto.Note );
            Assert.Equal( MenuTest.CreationTime,dto.CreationTime );
            Assert.Equal( MenuTest.CreatorId,dto.CreatorId );
            Assert.Equal( MenuTest.LastModificationTime,dto.LastModificationTime );
            Assert.Equal( MenuTest.LastModifierId,dto.LastModifierId );
            Assert.Equal( MenuTest.IsDeleted,dto.IsDeleted );
            Assert.Equal( MenuTest.Version,dto.Version );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [Fact]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.Equal( MenuTest.Id,entity.Id );
            Assert.Equal( MenuTest.Code,entity.Code );
            Assert.Equal( MenuTest.Name,entity.Name );
            Assert.Equal( MenuTest.PinYin,entity.PinYin );
            Assert.Equal( MenuTest.Enabled,entity.Enabled );
            Assert.Equal( MenuTest.SortId,entity.SortId );
            Assert.Equal( MenuTest.ParentId,entity.ParentId );
            Assert.Equal( MenuTest.Path,entity.Path );
            Assert.Equal( MenuTest.Level,entity.Level );
            Assert.Equal( MenuTest.I18n,entity.I18n );
            Assert.Equal( MenuTest.Group,entity.Group );
            Assert.Equal( MenuTest.Link,entity.Link );
            Assert.Equal( MenuTest.LinkExact,entity.LinkExact );
            Assert.Equal( MenuTest.ExternalLink,entity.ExternalLink );
            Assert.Equal( MenuTest.Target,entity.Target );
            Assert.Equal( MenuTest.Icon,entity.Icon );
            Assert.Equal( MenuTest.Badge,entity.Badge );
            Assert.Equal( MenuTest.BadgeDot,entity.BadgeDot );
            Assert.Equal( MenuTest.BadgeStatus,entity.BadgeStatus );
            Assert.Equal( MenuTest.Disabled,entity.Disabled );
            Assert.Equal( MenuTest.Hide,entity.Hide );
            Assert.Equal( MenuTest.HideInBreadcrumb,entity.HideInBreadcrumb );
            Assert.Equal( MenuTest.Acl,entity.Acl );
            Assert.Equal( MenuTest.Shortcut,entity.Shortcut );
            Assert.Equal( MenuTest.ShortcutRoot,entity.ShortcutRoot );
            Assert.Equal( MenuTest.Reuse,entity.Reuse );
            Assert.Equal( MenuTest.Open,entity.Open );
            Assert.Equal( MenuTest.Note,entity.Note );
            Assert.Equal( MenuTest.CreationTime,entity.CreationTime );
            Assert.Equal( MenuTest.CreatorId,entity.CreatorId );
            Assert.Equal( MenuTest.LastModificationTime,entity.LastModificationTime );
            Assert.Equal( MenuTest.LastModifierId,entity.LastModifierId );
            Assert.Equal( MenuTest.IsDeleted,entity.IsDeleted );
            Assert.Equal( MenuTest.Version,entity.Version );
        }
    }
}