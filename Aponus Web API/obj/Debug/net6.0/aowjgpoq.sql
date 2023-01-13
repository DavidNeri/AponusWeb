BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[STOCK_CUANTITATIVOS]') AND [c].[name] = N'CantidadMoldeado');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [STOCK_CUANTITATIVOS] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [STOCK_CUANTITATIVOS] DROP COLUMN [CantidadMoldeado];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110001513_RemoverMoldeados', N'7.0.1');
GO

COMMIT;
GO

