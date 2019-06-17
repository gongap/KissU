using System;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Datas.Persistence;

namespace KissU.Data.Pos.Systems{
    /// <summary>
    /// 持久化对象
    /// </summary>
    public class MenuPo : TreePersistentObjectBase,IDelete,IAudited {
        /// <summary>
        /// 文本
        /// </summary>  
        public string Text { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>  
        public string PinYin { get; set; }
        /// <summary>
        /// i18n主键
        /// </summary>  
        public string I18n { get; set; }
        /// <summary>
        /// 是否显示分组名
        /// </summary>  
        public bool? Group { get; set; }
        /// <summary>
        /// 路由
        /// </summary>  
        public string Link { get; set; }
        /// <summary>
        /// 路由是否精准匹配
        /// </summary>  
        public bool? LinkExact { get; set; }
        /// <summary>
        /// 外部链接
        /// </summary>  
        public string ExternalLink { get; set; }
        /// <summary>
        /// 链接 target
        /// </summary>  
        public string Target { get; set; }
        /// <summary>
        /// 图标
        /// </summary>  
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
    }
}