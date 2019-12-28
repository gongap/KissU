IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'ids') IS NULL EXEC(N'CREATE SCHEMA [ids];');

GO

CREATE TABLE [ids].[ApiResources] (
    [Id] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [Enabled] bit NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [DisplayName] nvarchar(200) NULL,
    [Description] nvarchar(1000) NULL,
    CONSTRAINT [PK_ApiResources] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ids].[Clients] (
    [Id] int NOT NULL IDENTITY,
    [Version] rowversion NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [ClientName] nvarchar(200) NULL,
    [Enabled] bit NOT NULL,
    [Description] nvarchar(1000) NULL,
    [ProtocolType] nvarchar(200) NOT NULL,
    [UserCodeType] nvarchar(100) NULL,
    [RequireClientSecret] bit NOT NULL,
    [RequirePkce] bit NOT NULL,
    [AllowPlainTextPkce] bit NOT NULL,
    [AllowOfflineAccess] bit NOT NULL,
    [AllowAccessTokensViaBrowser] bit NOT NULL,
    [FrontChannelLogoutUri] nvarchar(2000) NULL,
    [FrontChannelLogoutSessionRequired] bit NOT NULL,
    [BackChannelLogoutUri] nvarchar(2000) NULL,
    [BackChannelLogoutSessionRequired] bit NOT NULL,
    [EnableLocalLogin] bit NOT NULL,
    [IdentityTokenLifetime] int NOT NULL,
    [AccessTokenLifetime] int NOT NULL,
    [AuthorizationCodeLifetime] int NOT NULL,
    [AbsoluteRefreshTokenLifetime] int NOT NULL,
    [SlidingRefreshTokenLifetime] int NOT NULL,
    [RefreshTokenUsage] int NOT NULL,
    [RefreshTokenExpiration] int NOT NULL,
    [UpdateAccessTokenClaimsOnRefresh] bit NOT NULL,
    [AccessTokenType] int NOT NULL,
    [IncludeJwtId] bit NOT NULL,
    [AlwaysSendClientClaims] bit NOT NULL,
    [AlwaysIncludeUserClaimsInIdToken] bit NOT NULL,
    [ClientClaimsPrefix] nvarchar(200) NULL,
    [PairWiseSubjectSalt] nvarchar(200) NULL,
    [RequireConsent] bit NOT NULL,
    [AllowRememberConsent] bit NOT NULL,
    [ConsentLifetime] int NULL,
    [ClientUri] nvarchar(2000) NULL,
    [LogoUri] nvarchar(2000) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ids].[DeviceFlowCodes] (
    [UserCode] nvarchar(200) NOT NULL,
    [Id] int NOT NULL,
    [Version] rowversion NULL,
    [DeviceCode] nvarchar(200) NOT NULL,
    [SubjectId] nvarchar(200) NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [Expiration] datetime2 NOT NULL,
    [Data] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DeviceFlowCodes] PRIMARY KEY ([UserCode])
);

GO

CREATE TABLE [ids].[IdentityResources] (
    [Id] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [Required] bit NOT NULL,
    [Emphasize] bit NOT NULL,
    [ShowInDiscoveryDocument] bit NOT NULL,
    [Enabled] bit NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [DisplayName] nvarchar(200) NULL,
    [Description] nvarchar(1000) NULL,
    CONSTRAINT [PK_IdentityResources] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ids].[PersistedGrants] (
    [Key] nvarchar(200) NOT NULL,
    [Id] int NOT NULL,
    [Version] rowversion NULL,
    [Type] nvarchar(50) NOT NULL,
    [SubjectId] nvarchar(200) NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [Data] nvarchar(max) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [Expiration] datetime2 NULL,
    CONSTRAINT [PK_PersistedGrants] PRIMARY KEY ([Key])
);

GO

CREATE TABLE [ids].[ApiClaims] (
    [ApiResourceId] uniqueidentifier NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(200) NULL,
    CONSTRAINT [PK_ApiClaims] PRIMARY KEY ([ApiResourceId], [Id]),
    CONSTRAINT [FK_ApiClaims_ApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [ids].[ApiResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ApiProperties] (
    [ApiResourceId] uniqueidentifier NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Key] nvarchar(250) NOT NULL,
    [Value] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_ApiProperties] PRIMARY KEY ([ApiResourceId], [Id]),
    CONSTRAINT [FK_ApiProperties_ApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [ids].[ApiResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ApiScopes] (
    [Id] uniqueidentifier NOT NULL,
    [ApiResourceId] uniqueidentifier NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [DisplayName] nvarchar(200) NULL,
    [Description] nvarchar(1000) NULL,
    [Required] bit NOT NULL,
    [Emphasize] bit NOT NULL,
    [ShowInDiscoveryDocument] bit NOT NULL,
    CONSTRAINT [PK_ApiScopes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ApiScopes_ApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [ids].[ApiResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ApiSecrets] (
    [Id] uniqueidentifier NOT NULL,
    [ApiResourceId] uniqueidentifier NOT NULL,
    [Type] nvarchar(250) NOT NULL,
    [Value] nvarchar(4000) NOT NULL,
    [Description] nvarchar(1000) NULL,
    [Expiration] datetime2 NULL,
    CONSTRAINT [PK_ApiSecrets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ApiSecrets_ApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [ids].[ApiResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientClaims] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [Type] nvarchar(250) NOT NULL,
    [Value] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_ClientClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClientClaims_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientCorsOrigins] (
    [ClientId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Origin] nvarchar(150) NOT NULL,
    CONSTRAINT [PK_ClientCorsOrigins] PRIMARY KEY ([ClientId], [Id]),
    CONSTRAINT [FK_ClientCorsOrigins_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientGrantTypes] (
    [ClientId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [GrantType] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_ClientGrantTypes] PRIMARY KEY ([ClientId], [Id]),
    CONSTRAINT [FK_ClientGrantTypes_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientIdPRestrictions] (
    [ClientId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Provider] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_ClientIdPRestrictions] PRIMARY KEY ([ClientId], [Id]),
    CONSTRAINT [FK_ClientIdPRestrictions_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientPostLogoutRedirectUris] (
    [ClientId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [PostLogoutRedirectUri] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_ClientPostLogoutRedirectUris] PRIMARY KEY ([ClientId], [Id]),
    CONSTRAINT [FK_ClientPostLogoutRedirectUris_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientPropertys] (
    [ClientId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Key] nvarchar(250) NOT NULL,
    [Value] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_ClientPropertys] PRIMARY KEY ([ClientId], [Id]),
    CONSTRAINT [FK_ClientPropertys_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientRedirectUris] (
    [ClientId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [RedirectUri] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_ClientRedirectUris] PRIMARY KEY ([ClientId], [Id]),
    CONSTRAINT [FK_ClientRedirectUris_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientScopes] (
    [ClientId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Scope] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_ClientScopes] PRIMARY KEY ([ClientId], [Id]),
    CONSTRAINT [FK_ClientScopes_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ClientSecrets] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [Type] nvarchar(250) NOT NULL,
    [Value] nvarchar(4000) NOT NULL,
    [Description] nvarchar(2000) NULL,
    [Expiration] datetime2 NULL,
    CONSTRAINT [PK_ClientSecrets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClientSecrets_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [ids].[Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[IdentityClaims] (
    [IdentityResourceId] uniqueidentifier NOT NULL,
    [Id] int NOT NULL,
    [Type] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_IdentityClaims] PRIMARY KEY ([IdentityResourceId], [Id]),
    CONSTRAINT [FK_IdentityClaims_IdentityResources_IdentityResourceId] FOREIGN KEY ([IdentityResourceId]) REFERENCES [ids].[IdentityResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[IdentityProperties] (
    [IdentityResourceId] uniqueidentifier NOT NULL,
    [Id] int NOT NULL,
    [Key] nvarchar(250) NOT NULL,
    [Value] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_IdentityProperties] PRIMARY KEY ([IdentityResourceId], [Id]),
    CONSTRAINT [FK_IdentityProperties_IdentityResources_IdentityResourceId] FOREIGN KEY ([IdentityResourceId]) REFERENCES [ids].[IdentityResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ids].[ApiScopeClaims] (
    [ApiScopeId] uniqueidentifier NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_ApiScopeClaims] PRIMARY KEY ([ApiScopeId], [Id]),
    CONSTRAINT [FK_ApiScopeClaims_ApiScopes_ApiScopeId] FOREIGN KEY ([ApiScopeId]) REFERENCES [ids].[ApiScopes] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_ApiResources_Name] ON [ids].[ApiResources] ([Name]);

GO

CREATE INDEX [IX_ApiScopes_ApiResourceId] ON [ids].[ApiScopes] ([ApiResourceId]);

GO

CREATE UNIQUE INDEX [IX_ApiScopes_Name] ON [ids].[ApiScopes] ([Name]);

GO

CREATE INDEX [IX_ApiSecrets_ApiResourceId] ON [ids].[ApiSecrets] ([ApiResourceId]);

GO

CREATE INDEX [IX_ClientClaims_ClientId] ON [ids].[ClientClaims] ([ClientId]);

GO

CREATE UNIQUE INDEX [IX_Clients_ClientId] ON [ids].[Clients] ([ClientId]);

GO

CREATE INDEX [IX_ClientSecrets_ClientId] ON [ids].[ClientSecrets] ([ClientId]);

GO

CREATE UNIQUE INDEX [IX_DeviceFlowCodes_DeviceCode] ON [ids].[DeviceFlowCodes] ([DeviceCode]);

GO

CREATE INDEX [IX_DeviceFlowCodes_Expiration] ON [ids].[DeviceFlowCodes] ([Expiration]);

GO

CREATE UNIQUE INDEX [IX_IdentityResources_Name] ON [ids].[IdentityResources] ([Name]);

GO

CREATE INDEX [IX_PersistedGrants_Expiration] ON [ids].[PersistedGrants] ([Expiration]);

GO

CREATE INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [ids].[PersistedGrants] ([SubjectId], [ClientId], [Type]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191228154101_InitialCreate', N'3.1.0');

GO

