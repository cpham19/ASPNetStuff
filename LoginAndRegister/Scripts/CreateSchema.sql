IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Persons] (
    [PersonId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Username] nvarchar(450) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [IsAdmin] bit NOT NULL DEFAULT 0,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([PersonId]),
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190726011148_InitialSchema', N'2.2.1-servicing-10028');

GO

