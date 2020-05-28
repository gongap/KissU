IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AbpPermissionGrants] (
    [Id] uniqueidentifier NOT NULL,
    [TenantId] uniqueidentifier NULL,
    [Name] nvarchar(128) NOT NULL,
    [ProviderName] nvarchar(64) NOT NULL,
    [ProviderKey] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_AbpPermissionGrants] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_AbpPermissionGrants_Name_ProviderName_ProviderKey] ON [AbpPermissionGrants] ([Name], [ProviderName], [ProviderKey]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200528032702_InitialCreate', N'3.1.2');

GO

