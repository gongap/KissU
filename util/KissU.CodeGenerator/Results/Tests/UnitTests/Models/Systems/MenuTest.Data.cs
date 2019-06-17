using System;
using System.Collections.Generic;
using Util;
using KissU.Systems.Domain.Models;

namespace KissU.Test.Models.Systems {
    /// <summary>
    /// 测试数据
    /// </summary>
    public partial class MenuTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "597ced4d-274c-40e3-b42d-c6a84795ebe3".ToGuid();
        /// <summary>
        /// 文本
        /// </summary>
        public static readonly string Text = "Text";
        /// <summary>
        /// 拼音
        /// </summary>
        public static readonly string PinYin = "PinYin";
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 排序标识
        /// </summary>
        public static readonly int? SortId = 1;
        /// <summary>
        /// 父节点标识
        /// </summary>
        public static readonly Guid? ParentId = "26e6b70b-f9a5-40c5-8cbe-2a6bd6cc354b".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path = "Path";
        /// <summary>
        /// 层级
        /// </summary>
        public static readonly int Level = 1;
        /// <summary>
        /// i18n主键
        /// </summary>
        public static readonly string I18n = "I18n";
        /// <summary>
        /// 是否显示分组名
        /// </summary>
        public static readonly bool? Group = true;
        /// <summary>
        /// 路由
        /// </summary>
        public static readonly string Link = "Link";
        /// <summary>
        /// 路由是否精准匹配
        /// </summary>
        public static readonly bool? LinkExact = true;
        /// <summary>
        /// 外部链接
        /// </summary>
        public static readonly string ExternalLink = "ExternalLink";
        /// <summary>
        /// 链接 target
        /// </summary>
        public static readonly string Target = "Target";
        /// <summary>
        /// 图标
        /// </summary>
        public static readonly string Icon = "Icon";
        /// <summary>
        /// 徽标数，展示的数字
        /// </summary>
        public static readonly int? Badge = 1;
        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        public static readonly bool? BadgeDot = true;
        /// <summary>
        /// 徽标 Badge 颜色
        /// </summary>
        public static readonly string BadgeStatus = "BadgeStatus";
        /// <summary>
        /// 是否禁用
        /// </summary>
        public static readonly bool? Disabled = true;
        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        public static readonly bool? Hide = true;
        /// <summary>
        /// 隐藏面包屑
        /// </summary>
        public static readonly bool? HideInBreadcrumb = true;
        /// <summary>
        /// ACL配置
        /// </summary>
        public static readonly string Acl = "Acl";
        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        public static readonly bool? Shortcut = true;
        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        public static readonly bool? ShortcutRoot = true;
        /// <summary>
        /// 是否允许复用
        /// </summary>
        public static readonly bool? Reuse = true;
        /// <summary>
        /// 是否展开
        /// </summary>
        public static readonly bool? Open = true;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note = "Note";
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/6/17 23:43:33".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "291be039-baff-4c12-9b14-d261f9d04a07".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/17 23:43:33".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "b915fe51-1220-42dc-84ce-c95727443867".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version = Util.Helpers.Convert.ToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id2 = "f094abe4-182a-4564-a93f-5d271a2cc962".ToGuid();
        /// <summary>
        /// 文本
        /// </summary>
        public static readonly string Text2 = "Text2";
        /// <summary>
        /// 拼音
        /// </summary>
        public static readonly string PinYin2 = "PinYin2";
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 排序标识
        /// </summary>
        public static readonly int? SortId2 = 2;
        /// <summary>
        /// 父节点标识
        /// </summary>
        public static readonly Guid? ParentId2 = "021f01ea-a90e-4b82-900c-615086a66a47".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path2 = "Path2";
        /// <summary>
        /// 层级
        /// </summary>
        public static readonly int Level2 = 2;
        /// <summary>
        /// i18n主键
        /// </summary>
        public static readonly string I18n2 = "I18n2";
        /// <summary>
        /// 是否显示分组名
        /// </summary>
        public static readonly bool? Group2 = true;
        /// <summary>
        /// 路由
        /// </summary>
        public static readonly string Link2 = "Link2";
        /// <summary>
        /// 路由是否精准匹配
        /// </summary>
        public static readonly bool? LinkExact2 = true;
        /// <summary>
        /// 外部链接
        /// </summary>
        public static readonly string ExternalLink2 = "ExternalLink2";
        /// <summary>
        /// 链接 target
        /// </summary>
        public static readonly string Target2 = "Target2";
        /// <summary>
        /// 图标
        /// </summary>
        public static readonly string Icon2 = "Icon2";
        /// <summary>
        /// 徽标数，展示的数字
        /// </summary>
        public static readonly int? Badge2 = 2;
        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        public static readonly bool? BadgeDot2 = true;
        /// <summary>
        /// 徽标 Badge 颜色
        /// </summary>
        public static readonly string BadgeStatus2 = "BadgeStatus2";
        /// <summary>
        /// 是否禁用
        /// </summary>
        public static readonly bool? Disabled2 = true;
        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        public static readonly bool? Hide2 = true;
        /// <summary>
        /// 隐藏面包屑
        /// </summary>
        public static readonly bool? HideInBreadcrumb2 = true;
        /// <summary>
        /// ACL配置
        /// </summary>
        public static readonly string Acl2 = "Acl2";
        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        public static readonly bool? Shortcut2 = true;
        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        public static readonly bool? ShortcutRoot2 = true;
        /// <summary>
        /// 是否允许复用
        /// </summary>
        public static readonly bool? Reuse2 = true;
        /// <summary>
        /// 是否展开
        /// </summary>
        public static readonly bool? Open2 = true;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note2 = "Note2";
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/6/18 23:43:33".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "949ece3d-7bb8-4d5e-803f-25846286e6b3".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/18 23:43:33".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "73949235-8b4b-46da-9656-d12b589547d5".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建实体
        /// </summary>
        public static Menu Create(string id = "") {
            return new Menu( id.ToGuid() ) {
                Text = Text,
                PinYin = PinYin,
                Enabled = Enabled,
                SortId = SortId,
                ParentId = ParentId,
                Path = Path,
                Level = Level,
                I18n = I18n,
                Group = Group,
                Link = Link,
                LinkExact = LinkExact,
                ExternalLink = ExternalLink,
                Target = Target,
                Icon = Icon,
                Badge = Badge,
                BadgeDot = BadgeDot,
                BadgeStatus = BadgeStatus,
                Disabled = Disabled,
                Hide = Hide,
                HideInBreadcrumb = HideInBreadcrumb,
                Acl = Acl,
                Shortcut = Shortcut,
                ShortcutRoot = ShortcutRoot,
                Reuse = Reuse,
                Open = Open,
                Note = Note,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建实体2
        /// </summary>
        /// <param name="id">编号</param>
        public static Menu Create2( string id = "" ) {
            return new Menu( id.ToGuid() ) {
                Text = Text2,
                PinYin = PinYin2,
                Enabled = Enabled2,
                SortId = SortId2,
                ParentId = ParentId2,
                Path = Path2,
                Level = Level2,
                I18n = I18n2,
                Group = Group2,
                Link = Link2,
                LinkExact = LinkExact2,
                ExternalLink = ExternalLink2,
                Target = Target2,
                Icon = Icon2,
                Badge = Badge2,
                BadgeDot = BadgeDot2,
                BadgeStatus = BadgeStatus2,
                Disabled = Disabled2,
                Hide = Hide2,
                HideInBreadcrumb = HideInBreadcrumb2,
                Acl = Acl2,
                Shortcut = Shortcut2,
                ShortcutRoot = ShortcutRoot2,
                Reuse = Reuse2,
                Open = Open2,
                Note = Note2,
                CreationTime = CreationTime2,
                CreatorId = CreatorId2,
                LastModificationTime = LastModificationTime2,
                LastModifierId = LastModifierId2,
                IsDeleted = IsDeleted2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<Menu> CreateList() {
            return new List<Menu>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}