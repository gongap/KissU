IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'systems') IS NULL EXEC(N'CREATE SCHEMA [systems];');

GO

CREATE TABLE [systems].[Language] (
    [Id] uniqueidentifier NOT NULL,
    [Version] rowversion NULL,
    [CreatorId] uniqueidentifier NULL,
    [CreationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [Code] nvarchar(10) NOT NULL,
    [Text] nvarchar(64) NOT NULL,
    [Abbr] nvarchar(128) NULL,
    [IsEnabled] bit NULL,
    CONSTRAINT [PK_Language] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [systems].[LanguageDetail] (
    [Id] uniqueidentifier NOT NULL,
    [MainId] uniqueidentifier NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    [CreationTime] datetime2 NULL,
    [LastModifierId] uniqueidentifier NULL,
    [LastModificationTime] datetime2 NULL,
    [Key] nvarchar(256) NOT NULL,
    [Value] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_LanguageDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LanguageDetail_Language_MainId] FOREIGN KEY ([MainId]) REFERENCES [systems].[Language] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_LanguageDetail_MainId] ON [systems].[LanguageDetail] ([MainId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191226113013_InitialCreate', N'3.1.0');

GO

