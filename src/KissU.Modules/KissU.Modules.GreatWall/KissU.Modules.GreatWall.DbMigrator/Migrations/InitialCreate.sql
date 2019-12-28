IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'Systems') IS NULL EXEC(N'CREATE SCHEMA [Systems];');

GO

CREATE TABLE [Systems].[Application] (
    [ApplicationId] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [Code] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Enabled] bit NOT NULL,
    [RegisterEnabled] bit NOT NULL,
    [Remark] nvarchar(max) NULL,
    [Extend] nvarchar(max) NULL,
    [CreationTime] datetime2 NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Application] PRIMARY KEY ([ApplicationId])
);

GO

CREATE TABLE [Systems].[Claim] (
    [ClaimId] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [Name] nvarchar(200) NOT NULL,
    [Enabled] bit NOT NULL,
    [SortId] int NULL,
    [Remark] nvarchar(500) NULL,
    [CreationTime] datetime2 NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Claim] PRIMARY KEY ([ClaimId])
);

GO

CREATE TABLE [Systems].[Permission] (
    [PermissionId] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [RoleId] uniqueidentifier NOT NULL,
    [ResourceId] uniqueidentifier NOT NULL,
    [IsDeny] bit NOT NULL,
    [Sign] nvarchar(256) NULL,
    [CreationTime] datetime2 NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY ([PermissionId])
);

GO

CREATE TABLE [Systems].[Role] (
    [RoleId] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [ParentId] uniqueidentifier NULL,
    [Path] nvarchar(max) NOT NULL,
    [Level] int NOT NULL,
    [Enabled] bit NOT NULL,
    [SortId] int NULL,
    [Code] nvarchar(256) NOT NULL,
    [Name] nvarchar(256) NOT NULL,
    [NormalizedName] nvarchar(256) NOT NULL,
    [Type] nvarchar(80) NOT NULL,
    [IsAdmin] bit NOT NULL,
    [Remark] nvarchar(500) NULL,
    [PinYin] nvarchar(200) NULL,
    [Sign] nvarchar(256) NULL,
    [CreationTime] datetime2 NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([RoleId])
);

GO

CREATE TABLE [Systems].[User] (
    [UserId] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PhoneNumber] nvarchar(64) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [Password] nvarchar(256) NULL,
    [PasswordHash] nvarchar(1024) NULL,
    [SafePassword] nvarchar(256) NULL,
    [SafePasswordHash] nvarchar(1024) NULL,
    [LockoutEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LastLoginTime] datetime2 NULL,
    [LastLoginIp] nvarchar(30) NULL,
    [CurrentLoginTime] datetime2 NULL,
    [CurrentLoginIp] nvarchar(30) NULL,
    [LoginCount] int NULL,
    [AccessFailedCount] int NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [Enabled] bit NOT NULL,
    [DisabledTime] datetime2 NULL,
    [RegisterIp] nvarchar(30) NULL,
    [SecurityStamp] nvarchar(1024) NULL,
    [Remark] nvarchar(500) NULL,
    [CreationTime] datetime2 NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [Systems].[UserRole] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId])
);

GO

CREATE TABLE [Systems].[Resource] (
    [ResourceId] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [ParentId] uniqueidentifier NULL,
    [Path] nvarchar(max) NULL,
    [Level] int NOT NULL,
    [Enabled] bit NOT NULL,
    [SortId] int NULL,
    [ApplicationId] uniqueidentifier NULL,
    [Uri] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Type] int NOT NULL,
    [Remark] nvarchar(max) NULL,
    [PinYin] nvarchar(max) NULL,
    [Extend] nvarchar(max) NULL,
    [CreationTime] datetime2 NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Resource] PRIMARY KEY ([ResourceId]),
    CONSTRAINT [FK_Resource_Application_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Systems].[Application] ([ApplicationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Resource_Resource_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Systems].[Resource] ([ResourceId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Resource_ApplicationId] ON [Systems].[Resource] ([ApplicationId]);

GO

CREATE INDEX [IX_Resource_ParentId] ON [Systems].[Resource] ([ParentId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191228154130_InitialCreate', N'3.1.0');

GO

