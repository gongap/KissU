USE [KissU]
GO

/****** Object:  Table [Systems].[Menu]    Script Date: 2019/6/17 22:49:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Systems].[Menu](
	[Id] [uniqueidentifier] NOT NULL,
	[Text] [nvarchar](256) NOT NULL,
	[PinYin] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[SortId] [int] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Path] [nvarchar](800) NOT NULL,
	[Level] [int] NOT NULL,
	[I18n] [nvarchar](50) NULL,
	[Group] [bit] NULL,
	[Link] [nvarchar](256) NULL,
	[LinkExact] [bit] NULL,
	[ExternalLink] [nvarchar](256) NULL,
	[Target] [nvarchar](20) NULL,
	[Icon] [nvarchar](256) NULL,
	[Badge] [int] NULL,
	[BadgeDot] [bit] NULL,
	[BadgeStatus] [nvarchar](20) NULL,
	[Disabled] [bit] NULL,
	[Hide] [bit] NULL,
	[HideInBreadcrumb] [bit] NULL,
	[ACL] [nvarchar](50) NULL,
	[Shortcut] [bit] NULL,
	[ShortcutRoot] [bit] NULL,
	[Reuse] [bit] NULL,
	[Open] [bit] NULL,
	[Note] [nvarchar](500) NULL,
	[CreationTime] [datetime] NULL,
	[CreatorId] [uniqueidentifier] NULL,
	[LastModificationTime] [datetime] NULL,
	[LastModifierId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文本' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拼音' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'PinYin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序标识' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'SortId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父节点标识' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ParentId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路径' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Path'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'层级' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Level'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'i18n主键' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'I18n'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示分组名' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Group'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路由' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Link'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路由是否精准匹配' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'LinkExact'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部链接' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ExternalLink'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接 target' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Target'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Icon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'徽标数，展示的数字' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Badge'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'徽标数，显示小红点' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'BadgeDot'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'徽标 Badge 颜色' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'BadgeStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否禁用' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Disabled'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否隐藏菜单' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Hide'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隐藏面包屑' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'HideInBreadcrumb'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ACL配置' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ACL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否快捷菜单项' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Shortcut'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快捷菜单根节点' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ShortcutRoot'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许复用' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Reuse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否展开' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Open'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Note'
GO


