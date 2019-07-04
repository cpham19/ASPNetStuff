﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Forums] (
    [Id] int NOT NULL IDENTITY,
    [ForumName] nvarchar(max) NULL,
    CONSTRAINT [PK_Forums] PRIMARY KEY ([Id]),
);

GO

CREATE TABLE [Topics] (
    [Id] int NOT NULL IDENTITY,
    [TopicName] nvarchar(max) NULL,
    [TopicContent] nvarchar(max) NULL,
    [TopicDate] datetime2 NOT NULL,
    [ForumId] int NULL,
    CONSTRAINT [PK_Topics] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Topics_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Replies] (
    [Id] int NOT NULL IDENTITY,
    [ReplyContent] nvarchar(max) NULL,
	[ReplyDate] datetime2 NOT NULL,
    [TopicId] int NULL,
    CONSTRAINT [PK_Replies] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Replies_Topics_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [Topics] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_FK_Topics_ForumId] ON [Topics] ([ForumId]);

GO 

CREATE INDEX [IX_FK_Replies_TopicId] ON [Replies] ([TopicId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190615183926_InitialSchema', N'2.2.4-servicing-10062');

GO