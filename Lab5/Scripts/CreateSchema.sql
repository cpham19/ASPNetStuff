IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Contacts] (
    [ContactId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([ContactId]),
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190705160311_InitialSchema', N'2.2.1-servicing-10028');

GO

