using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Data;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// 菜单数据传输对象
    /// </summary>
    public class MenuDto : TreeDto<MenuDto> {
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Required(ErrorMessage = "菜单编码不能为空")]
        [StringLength( 256 )]
        [Display( Name = "菜单编码" )]
        public string Code { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单名称不能为空")]
        [StringLength( 256 )]
        [Display( Name = "菜单名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [Required(ErrorMessage = "拼音不能为空")]
        [StringLength( 200 )]
        [Display( Name = "拼音" )]
        public string PinYin { get; set; }
        /// <summary>
        /// i18n主键
        /// </summary>
        [StringLength( 50 )]
        [Display( Name = "i18n主键" )]
        public string I18n { get; set; }
        /// <summary>
        /// 是否显示分组名
        /// </summary>
        [Display( Name = "是否显示分组名" )]
        public bool? Group { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "路由" )]
        public string Link { get; set; }
        /// <summary>
        /// 路由是否精准匹配
        /// </summary>
        [Display( Name = "路由是否精准匹配" )]
        public bool? LinkExact { get; set; }
        /// <summary>
        /// 外部链接
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "外部链接" )]
        public string ExternalLink { get; set; }
        /// <summary>
        /// 链接 target
        /// </summary>
        [StringLength( 20 )]
        [Display( Name = "链接 target" )]
        public string Target { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "图标" )]
        public string Icon { get; set; }
        /// <summary>
        /// 徽标数，展示的数字
        /// </summary>
        [Display( Name = "徽标数，展示的数字" )]
        public int? Badge { get; set; }
        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        [Display( Name = "徽标数，显示小红点" )]
        public bool? BadgeDot { get; set; }
        /// <summary>
        /// 徽标 Badge 颜色
        /// </summary>
        [StringLength( 20 )]
        [Display( Name = "徽标 Badge 颜色" )]
        public string BadgeStatus { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        [Display( Name = "是否禁用" )]
        public bool? Disabled { get; set; }
        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        [Display( Name = "是否隐藏菜单" )]
        public bool? Hide { get; set; }
        /// <summary>
        /// 隐藏面包屑
        /// </summary>
        [Display( Name = "隐藏面包屑" )]
        public bool? HideInBreadcrumb { get; set; }
        /// <summary>
        /// ACL配置
        /// </summary>
        [StringLength( 50 )]
        [Display( Name = "ACL配置" )]
        public string Acl { get; set; }
        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        [Display( Name = "是否快捷菜单项" )]
        public bool? Shortcut { get; set; }
        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        [Display( Name = "快捷菜单根节点" )]
        public bool? ShortcutRoot { get; set; }
        /// <summary>
        /// 是否允许复用
        /// </summary>
        [Display( Name = "是否允许复用" )]
        public bool? Reuse { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [Display( Name = "是否展开" )]
        public bool? Open { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Note { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Byte[] Version { get; set; }
    }
}