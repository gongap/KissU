using System;
using KissU.Systems.Domains.Models;

namespace KissU.Systems.Domains.Factories {
    /// <summary>
    /// 工厂
    /// </summary>
    public static class MenuFactory {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text">文本</param>
        /// <param name="pinYin">拼音</param>
        /// <param name="enabled"></param>
        /// <param name="sortId">排序标识</param>
        /// <param name="parentId">父节点标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        /// <param name="i18n">i18n主键</param>
        /// <param name="group">是否显示分组名</param>
        /// <param name="link">路由</param>
        /// <param name="linkExact">路由是否精准匹配</param>
        /// <param name="externalLink">外部链接</param>
        /// <param name="target">链接 target</param>
        /// <param name="icon">图标</param>
        /// <param name="badge">徽标数，展示的数字</param>
        /// <param name="badgeDot">徽标数，显示小红点</param>
        /// <param name="badgeStatus">徽标 Badge 颜色</param>
        /// <param name="disabled">是否禁用</param>
        /// <param name="hide">是否隐藏菜单</param>
        /// <param name="hideInBreadcrumb">隐藏面包屑</param>
        /// <param name="acl">ACL配置</param>
        /// <param name="shortcut">是否快捷菜单项</param>
        /// <param name="shortcutRoot">快捷菜单根节点</param>
        /// <param name="reuse">是否允许复用</param>
        /// <param name="open">是否展开</param>
        /// <param name="note">备注</param>
        /// <param name="creationTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="lastModificationTime"></param>
        /// <param name="lastModifierId"></param>
        /// <param name="isDeleted"></param>
        /// <param name="version"></param>
        public static Menu Create( 
            Guid id,
            string text,
            string pinYin,
            bool enabled,
            int? sortId,
            Guid? parentId,
            string path,
            int level,
            string i18n,
            bool? group,
            string link,
            bool? linkExact,
            string externalLink,
            string target,
            string icon,
            int? badge,
            bool? badgeDot,
            string badgeStatus,
            bool? disabled,
            bool? hide,
            bool? hideInBreadcrumb,
            string acl,
            bool? shortcut,
            bool? shortcutRoot,
            bool? reuse,
            bool? open,
            string note,
            DateTime? creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            Byte[] version
        ) {
            Menu result;
            result = new Menu( id );
            result.Text = text;
            result.PinYin = pinYin;
            result.Enabled = enabled;
            result.SortId = sortId;
            result.ParentId = parentId;
            result.Path = path;
            result.Level = level;
            result.I18n = i18n;
            result.Group = group;
            result.Link = link;
            result.LinkExact = linkExact;
            result.ExternalLink = externalLink;
            result.Target = target;
            result.Icon = icon;
            result.Badge = badge;
            result.BadgeDot = badgeDot;
            result.BadgeStatus = badgeStatus;
            result.Disabled = disabled;
            result.Hide = hide;
            result.HideInBreadcrumb = hideInBreadcrumb;
            result.Acl = acl;
            result.Shortcut = shortcut;
            result.ShortcutRoot = shortcutRoot;
            result.Reuse = reuse;
            result.Open = open;
            result.Note = note;
            result.CreationTime = creationTime;
            result.CreatorId = creatorId;
            result.LastModificationTime = lastModificationTime;
            result.LastModifierId = lastModifierId;
            result.IsDeleted = isDeleted;
            result.Version = version;
            return result;
        }
    }
}