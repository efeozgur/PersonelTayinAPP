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
CREATE TABLE [Personeller] (
    [Id] int NOT NULL IDENTITY,
    [SicilNo] nvarchar(max) NOT NULL,
    [AdSoyad] nvarchar(max) NOT NULL,
    [Sifre] nvarchar(max) NOT NULL,
    [Unvan] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Personeller] PRIMARY KEY ([Id])
);

CREATE TABLE [TayinTalepleri] (
    [Id] int NOT NULL IDENTITY,
    [PersonelId] int NOT NULL,
    [TalepTuru] nvarchar(max) NOT NULL,
    [TercihAdliye] nvarchar(max) NOT NULL,
    [Aciklama] nvarchar(max) NOT NULL,
    [BasvuruTarihi] datetime2 NOT NULL,
    CONSTRAINT [PK_TayinTalepleri] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TayinTalepleri_Personeller_PersonelId] FOREIGN KEY ([PersonelId]) REFERENCES [Personeller] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_TayinTalepleri_PersonelId] ON [TayinTalepleri] ([PersonelId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250526173545_IlkKurulum', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250526182352_TalepDurumuVarsayilan', N'9.0.5');

ALTER TABLE [Personeller] ADD [Yetki] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250526183235_YetkiEkliyoruz', N'9.0.5');

ALTER TABLE [Personeller] ADD [Cinsiyet] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250526192637_CinsiyetEklendi', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250527061237_YeniBilgisayar', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250527061617_Durum', N'9.0.5');

ALTER TABLE [Personeller] ADD [GorevYeri] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250527163048_GorevYeri', N'9.0.5');

COMMIT;
GO

