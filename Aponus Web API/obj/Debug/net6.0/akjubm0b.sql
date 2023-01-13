BEGIN TRANSACTION;
GO

ALTER TABLE [STOCK_CUANTITATIVOS] ADD [CantidadMoldeado] int NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110000111_Moldeado', N'7.0.1');
GO

COMMIT;
GO

