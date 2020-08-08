IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [IdentityServerApiResources] (
    [Id] uniqueidentifier NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [DeleterId] uniqueidentifier NULL,
    [DeletionTime] datetime2 NULL,
    [Name] nvarchar(200) NOT NULL,
    [DisplayName] nvarchar(200) NULL,
    [Description] nvarchar(1000) NULL,
    [Enabled] bit NOT NULL,
    [Properties] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityServerApiResources] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [IdentityServerClients] (
    [Id] uniqueidentifier NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [DeleterId] uniqueidentifier NULL,
    [DeletionTime] datetime2 NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [ClientName] nvarchar(200) NULL,
    [Description] nvarchar(1000) NULL,
    [ClientUri] nvarchar(2000) NULL,
    [LogoUri] nvarchar(2000) NULL,
    [Enabled] bit NOT NULL,
    [ProtocolType] nvarchar(200) NOT NULL,
    [RequireClientSecret] bit NOT NULL,
    [RequireConsent] bit NOT NULL,
    [AllowRememberConsent] bit NOT NULL,
    [AlwaysIncludeUserClaimsInIdToken] bit NOT NULL,
    [RequirePkce] bit NOT NULL,
    [AllowPlainTextPkce] bit NOT NULL,
    [AllowAccessTokensViaBrowser] bit NOT NULL,
    [FrontChannelLogoutUri] nvarchar(2000) NULL,
    [FrontChannelLogoutSessionRequired] bit NOT NULL,
    [BackChannelLogoutUri] nvarchar(2000) NULL,
    [BackChannelLogoutSessionRequired] bit NOT NULL,
    [AllowOfflineAccess] bit NOT NULL,
    [IdentityTokenLifetime] int NOT NULL,
    [AccessTokenLifetime] int NOT NULL,
    [AuthorizationCodeLifetime] int NOT NULL,
    [ConsentLifetime] int NULL,
    [AbsoluteRefreshTokenLifetime] int NOT NULL,
    [SlidingRefreshTokenLifetime] int NOT NULL,
    [RefreshTokenUsage] int NOT NULL,
    [UpdateAccessTokenClaimsOnRefresh] bit NOT NULL,
    [RefreshTokenExpiration] int NOT NULL,
    [AccessTokenType] int NOT NULL,
    [EnableLocalLogin] bit NOT NULL,
    [IncludeJwtId] bit NOT NULL,
    [AlwaysSendClientClaims] bit NOT NULL,
    [ClientClaimsPrefix] nvarchar(200) NULL,
    [PairWiseSubjectSalt] nvarchar(200) NULL,
    [UserSsoLifetime] int NULL,
    [UserCodeType] nvarchar(100) NULL,
    [DeviceCodeLifetime] int NOT NULL,
    CONSTRAINT [PK_IdentityServerClients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [IdentityServerDeviceFlowCodes] (
    [Id] uniqueidentifier NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [DeviceCode] nvarchar(200) NOT NULL,
    [UserCode] nvarchar(200) NOT NULL,
    [SubjectId] nvarchar(200) NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [Expiration] datetime2 NOT NULL,
    [Data] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_IdentityServerDeviceFlowCodes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [IdentityServerIdentityResources] (
    [Id] uniqueidentifier NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [DeleterId] uniqueidentifier NULL,
    [DeletionTime] datetime2 NULL,
    [Name] nvarchar(200) NOT NULL,
    [DisplayName] nvarchar(200) NULL,
    [Description] nvarchar(1000) NULL,
    [Enabled] bit NOT NULL,
    [Required] bit NOT NULL,
    [Emphasize] bit NOT NULL,
    [ShowInDiscoveryDocument] bit NOT NULL,
    [Properties] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityServerIdentityResources] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [IdentityServerPersistedGrants] (
    [Key] nvarchar(200) NOT NULL,
    [Id] uniqueidentifier NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [Type] nvarchar(50) NOT NULL,
    [SubjectId] nvarchar(200) NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [Expiration] datetime2 NULL,
    [Data] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_IdentityServerPersistedGrants] PRIMARY KEY ([Key])
);

GO

CREATE TABLE [IdentityServerApiClaims] (
    [Type] nvarchar(200) NOT NULL,
    [ApiResourceId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_IdentityServerApiClaims] PRIMARY KEY ([ApiResourceId], [Type]),
    CONSTRAINT [FK_IdentityServerApiClaims_IdentityServerApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [IdentityServerApiResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerApiScopes] (
    [ApiResourceId] uniqueidentifier NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [DisplayName] nvarchar(200) NULL,
    [Description] nvarchar(1000) NULL,
    [Required] bit NOT NULL,
    [Emphasize] bit NOT NULL,
    [ShowInDiscoveryDocument] bit NOT NULL,
    CONSTRAINT [PK_IdentityServerApiScopes] PRIMARY KEY ([ApiResourceId], [Name]),
    CONSTRAINT [FK_IdentityServerApiScopes_IdentityServerApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [IdentityServerApiResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerApiSecrets] (
    [Type] nvarchar(250) NOT NULL,
    [Value] nvarchar(4000) NOT NULL,
    [ApiResourceId] uniqueidentifier NOT NULL,
    [Description] nvarchar(2000) NULL,
    [Expiration] datetime2 NULL,
    CONSTRAINT [PK_IdentityServerApiSecrets] PRIMARY KEY ([ApiResourceId], [Type], [Value]),
    CONSTRAINT [FK_IdentityServerApiSecrets_IdentityServerApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [IdentityServerApiResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientClaims] (
    [ClientId] uniqueidentifier NOT NULL,
    [Type] nvarchar(250) NOT NULL,
    [Value] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientClaims] PRIMARY KEY ([ClientId], [Type], [Value]),
    CONSTRAINT [FK_IdentityServerClientClaims_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientCorsOrigins] (
    [ClientId] uniqueidentifier NOT NULL,
    [Origin] nvarchar(150) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientCorsOrigins] PRIMARY KEY ([ClientId], [Origin]),
    CONSTRAINT [FK_IdentityServerClientCorsOrigins_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientGrantTypes] (
    [ClientId] uniqueidentifier NOT NULL,
    [GrantType] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientGrantTypes] PRIMARY KEY ([ClientId], [GrantType]),
    CONSTRAINT [FK_IdentityServerClientGrantTypes_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientIdPRestrictions] (
    [ClientId] uniqueidentifier NOT NULL,
    [Provider] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientIdPRestrictions] PRIMARY KEY ([ClientId], [Provider]),
    CONSTRAINT [FK_IdentityServerClientIdPRestrictions_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientPostLogoutRedirectUris] (
    [ClientId] uniqueidentifier NOT NULL,
    [PostLogoutRedirectUri] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientPostLogoutRedirectUris] PRIMARY KEY ([ClientId], [PostLogoutRedirectUri]),
    CONSTRAINT [FK_IdentityServerClientPostLogoutRedirectUris_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientProperties] (
    [ClientId] uniqueidentifier NOT NULL,
    [Key] nvarchar(250) NOT NULL,
    [Value] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientProperties] PRIMARY KEY ([ClientId], [Key]),
    CONSTRAINT [FK_IdentityServerClientProperties_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientRedirectUris] (
    [ClientId] uniqueidentifier NOT NULL,
    [RedirectUri] nvarchar(2000) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientRedirectUris] PRIMARY KEY ([ClientId], [RedirectUri]),
    CONSTRAINT [FK_IdentityServerClientRedirectUris_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientScopes] (
    [ClientId] uniqueidentifier NOT NULL,
    [Scope] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_IdentityServerClientScopes] PRIMARY KEY ([ClientId], [Scope]),
    CONSTRAINT [FK_IdentityServerClientScopes_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerClientSecrets] (
    [Type] nvarchar(250) NOT NULL,
    [Value] nvarchar(4000) NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [Description] nvarchar(2000) NULL,
    [Expiration] datetime2 NULL,
    CONSTRAINT [PK_IdentityServerClientSecrets] PRIMARY KEY ([ClientId], [Type], [Value]),
    CONSTRAINT [FK_IdentityServerClientSecrets_IdentityServerClients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [IdentityServerClients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerIdentityClaims] (
    [Type] nvarchar(200) NOT NULL,
    [IdentityResourceId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_IdentityServerIdentityClaims] PRIMARY KEY ([IdentityResourceId], [Type]),
    CONSTRAINT [FK_IdentityServerIdentityClaims_IdentityServerIdentityResources_IdentityResourceId] FOREIGN KEY ([IdentityResourceId]) REFERENCES [IdentityServerIdentityResources] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [IdentityServerApiScopeClaims] (
    [Type] nvarchar(200) NOT NULL,
    [ApiResourceId] uniqueidentifier NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_IdentityServerApiScopeClaims] PRIMARY KEY ([ApiResourceId], [Name], [Type]),
    CONSTRAINT [FK_IdentityServerApiScopeClaims_IdentityServerApiScopes_ApiResourceId_Name] FOREIGN KEY ([ApiResourceId], [Name]) REFERENCES [IdentityServerApiScopes] ([ApiResourceId], [Name]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_IdentityServerClients_ClientId] ON [IdentityServerClients] ([ClientId]);

GO

CREATE UNIQUE INDEX [IX_IdentityServerDeviceFlowCodes_DeviceCode] ON [IdentityServerDeviceFlowCodes] ([DeviceCode]);

GO

CREATE INDEX [IX_IdentityServerDeviceFlowCodes_Expiration] ON [IdentityServerDeviceFlowCodes] ([Expiration]);

GO

CREATE UNIQUE INDEX [IX_IdentityServerDeviceFlowCodes_UserCode] ON [IdentityServerDeviceFlowCodes] ([UserCode]);

GO

CREATE INDEX [IX_IdentityServerPersistedGrants_Expiration] ON [IdentityServerPersistedGrants] ([Expiration]);

GO

CREATE INDEX [IX_IdentityServerPersistedGrants_SubjectId_ClientId_Type] ON [IdentityServerPersistedGrants] ([SubjectId], [ClientId], [Type]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200528122847_InitialCreate', N'3.1.2');

GO

