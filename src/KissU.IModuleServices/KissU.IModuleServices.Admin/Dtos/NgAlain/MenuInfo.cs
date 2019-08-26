using System.Collections.Generic;
using Newtonsoft.Json;

namespace KissU.IModuleServices.Admin.Dtos.NgAlain
{
    /// <summary>
    /// NgAlain菜单
    /// </summary>
    public class MenuInfo
    {
        /// <summary>
        /// 初始化NgAlain菜单
        /// </summary>
        public MenuInfo()
        {
            Children = new List<MenuInfo>();
            Group = true;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 外部链接
        /// </summary>
        public string ExternalLink { get; set; }

        /// <summary>
        /// 链接目标
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 国际化
        /// </summary>
        [JsonProperty("i18n")]
        public string I18N { get; set; }

        /// <summary>
        /// 组
        /// </summary>
        public bool Group { get; set; }

        /// <summary>
        /// 不要在面包屑导航中显示
        /// </summary>
        public bool HideInBreadcrumb { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuInfo> Children { get; set; }
    }
}