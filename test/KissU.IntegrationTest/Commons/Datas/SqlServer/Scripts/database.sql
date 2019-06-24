USE [KissU]
GO
/****** Object:  Schema [Systems]    Script Date: 2019/6/23 15:25:08 ******/
CREATE SCHEMA [Systems]
GO
/****** Object:  Table [Systems].[Application]    Script Date: 2019/6/23 15:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Systems].[Application](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](60) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Comment] [nvarchar](500) NULL,
	[Enabled] [bit] NOT NULL,
	[RegisterEnabled] [bit] NOT NULL,
	[CreationTime] [datetime] NULL,
	[CreatorId] [uniqueidentifier] NULL,
	[LastModificationTime] [datetime] NULL,
	[LastModifierId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_APPLICATION] PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Systems].[Menu]    Script Date: 2019/6/23 15:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Systems].[Menu](
	[MenuId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
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
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Systems].[Role]    Script Date: 2019/6/23 15:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Systems].[Role](
	[RoleId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[NormalizedName] [nvarchar](256) NOT NULL,
	[Type] [nvarchar](80) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Path] [nvarchar](800) NOT NULL,
	[Level] [int] NOT NULL,
	[SortId] [int] NULL,
	[Enabled] [bit] NOT NULL,
	[Comment] [nvarchar](500) NULL,
	[PinYin] [nvarchar](200) NULL,
	[Sign] [nvarchar](256) NULL,
	[CreationTime] [datetime] NULL,
	[CreatorId] [uniqueidentifier] NULL,
	[LastModificationTime] [datetime] NULL,
	[LastModifierId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_ROLE] PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用程序编号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用程序编码' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用程序名称' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用注册' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'RegisterEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'CreationTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改时间' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'LastModificationTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改人编号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'LastModifierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用程序' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Application'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编码' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Name'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编码' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准化角色名称' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'NormalizedName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色类型' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'IsAdmin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父编号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路径' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'级数' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'SortId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拼音简码' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'PinYin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签名' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Sign'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreationTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人编号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改时间' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'LastModificationTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改人编号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'LastModifierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本号' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Role'
GO
