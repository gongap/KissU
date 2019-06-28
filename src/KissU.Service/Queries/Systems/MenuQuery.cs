using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries.Trees;

namespace KissU.Service.Queries.Systems {
    /// <summary>
    /// 菜单查询参数
    /// </summary>
    public class MenuQuery : TreeQueryParameter {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? MenuId { get; set; }
        
        private string _code = string.Empty;
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Display(Name="菜单编码")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        
        private string _name = string.Empty;
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Display(Name="菜单名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _pinYin = string.Empty;
        /// <summary>
        /// 拼音
        /// </summary>
        [Display(Name="拼音")]
        public string PinYin {
            get => _pinYin == null ? string.Empty : _pinYin.Trim();
            set => _pinYin = value;
        }
        
        private string _i18n = string.Empty;
        /// <summary>
        /// i18n主键
        /// </summary>
        [Display(Name="i18n主键")]
        public string I18n {
            get => _i18n == null ? string.Empty : _i18n.Trim();
            set => _i18n = value;
        }
        /// <summary>
        /// 是否显示分组名
        /// </summary>
        [Display(Name="是否显示分组名")]
        public bool? Group { get; set; }
        
        private string _link = string.Empty;
        /// <summary>
        /// 路由
        /// </summary>
        [Display(Name="路由")]
        public string Link {
            get => _link == null ? string.Empty : _link.Trim();
            set => _link = value;
        }
        /// <summary>
        /// 路由是否精准匹配
        /// </summary>
        [Display(Name="路由是否精准匹配")]
        public bool? LinkExact { get; set; }
        
        private string _externalLink = string.Empty;
        /// <summary>
        /// 外部链接
        /// </summary>
        [Display(Name="外部链接")]
        public string ExternalLink {
            get => _externalLink == null ? string.Empty : _externalLink.Trim();
            set => _externalLink = value;
        }
        
        private string _target = string.Empty;
        /// <summary>
        /// 链接 target
        /// </summary>
        [Display(Name="链接 target")]
        public string Target {
            get => _target == null ? string.Empty : _target.Trim();
            set => _target = value;
        }
        
        private string _icon = string.Empty;
        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name="图标")]
        public string Icon {
            get => _icon == null ? string.Empty : _icon.Trim();
            set => _icon = value;
        }
        /// <summary>
        /// 徽标数，展示的数字
        /// </summary>
        [Display(Name="徽标数，展示的数字")]
        public int? Badge { get; set; }
        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        [Display(Name="徽标数，显示小红点")]
        public bool? BadgeDot { get; set; }
        
        private string _badgeStatus = string.Empty;
        /// <summary>
        /// 徽标 Badge 颜色
        /// </summary>
        [Display(Name="徽标 Badge 颜色")]
        public string BadgeStatus {
            get => _badgeStatus == null ? string.Empty : _badgeStatus.Trim();
            set => _badgeStatus = value;
        }
        /// <summary>
        /// 是否禁用
        /// </summary>
        [Display(Name="是否禁用")]
        public bool? Disabled { get; set; }
        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        [Display(Name="是否隐藏菜单")]
        public bool? Hide { get; set; }
        /// <summary>
        /// 隐藏面包屑
        /// </summary>
        [Display(Name="隐藏面包屑")]
        public bool? HideInBreadcrumb { get; set; }
        
        private string _acl = string.Empty;
        /// <summary>
        /// ACL配置
        /// </summary>
        [Display(Name="ACL配置")]
        public string Acl {
            get => _acl == null ? string.Empty : _acl.Trim();
            set => _acl = value;
        }
        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        [Display(Name="是否快捷菜单项")]
        public bool? Shortcut { get; set; }
        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        [Display(Name="快捷菜单根节点")]
        public bool? ShortcutRoot { get; set; }
        /// <summary>
        /// 是否允许复用
        /// </summary>
        [Display(Name="是否允许复用")]
        public bool? Reuse { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [Display(Name="是否展开")]
        public bool? Open { get; set; }
        
        private string _note = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string Note {
            get => _note == null ? string.Empty : _note.Trim();
            set => _note = value;
        }
        /// <summary>
        /// 起始
        /// </summary>
        [Display( Name = "起始" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束
        /// </summary>
        [Display( Name = "结束" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始
        /// </summary>
        [Display( Name = "起始" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束
        /// </summary>
        [Display( Name = "结束" )]
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? LastModifierId { get; set; }
    }
}