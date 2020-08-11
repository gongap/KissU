IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [BlgBlogs] (
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
    [Name] nvarchar(256) NOT NULL,
    [ShortName] nvarchar(32) NOT NULL,
    [Description] nvarchar(1024) NULL,
    CONSTRAINT [PK_BlgBlogs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BlgTags] (
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
    [BlogId] uniqueidentifier NOT NULL,
    [Name] nvarchar(64) NOT NULL,
    [Description] nvarchar(512) NULL,
    [UsageCount] int NOT NULL,
    CONSTRAINT [PK_BlgTags] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BlgUsers] (
    [Id] uniqueidentifier NOT NULL,
    [ExtraProperties] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [TenantId] uniqueidentifier NULL,
    [UserName] nvarchar(256) NOT NULL,
    [Email] nvarchar(256) NOT NULL,
    [Name] nvarchar(64) NULL,
    [Surname] nvarchar(64) NULL,
    [EmailConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit),
    [PhoneNumber] nvarchar(16) NULL,
    [PhoneNumberConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_BlgUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BlgPosts] (
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
    [BlogId] uniqueidentifier NOT NULL,
    [Url] nvarchar(64) NOT NULL,
    [CoverImage] nvarchar(max) NOT NULL,
    [Title] nvarchar(512) NOT NULL,
    [Content] nvarchar(max) NULL,
    [Description] nvarchar(1000) NULL,
    [ReadCount] int NOT NULL,
    CONSTRAINT [PK_BlgPosts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BlgPosts_BlgBlogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [BlgBlogs] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BlgComments] (
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
    [PostId] uniqueidentifier NOT NULL,
    [RepliedCommentId] uniqueidentifier NULL,
    [Text] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_BlgComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BlgComments_BlgPosts_PostId] FOREIGN KEY ([PostId]) REFERENCES [BlgPosts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BlgComments_BlgComments_RepliedCommentId] FOREIGN KEY ([RepliedCommentId]) REFERENCES [BlgComments] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [BlgPostTags] (
    [PostId] uniqueidentifier NOT NULL,
    [TagId] uniqueidentifier NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [CreatorId] uniqueidentifier NULL,
    CONSTRAINT [PK_BlgPostTags] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_BlgPostTags_BlgPosts_PostId] FOREIGN KEY ([PostId]) REFERENCES [BlgPosts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BlgPostTags_BlgTags_TagId] FOREIGN KEY ([TagId]) REFERENCES [BlgTags] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_BlgComments_PostId] ON [BlgComments] ([PostId]);

GO

CREATE INDEX [IX_BlgComments_RepliedCommentId] ON [BlgComments] ([RepliedCommentId]);

GO

CREATE INDEX [IX_BlgPosts_BlogId] ON [BlgPosts] ([BlogId]);

GO

CREATE INDEX [IX_BlgPostTags_TagId] ON [BlgPostTags] ([TagId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200529055123_InitialCreate', N'3.1.2');

GO

