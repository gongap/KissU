using Util;
using Util.Maps;
using KissU.Systems.Domain.Models;

namespace KissU.Service.Dtos.Systems.Extensions {
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MenuDtoExtension {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static Menu ToEntity( this MenuDto dto ) {
            if ( dto == null )
                return new Menu();
            return dto.MapTo( new Menu( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static Menu ToEntity2( this MenuDto dto ) {
            if( dto == null )
                return new Menu();
            return new Menu( dto.Id.ToGuid() ) {
                Text = dto.Text,
                PinYin = dto.PinYin,
                    Enabled = dto.Enabled.SafeValue(),
                SortId = dto.SortId,
                ParentId = dto.ParentId,
                Path = dto.Path,
                Level = dto.Level,
                I18n = dto.I18n,
                    Group = dto.Group.SafeValue(),
                Link = dto.Link,
                    LinkExact = dto.LinkExact.SafeValue(),
                ExternalLink = dto.ExternalLink,
                Target = dto.Target,
                Icon = dto.Icon,
                Badge = dto.Badge,
                    BadgeDot = dto.BadgeDot.SafeValue(),
                BadgeStatus = dto.BadgeStatus,
                    Disabled = dto.Disabled.SafeValue(),
                    Hide = dto.Hide.SafeValue(),
                    HideInBreadcrumb = dto.HideInBreadcrumb.SafeValue(),
                Acl = dto.Acl,
                    Shortcut = dto.Shortcut.SafeValue(),
                    ShortcutRoot = dto.ShortcutRoot.SafeValue(),
                    Reuse = dto.Reuse.SafeValue(),
                    Open = dto.Open.SafeValue(),
                Note = dto.Note,
                CreationTime = dto.CreationTime,
                CreatorId = dto.CreatorId,
                LastModificationTime = dto.LastModificationTime,
                LastModifierId = dto.LastModifierId,
                    IsDeleted = dto.IsDeleted.SafeValue(),
                Version = dto.Version,
            };
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static Menu ToEntity3( this MenuDto dto ) {
            if( dto == null )
                return new Menu();
            return MenuFactory.Create(
                id : dto.Id.ToGuid(),
                text : dto.Text,
                pinYin : dto.PinYin,
                enabled : dto.Enabled,
                sortId : dto.SortId,
                parentId : dto.ParentId,
                path : dto.Path,
                level : dto.Level,
                i18n : dto.I18n,
                group : dto.Group,
                link : dto.Link,
                linkExact : dto.LinkExact,
                externalLink : dto.ExternalLink,
                target : dto.Target,
                icon : dto.Icon,
                badge : dto.Badge,
                badgeDot : dto.BadgeDot,
                badgeStatus : dto.BadgeStatus,
                disabled : dto.Disabled,
                hide : dto.Hide,
                hideInBreadcrumb : dto.HideInBreadcrumb,
                acl : dto.Acl,
                shortcut : dto.Shortcut,
                shortcutRoot : dto.ShortcutRoot,
                reuse : dto.Reuse,
                open : dto.Open,
                note : dto.Note,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                isDeleted : dto.IsDeleted,
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MenuDto ToDto(this Menu entity) {
            if( entity == null )
                return new MenuDto();
            return entity.MapTo<MenuDto>();
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MenuDto ToDto2( this Menu entity ) {
            if( entity == null )
                return new MenuDto();
            return new MenuDto {
                Id = entity.Id.ToString(),
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