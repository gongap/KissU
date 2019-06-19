﻿using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.Test.Models.Systems {
    /// <summary>
    /// 菜单测试数据
    /// </summary>
    public partial class MenuTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "924220ae-23d0-47c6-a1d0-c56cd308b4ca".ToGuid();
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
        public static readonly Guid? ParentId = "8eaff21f-cad2-44bb-bbaa-457b50ec2cfe".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/6/19 17:27:08".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "6d2803de-e61e-4791-880c-1c1bfae2f1bf".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/19 17:27:08".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "9d503736-38bd-47e5-b187-25dff700c21f".ToGuid();
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
        public static readonly Guid Id2 = "bb4ac328-a386-4ceb-9a08-a8ad01aa6e3a".ToGuid();
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
        public static readonly Guid? ParentId2 = "d180bd1c-125d-4cee-83a9-b3744247a350".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/6/20 17:27:08".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "9043e2b4-7d4e-49ea-a941-1b713ad62287".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/20 17:27:08".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "3d2d26e8-7fa5-440e-a745-1acfc31060e5".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted2 = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建菜单实体
        /// </summary>
        public static Menu Create(string id = "") {
            return 
			new Menu( id.ToGuid(),"", 0  ) {
                Text = Text,
                PinYin = PinYin,
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
        /// 创建菜单实体2
        /// </summary>
        /// <param name="id">菜单编号</param>
        public static Menu Create2( string id = "" ) {
            return 
			new Menu( id.ToGuid(),"", 0 ) {
                Text = Text2,
                PinYin = PinYin2,
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