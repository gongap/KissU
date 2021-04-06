﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AbpClaimTypes] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(256) NOT NULL,
    [Required] bit NOT NULL,
    [IsStatic] bit NOT NULL,
    [Regex] nvarchar(512) NULL,
    [RegexDescription] nvarchar(128) NULL,
    [Description] nvarchar(256) NULL,
    [ValueType] int NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    CONSTRAINT [PK_AbpClaimTypes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AbpLinkUsers] (
    [Id] uniqueidentifier NOT NULL,
    [SourceUserId] uniqueidentifier NOT NULL,
    [SourceTenantId] uniqueidentifier NULL,
    [TargetUserId] uniqueidentifier NOT NULL,
    [TargetTenantId] uniqueidentifier NULL,
    CONSTRAINT [PK_AbpLinkUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AbpOrganizationUnits] (
    [Id] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [ParentId] uniqueidentifier NULL,
    [Code] nvarchar(95) NOT NULL,
    [DisplayName] nvarchar(128) NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [DeleterId] uniqueidentifier NULL,
    [DeletionTime] datetime2 NULL,
    CONSTRAINT [PK_AbpOrganizationUnits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [AbpOrganizationUnits] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [AbpRoles] (
    [Id] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [Name] nvarchar(256) NOT NULL,
    [NormalizedName] nvarchar(256) NOT NULL,
    [IsDefault] bit NOT NULL,
    [IsStatic] bit NOT NULL,
    [IsPublic] bit NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    CONSTRAINT [PK_AbpRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AbpSecurityLogs] (
    [Id] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [ApplicationName] nvarchar(96) NULL,
    [Identity] nvarchar(96) NULL,
    [Action] nvarchar(96) NULL,
    [UserId] uniqueidentifier NULL,
    [UserName] nvarchar(256) NULL,
    [TenantName] nvarchar(64) NULL,
    [ClientId] nvarchar(64) NULL,
    [CorrelationId] nvarchar(64) NULL,
    [ClientIpAddress] nvarchar(64) NULL,
    [BrowserInfo] nvarchar(512) NULL,
    [CreationTime] datetime2 NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    CONSTRAINT [PK_AbpSecurityLogs] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AbpUsers] (
    [Id] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [UserName] nvarchar(256) NOT NULL,
    [NormalizedUserName] nvarchar(256) NOT NULL,
    [Name] nvarchar(64) NULL,
    [Surname] nvarchar(64) NULL,
    [Email] nvarchar(256) NOT NULL,
    [NormalizedEmail] nvarchar(256) NOT NULL,
    [EmailConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit),
    [PasswordHash] nvarchar(256) NULL,
    [SecurityStamp] nvarchar(256) NOT NULL,
    [IsExternal] bit NOT NULL DEFAULT CAST(0 AS bit),
    [PhoneNumber] nvarchar(16) NULL,
    [PhoneNumberConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit),
    [TwoFactorEnabled] bit NOT NULL DEFAULT CAST(0 AS bit),
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL DEFAULT CAST(0 AS bit),
    [AccessFailedCount] int NOT NULL DEFAULT 0,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(40) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [DeleterId] uniqueidentifier NULL,
    [DeletionTime] datetime2 NULL,
    CONSTRAINT [PK_AbpUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AbpOrganizationUnitRoles] (
    [RoleId] uniqueidentifier NOT NULL,
    [OrganizationUnitId] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_AbpOrganizationUnitRoles] PRIMARY KEY ([OrganizationUnitId], [RoleId]),
    CONSTRAINT [FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUnitId] FOREIGN KEY ([OrganizationUnitId]) REFERENCES [AbpOrganizationUnits] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AbpOrganizationUnitRoles_AbpRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AbpRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AbpRoleClaims] (
    [Id] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [ClaimType] nvarchar(256) NOT NULL,
    [ClaimValue] nvarchar(1024) NULL,
    CONSTRAINT [PK_AbpRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AbpRoleClaims_AbpRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AbpRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AbpUserClaims] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [ClaimType] nvarchar(256) NOT NULL,
    [ClaimValue] nvarchar(1024) NULL,
    CONSTRAINT [PK_AbpUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AbpUserClaims_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AbpUserLogins] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(64) NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [ProviderKey] nvarchar(196) NOT NULL,
    [ProviderDisplayName] nvarchar(128) NULL,
    CONSTRAINT [PK_AbpUserLogins] PRIMARY KEY ([UserId], [LoginProvider]),
    CONSTRAINT [FK_AbpUserLogins_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AbpUserOrganizationUnits] (
    [UserId] uniqueidentifier NOT NULL,
    [OrganizationUnitId] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_AbpUserOrganizationUnits] PRIMARY KEY ([OrganizationUnitId], [UserId]),
    CONSTRAINT [FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUnitId] FOREIGN KEY ([OrganizationUnitId]) REFERENCES [AbpOrganizationUnits] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AbpUserOrganizationUnits_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AbpUserRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    CONSTRAINT [PK_AbpUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AbpUserRoles_AbpRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AbpRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AbpUserRoles_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AbpUserTokens] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(64) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AbpUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AbpUserTokens_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_AbpLinkUsers_SourceUserId_SourceTenantId_TargetUserId_TargetTenantId] ON [AbpLinkUsers] ([SourceUserId], [SourceTenantId], [TargetUserId], [TargetTenantId]) WHERE [SourceTenantId] IS NOT NULL AND [TargetTenantId] IS NOT NULL;
GO

CREATE INDEX [IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId] ON [AbpOrganizationUnitRoles] ([RoleId], [OrganizationUnitId]);
GO

CREATE INDEX [IX_AbpOrganizationUnits_Code] ON [AbpOrganizationUnits] ([Code]);
GO

CREATE INDEX [IX_AbpOrganizationUnits_ParentId] ON [AbpOrganizationUnits] ([ParentId]);
GO

CREATE INDEX [IX_AbpRoleClaims_RoleId] ON [AbpRoleClaims] ([RoleId]);
GO

CREATE INDEX [IX_AbpRoles_NormalizedName] ON [AbpRoles] ([NormalizedName]);
GO

CREATE INDEX [IX_AbpSecurityLogs_TenantId_Action] ON [AbpSecurityLogs] ([TenantId], [Action]);
GO

CREATE INDEX [IX_AbpSecurityLogs_TenantId_ApplicationName] ON [AbpSecurityLogs] ([TenantId], [ApplicationName]);
GO

CREATE INDEX [IX_AbpSecurityLogs_TenantId_Identity] ON [AbpSecurityLogs] ([TenantId], [Identity]);
GO

CREATE INDEX [IX_AbpSecurityLogs_TenantId_UserId] ON [AbpSecurityLogs] ([TenantId], [UserId]);
GO

CREATE INDEX [IX_AbpUserClaims_UserId] ON [AbpUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AbpUserLogins_LoginProvider_ProviderKey] ON [AbpUserLogins] ([LoginProvider], [ProviderKey]);
GO

CREATE INDEX [IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId] ON [AbpUserOrganizationUnits] ([UserId], [OrganizationUnitId]);
GO

CREATE INDEX [IX_AbpUserRoles_RoleId_UserId] ON [AbpUserRoles] ([RoleId], [UserId]);
GO

CREATE INDEX [IX_AbpUsers_Email] ON [AbpUsers] ([Email]);
GO

CREATE INDEX [IX_AbpUsers_NormalizedEmail] ON [AbpUsers] ([NormalizedEmail]);
GO

CREATE INDEX [IX_AbpUsers_NormalizedUserName] ON [AbpUsers] ([NormalizedUserName]);
GO

CREATE INDEX [IX_AbpUsers_UserName] ON [AbpUsers] ([UserName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210317082309_InitialCreate', N'5.0.4');
GO

COMMIT;
GO

