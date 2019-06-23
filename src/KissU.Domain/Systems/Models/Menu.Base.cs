using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Trees;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace KissU.Domain.Systems.Models {
    /// <summary>
    /// 菜单
    /// </summary>
    [Description( "菜单" )]
    public partial class Menu : TreeEntityBase<Menu>,IDelete,IAudited {
        /// <summary>
        /// 初始化菜单
        /// </summary>
        public Menu()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="id">菜单标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Menu( Guid id, string path, int level )
            : base( id, path, level ) {
        }

        /// <summary>
        /// 菜单编码
        /// </summary>
        [Required(ErrorMessage = "菜单编码不能为空")]
        [StringLength( 256, ErrorMessage = "菜单编码输入过长，不能超过256位" )]
        public string Code { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单名称不能为空")]
        [StringLength( 256, ErrorMessage = "菜单名称输入过长，不能超过256位" )]
        public string Name { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [Required(ErrorMessage = "拼音不能为空")]
        [StringLength( 200, ErrorMessage = "拼音输入过长，不能超过200位" )]
        public string PinYin { get; set; }
        /// <summary>
        /// i18n主键
        /// </summary>
        [StringLength( 50, ErrorMessage = "i18n主键输入过长，不能超过50位" )]
        public string I18n { get; set; }
        /// <summary>
        /// 是否显示分组名
        /// </summary>
        public bool? Group { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        [StringLength( 256, ErrorMessage = "路由输入过长，不能超过256位" )]
        public string Link { get; set; }
        /// <summary>
        /// 路由是否精准匹配
        /// </summary>
        public bool? LinkExact { get; set; }
        /// <summary>
        /// 外部链接
        /// </summary>
        [StringLength( 256, ErrorMessage = "外部链接输入过长，不能超过256位" )]
        public string ExternalLink { get; set; }
        /// <summary>
        /// 链接 target
        /// </summary>
        [StringLength( 20, ErrorMessage = "链接 target输入过长，不能超过20位" )]
        public string Target { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength( 256, ErrorMessage = "图标输入过长，不能超过256位" )]
        public string Icon { get; set; }
        /// <summary>
        /// 徽标数，展示的数字
        /// </summary>
        public int? Badge { get; set; }
        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        public bool? BadgeDot { get; set; }
        /// <summary>
        /// 徽标 Badge 颜色
        /// </summary>
        [StringLength( 20, ErrorMessage = "徽标 Badge 颜色输入过长，不能超过20位" )]
        public string BadgeStatus { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool? Disabled { get; set; }
        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        public bool? Hide { get; set; }
        /// <summary>
        /// 隐藏面包屑
        /// </summary>
        public bool? HideInBreadcrumb { get; set; }
        /// <summary>
        /// ACL配置
        /// </summary>
        [StringLength( 50, ErrorMessage = "ACL配置输入过长，不能超过50位" )]
        public string Acl { get; set; }
        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        public bool? Shortcut { get; set; }
        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        public bool? ShortcutRoot { get; set; }
        /// <summary>
        /// 是否允许复用
        /// </summary>
        public bool? Reuse { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool? Open { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        public string Note { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Code );
            AddDescription( t => t.Name );
            AddDescription( t => t.PinYin );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.SortId );
            AddDescription( t => t.ParentId );
            AddDescription( t => t.Path );
            AddDescription( t => t.Level );
            AddDescription( t => t.I18n );
            AddDescription( t => t.Group );
            AddDescription( t => t.Link );
            AddDescription( t => t.LinkExact );
            AddDescription( t => t.ExternalLink );
            AddDescription( t => t.Target );
            AddDescription( t => t.Icon );
            AddDescription( t => t.Badge );
            AddDescription( t => t.BadgeDot );
            AddDescription( t => t.BadgeStatus );
            AddDescription( t => t.Disabled );
            AddDescription( t => t.Hide );
            AddDescription( t => t.HideInBreadcrumb );
            AddDescription( t => t.Acl );
            AddDescription( t => t.Shortcut );
            AddDescription( t => t.ShortcutRoot );
            AddDescription( t => t.Reuse );
            AddDescription( t => t.Open );
            AddDescription( t => t.Note );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Menu other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.PinYin, other.PinYin );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.SortId, other.SortId );
            AddChange( t => t.ParentId, other.ParentId );
            AddChange( t => t.Path, other.Path );
            AddChange( t => t.Level, other.Level );
            AddChange( t => t.I18n, other.I18n );
            AddChange( t => t.Group, other.Group );
            AddChange( t => t.Link, other.Link );
            AddChange( t => t.LinkExact, other.LinkExact );
            AddChange( t => t.ExternalLink, other.ExternalLink );
            AddChange( t => t.Target, other.Target );
            AddChange( t => t.Icon, other.Icon );
            AddChange( t => t.Badge, other.Badge );
            AddChange( t => t.BadgeDot, other.BadgeDot );
            AddChange( t => t.BadgeStatus, other.BadgeStatus );
            AddChange( t => t.Disabled, other.Disabled );
            AddChange( t => t.Hide, other.Hide );
            AddChange( t => t.HideInBreadcrumb, other.HideInBreadcrumb );
            AddChange( t => t.Acl, other.Acl );
            AddChange( t => t.Shortcut, other.Shortcut );
            AddChange( t => t.ShortcutRoot, other.ShortcutRoot );
            AddChange( t => t.Reuse, other.Reuse );
            AddChange( t => t.Open, other.Open );
            AddChange( t => t.Note, other.Note );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}