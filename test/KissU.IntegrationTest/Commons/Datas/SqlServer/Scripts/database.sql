﻿/*========================================================== 1. 创建数据库 ===========================================================*/
USE [master]
GO

--删除数据库
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'KissU'
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'KissU')
Begin
DROP DATABASE [KissU]
End
GO

--创建数据库
CREATE DATABASE [KissU]
GO

/*========================================================== 2. 创建架构 ===========================================================*/
USE [KissU]
GO

/* 1. 系统模块[Systems] */
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'KissU')
DROP SCHEMA [Systems]
GO
CREATE SCHEMA [Systems] AUTHORIZATION [dbo]
GO

/*========================================================== 3. 创建表及索引 ===========================================================*/
/****** Object:  Table [Systems].[Api]    Script Date: 2019/6/30 16:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Systems].[Api](
	[ApiId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[DisplayName] [nvarchar](200) NULL,
	[Description] [nvarchar](1000) NULL,
	[ClaimTypes] [nvarchar](2000) NULL,
	[Enabled] [bit] NOT NULL,
	[CreationTime] [datetime] NULL,
	[CreatorId] [uniqueidentifier] NULL,
	[LastModificationTime] [datetime] NULL,
	[LastModifierId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_Api] PRIMARY KEY CLUSTERED 
(
	[ApiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Systems].[ApiScope]    Script Date: 2019/6/30 16:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Systems].[ApiScope](
	[ApiScopeId] [uniqueidentifier] NOT NULL,
	[ApiId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[DisplayName] [nvarchar](200) NULL,
	[Description] [nvarchar](1000) NULL,
	[ClaimTypes] [nvarchar](2000) NULL,
	[Required] [bit] NOT NULL,
	[Emphasize] [bit] NOT NULL,
	[ShowInDiscoveryDocument] [bit] NOT NULL,
	[CreationTime] [datetime] NULL,
	[CreatorId] [uniqueidentifier] NULL,
	[LastModificationTime] [datetime] NULL,
	[LastModifierId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ApiScope] PRIMARY KEY CLUSTERED 
(
	[ApiScopeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Systems].[Application]    Script Date: 2019/6/30 16:43:20 ******/
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
/****** Object:  Table [Systems].[Role]    Script Date: 2019/6/30 16:43:20 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api', @level2type=N'COLUMN',@level2name=N'ApiId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示名' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'声明类型' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api', @level2type=N'COLUMN',@level2name=N'ClaimTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Api资源' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'Api'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Api资源标识' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'ApiId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示名' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'声明类型' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'ClaimTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否必选' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'Required'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否强调' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'Emphasize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示在发现文档中' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope', @level2type=N'COLUMN',@level2name=N'ShowInDiscoveryDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Api许可范围' , @level0type=N'SCHEMA',@level0name=N'Systems', @level1type=N'TABLE',@level1name=N'ApiScope'
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
