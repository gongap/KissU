using Util;
using Util.Maps;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Factories;

namespace KissU.Service.Dtos.Systems.Extensions {
    /// <summary>
    /// 菜单数据传输对象扩展
    /// </summary>
    public static class MenuDtoExtension {
        /// <summary>
        /// 转换为菜单实体
        /// </summary>
        /// <param name="dto">菜单数据传输对象</param>
        public static Menu ToEntity( this MenuDto dto ) {
            if ( dto == null )
                return new Menu();
				return dto.MapTo( new Menu( dto.Id.ToGuid(), dto.Path, dto.Level.SafeValue() ) );
        }
        
        /// <summary>
        /// 转换为菜单实体
        /// </summary>
        /// <param name="dto">菜单数据传输对象</param>
        public static Menu ToEntity2( this MenuDto dto ) {
            if( dto == null )
                return new Menu();
            return 
				new Menu( dto.Id.ToGuid(),dto.Path, dto.Level.SafeValue() ) {
                Code = dto.Code,
                Name = dto.Name,
                PinYin = dto.PinYin,
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
        /// 转换为菜单实体
        /// </summary>
        /// <param name="dto">菜单数据传输对象</param>
        public static Menu ToEntity3( this MenuDto dto ) {
            if( dto == null )
                return new Menu();
            return MenuFactory.Create(
                menuId : dto.Id.ToGuid(),
                code : dto.Code,
                name : dto.Name,
                pinYin : dto.PinYin,
                enabled : dto.Enabled.SafeValue(),
                sortId : dto.SortId.SafeValue(),
                parentId : dto.ParentId.ToGuidOrNull(),
                path : dto.Path,
                level : dto.Level.SafeValue(),
                i18n : dto.I18n,
                group : dto.Group.SafeValue(),
                link : dto.Link,
                linkExact : dto.LinkExact.SafeValue(),
                externalLink : dto.ExternalLink,
                target : dto.Target,
                icon : dto.Icon,
                badge : dto.Badge.SafeValue(),
                badgeDot : dto.BadgeDot.SafeValue(),
                badgeStatus : dto.BadgeStatus,
                disabled : dto.Disabled.SafeValue(),
                hide : dto.Hide.SafeValue(),
                hideInBreadcrumb : dto.HideInBreadcrumb.SafeValue(),
                acl : dto.Acl,
                shortcut : dto.Shortcut.SafeValue(),
                shortcutRoot : dto.ShortcutRoot.SafeValue(),
                reuse : dto.Reuse.SafeValue(),
                open : dto.Open.SafeValue(),
                note : dto.Note,
                creationTime : dto.CreationTime,
                creatorId : dto.CreatorId,
                lastModificationTime : dto.LastModificationTime,
                lastModifierId : dto.LastModifierId,
                isDeleted : dto.IsDeleted.SafeValue(),
                version : dto.Version
            );
        }
        
        /// <summary>
        /// 转换为菜单数据传输对象
        /// </summary>
        /// <param name="entity">菜单实体</param>
        public static MenuDto ToDto(this Menu entity) {
            if( entity == null )
                return new MenuDto();
            return entity.MapTo<MenuDto>();
        }

        /// <summary>
        /// 转换为菜单数据传输对象
        /// </summary>
        /// <param name="entity">菜单实体</param>
        public static MenuDto ToDto2( this Menu entity ) {
            if( entity == null )
                return new MenuDto();
            return new MenuDto {
                Id = entity.Id.ToString(),
                Code = entity.Code,
                Name = entity.Name,
                PinYin = entity.PinYin,
                Enabled = entity.Enabled,
                SortId = entity.SortId,
                ParentId = entity.ParentId.SafeString(),
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