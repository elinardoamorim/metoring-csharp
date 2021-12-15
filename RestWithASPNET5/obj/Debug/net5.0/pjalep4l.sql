IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

CREATE TABLE [person] (
    [id] bigint NOT NULL IDENTITY,
    [first_name] nvarchar(max) NULL,
    [last_name] nvarchar(max) NULL,
    [address] nvarchar(max) NULL,
    [gender] nvarchar(max) NULL,
    CONSTRAINT [PK_person] PRIMARY KEY ([id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211210192701_initial', N'5.0.12');
GO

COMMIT;
GO

