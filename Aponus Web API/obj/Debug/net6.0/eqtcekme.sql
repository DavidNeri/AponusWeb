BEGIN TRANSACTION;
GO

ALTER TABLE [CUANTITATIVOS_DETALLE] ADD CONSTRAINT [AK_CUANTITATIVOS_DETALLE_ID_COMPONENTE_PERFIL] UNIQUE ([ID_COMPONENTE], [PERFIL]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230111055216_AgregarPKPerfil_CampoDiametro_TablaCuantitativosDetalle_3', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [CUANTITATIVOS_DETALLE] DROP CONSTRAINT [AK_CUANTITATIVOS_DETALLE_ID_COMPONENTE_PERFIL];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230112001108_Columna_CantidadMoldeado_Tabla_StockCuantitativos', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[STOCK_CUANTITATIVOS]') AND [c].[name] = N'Cantidad_Moldeado');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [STOCK_CUANTITATIVOS] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [STOCK_CUANTITATIVOS] DROP COLUMN [Cantidad_Moldeado];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230112012315_CantidadMoldeado_StockCuantitativos', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [STOCK_CUANTITATIVOS] ADD [CANTIDAD_MOLDEADO] int NULL DEFAULT N'0';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230112013105_CantidadMoldeado_StockCuantitativos_Agregar', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[STOCK_CUANTITATIVOS]') AND [c].[name] = N'CANTIDAD_MOLDEADO');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [STOCK_CUANTITATIVOS] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [STOCK_CUANTITATIVOS] ALTER COLUMN [CANTIDAD_MOLDEADO] int NULL;
ALTER TABLE [STOCK_CUANTITATIVOS] ADD DEFAULT (((0))) FOR [CANTIDAD_MOLDEADO];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230112013448_CantidadMoldeado_StockCuantitativos_Alter', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230112235254_MigracionPrueba', N'7.0.1');
GO

COMMIT;
GO

