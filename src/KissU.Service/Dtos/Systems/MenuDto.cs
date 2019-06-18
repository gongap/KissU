using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;
using Util.Ui.Data;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// 菜单数据传输对象
    /// </summary>
    [Model("model")]
    public class MenuDto : TreeDto<MenuDto> {
        /// <summary>
        /// 文本
        /// </summary>
        [Required(ErrorMessage = "文本不能为空")]
        [StringLength( 256, ErrorMessage = "文本输入过长，不能超过256位" )]
        [Display( Name = "文本" )]
        [DataMember]
        public string Text { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [Required(ErrorMessage = "拼音不能为空")]
        [StringLength( 200, ErrorMessage = "拼音输入过长，不能超过200位" )]
        [Display( Name = "拼音" )]
        [DataMember]
        public string PinYin { get; set; }
        /// <summary>
        /// i18n主键
        /// </summary>
        [StringLength( 50, ErrorMessage = "i18n主键输入过长，不能超过50位" )]
        [Display( Name = "i18n主键" )]
        [DataMember]
        public string I18n { get; set; }
        /// <summary>
        /// 是否显示分组名
        /// </summary>
        [Display( Name = "是否显示分组名" )]
        [DataMember]
        public bool? Group { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        [StringLength( 256, ErrorMessage = "路由输入过长，不能超过256位" )]
        [Display( Name = "路由" )]
        [DataMember]
        public string Link { get; set; }
        /// <summary>
        /// 路由是否精准匹配
        /// </summary>
        [Display( Name = "路由是否精准匹配" )]
        [DataMember]
        public bool? LinkExact { get; set; }
        /// <summary>
        /// 外部链接
        /// </summary>
        [StringLength( 256, ErrorMessage = "外部链接输入过长，不能超过256位" )]
        [Display( Name = "外部链接" )]
        [DataMember]
        public string ExternalLink { get; set; }
        /// <summary>
        /// 链接 target
        /// </summary>
        [StringLength( 20, ErrorMessage = "链接 target输入过长，不能超过20位" )]
        [Display( Name = "链接 target" )]
        [DataMember]
        public string Target { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength( 256, ErrorMessage = "图标输入过长，不能超过256位" )]
        [Display( Name = "图标" )]
        [DataMember]
        public string Icon { get; set; }
        /// <summary>
        /// 徽标数，展示的数字
        /// </summary>
        [Display( Name = "徽标数，展示的数字" )]
        [DataMember]
        public int? Badge { get; set; }
        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        [Display( Name = "徽标数，显示小红点" )]
        [DataMember]
        public bool? BadgeDot { get; set; }
        /// <summary>
        /// 徽标 Badge 颜色
        /// </summary>
        [StringLength( 20, ErrorMessage = "徽标 Badge 颜色输入过长，不能超过20位" )]
        [Display( Name = "徽标 Badge 颜色" )]
        [DataMember]
        public string BadgeStatus { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        [Display( Name = "是否禁用" )]
        [DataMember]
        public bool? Disabled { get; set; }
        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        [Display( Name = "是否隐藏菜单" )]
        [DataMember]
        public bool? Hide { get; set; }
        /// <summary>
        /// 隐藏面包屑
        /// </summary>
        [Display( Name = "隐藏面包屑" )]
        [DataMember]
        public bool? HideInBreadcrumb { get; set; }
        /// <summary>
        /// ACL配置
        /// </summary>
        [StringLength( 50, ErrorMessage = "ACL配置输入过长，不能超过50位" )]
        [Display( Name = "ACL配置" )]
        [DataMember]
        public string Acl { get; set; }
        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        [Display( Name = "是否快捷菜单项" )]
        [DataMember]
        public bool? Shortcut { get; set; }
        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        [Display( Name = "快捷菜单根节点" )]
        [DataMember]
        public bool? ShortcutRoot { get; set; }
        /// <summary>
        /// 是否允许复用
        /// </summary>
        [Display( Name = "是否允许复用" )]
        [DataMember]
        public bool? Reuse { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [Display( Name = "是否展开" )]
        [DataMember]
        public bool? Open { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        [Display( Name = "备注" )]
        [DataMember]
        public string Note { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        [DataMember]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        [DataMember]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        [DataMember]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        [DataMember]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        [DataMember]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        [DataMember]
        public Byte[] Version { get; set; }
    }
}