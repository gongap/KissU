using Util;
using KissU.Domain.Systems.Models;
using Util.Maps;

namespace KissU.Data.Pos.Systems.Extensions {
    /// <summary>
    /// 菜单持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为菜单实体
        /// </summary>
        /// <param name="po">菜单持久化对象</param>
        public static Menu ToEntity( this MenuPo po ) {
            if ( po == null )
                return null;
            return po.MapTo( new Menu( po.Id ) );
        }
        
        /// <summary>
        /// 转换为菜单实体
        /// </summary>
        /// <param name="po">菜单持久化对象</param>
        private static Menu ToEntity2( this MenuPo po ) {
            if( po == null )
                return null;
            return new Menu( po.Id ) {
                Text = po.Text,
                PinYin = po.PinYin,
                Enabled = po.Enabled,
                SortId = po.SortId,
                ParentId = po.ParentId,
                Path = po.Path,
                Level = po.Level,
                I18n = po.I18n,
                Group = po.Group,
                Link = po.Link,
                LinkExact = po.LinkExact,
                ExternalLink = po.ExternalLink,
                Target = po.Target,
                Icon = po.Icon,
                Badge = po.Badge,
                BadgeDot = po.BadgeDot,
                BadgeStatus = po.BadgeStatus,
                Disabled = po.Disabled,
                Hide = po.Hide,
                HideInBreadcrumb = po.HideInBreadcrumb,
                Acl = po.Acl,
                Shortcut = po.Shortcut,
                ShortcutRoot = po.ShortcutRoot,
                Reuse = po.Reuse,
                Open = po.Open,
                Note = po.Note,
                CreationTime = po.CreationTime,
                CreatorId = po.CreatorId,
                LastModificationTime = po.LastModificationTime,
                LastModifierId = po.LastModifierId,
                IsDeleted = po.IsDeleted,
                Version = po.Version,
            };
        }
        
        /// <summary>
        /// 转换为菜单持久化对象
        /// </summary>
        /// <param name="entity">菜单实体</param>
        public static MenuPo ToPo(this Menu entity) {
            if( entity == null )
                return null;
            return entity.MapTo<MenuPo>();
        }

        /// <summary>
        /// 转换为菜单持久化对象
        /// </summary>
        /// <param name="entity">菜单实体</param>
        private static MenuPo ToPo2( this Menu entity ) {
            if( entity == null )
                return null;
            return new MenuPo {
                Id = entity.Id,
                Text = entity.Text,
                PinYin = entity.PinYin,
                Enabled = entity.Enabled,
                SortId = entity.SortId,
                ParentId = entity.ParentId,
                Path = entity.Path,
                Level = entity.Level,
                I18n = entity.I18n,
                Group = entity.Group,
                Link = entity.Link,
                LinkExact = entity.LinkExact,
                ExternalLink = entity.ExternalLink,
                Target = entity.Target,
                Icon = entity.Icon,
                Badge = entity.Badge,
                BadgeDot = entity.BadgeDot,
                BadgeStatus = entity.BadgeStatus,
                Disabled = entity.Disabled,
                Hide = entity.Hide,
                HideInBreadcrumb = entity.HideInBreadcrumb,
                Acl = entity.Acl,
                Shortcut = entity.Shortcut,
                ShortcutRoot = entity.ShortcutRoot,
                Reuse = entity.Reuse,
                Open = entity.Open,
                Note = entity.Note,
                CreationTime = entity.CreationTime,
                CreatorId = entity.CreatorId,
                LastModificationTime = entity.LastModificationTime,
                LastModifierId = entity.LastModifierId,
                IsDeleted = entity.IsDeleted,
                Version = entity.Version,
            };
        }
    }
}
