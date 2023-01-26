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

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110001121_Inical', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110001513_RemoverMoldeados', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[STOCK_CUANTITATIVOS].[CantidadMoldeado]', N'CANTIDAD_MOLDEADO', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110002457_AgregarCampoCantidadMoldeados_SotckCuantitativos', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[STOCK_CUANTITATIVOS].[CantidadMoldeado]', N'CANTIDAD_MOLDEADO', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110004508_RenombrarCampoCantidadMoldeados_SotckCuantitativos', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [CUANTITATIVOS_DETALLE] ADD [PERFIL] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110011455_Agregar_CampoPERFIL_Tabla_CuantitativosDetalle', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [CUANTITATIVOS_DETALLE] ADD [ESPESOR] decimal(18,2) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110020553_Agregar_CampoESPESOR_Tabla_CuantitativosDetalle', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CUANTITATIVOS_DETALLE]') AND [c].[name] = N'PERFIL');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [CUANTITATIVOS_DETALLE] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [CUANTITATIVOS_DETALLE] ALTER COLUMN [PERFIL] int NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230111040425_CambiarTipo_CampoPerfil_TablaCuantitativosDetalle', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[CUANTITATIVOS_DETALLE].[Perfil]', N'PERFIL', N'COLUMN';
GO

EXEC sp_rename N'[CUANTITATIVOS_DETALLE].[Espesor]', N'ESPESOR', N'COLUMN';
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CUANTITATIVOS_DETALLE]') AND [c].[name] = N'PERFIL');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [CUANTITATIVOS_DETALLE] DROP CONSTRAINT [' + @var1 + '];');
UPDATE [CUANTITATIVOS_DETALLE] SET [PERFIL] = 0 WHERE [PERFIL] IS NULL;
ALTER TABLE [CUANTITATIVOS_DETALLE] ALTER COLUMN [PERFIL] int NOT NULL;
ALTER TABLE [CUANTITATIVOS_DETALLE] ADD DEFAULT 0 FOR [PERFIL];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CUANTITATIVOS_DETALLE]') AND [c].[name] = N'ESPESOR');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [CUANTITATIVOS_DETALLE] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [CUANTITATIVOS_DETALLE] ADD DEFAULT (((0))) FOR [ESPESOR];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230111054714_AgregarPKPerfil_CampoDiametro_TablaCuantitativosDetalle', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230111054918_AgregarPKPerfil_CampoDiametro_TablaCuantitativosDetalle_2', N'7.0.1');
GO

COMMIT;
GO

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

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[STOCK_CUANTITATIVOS]') AND [c].[name] = N'Cantidad_Moldeado');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [STOCK_CUANTITATIVOS] DROP CONSTRAINT [' + @var3 + '];');
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

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[STOCK_CUANTITATIVOS]') AND [c].[name] = N'CANTIDAD_MOLDEADO');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [STOCK_CUANTITATIVOS] DROP CONSTRAINT [' + @var4 + '];');
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

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[STOCK_CUANTITATIVOS].[CANTIDAD_MOLDEADO]', N'CANTIDAD_MOLDEADO', N'COLUMN';
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[STOCK_CUANTITATIVOS]') AND [c].[name] = N'CantidadMoldeado');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [STOCK_CUANTITATIVOS] DROP CONSTRAINT [' + @var5 + '];');
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230116051351_Columna_CantidadMoldeado', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[STOCK_CUANTITATIVOS].[CANTIDAD_MOLDEADO    ]', N'CANTIDAD_MOLDEADO', N'COLUMN';
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[STOCK_CUANTITATIVOS]') AND [c].[name] = N'CANTIDAD_MOLDEADO');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [STOCK_CUANTITATIVOS] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [STOCK_CUANTITATIVOS] ADD DEFAULT (((0))) FOR [CANTIDAD_MOLDEADO];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230116052109_Columna_CantidadMoldeado_Prueba2', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ComponentesTipos] (
    [IdTipo] int NOT NULL IDENTITY,
    [DescripcionTipo] nvarchar(max) NULL,
    CONSTRAINT [PK_ComponentesTipos] PRIMARY KEY ([IdTipo])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230119062411_Prueba_Tabla_TiposComponentes', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[ComponentesTipos].[IdTipo]', N'ID_TIPO', N'COLUMN';
GO

EXEC sp_rename N'[ComponentesTipos].[DescripcionTipo]', N'DESCRIPCION_TIPO', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230119063720_CambiarNombreTabla_TiposComponentes', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[ComponentesTipos]', N'COMPONENTES_TIPOS';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230119064557_RenameTabl', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[COMPONENTES_TIPOS].[ID_TIPO]', N'ID_DESCRIPCION_TIPO', N'COLUMN';
GO

ALTER TABLE [COMPONENTES_DESCRIPCION] ADD [ID_DESCRIPCION_TIPO] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230120185729_AgregarCampo_IdDescripcionTipo_Tablas_ComponentesTipos_ComponentesDescripcion', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [COMPONENTES_DESCRIPCION] ADD CONSTRAINT [FK_COMPONENTES_DESCRIPCION_COMPONENTES_DESCRIPCION_ComponentesDescripcionIdDescripcion] FOREIGN KEY ([ID_DESCRIPCION_TIPO]) REFERENCES [COMPONENTES_TIPOS] ([ID_DESCRIPCION_TIPO]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230120202206_AgregarRelacion_ComponentesTipos_ComponentesDescripcion', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CUANTITATIVOS_DETALLE]') AND [c].[name] = N'PERFIL');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [CUANTITATIVOS_DETALLE] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [CUANTITATIVOS_DETALLE] ALTER COLUMN [PERFIL] int NULL;
ALTER TABLE [CUANTITATIVOS_DETALLE] ADD DEFAULT (null) FOR [PERFIL];
GO

ALTER TABLE [COMPONENTES_CUANTITATIVOS] ADD CONSTRAINT [FK_COMPONENTES_CUANTITATIVOS_PRODUCTOS_ID_PRODUCTO] FOREIGN KEY ([ID_PRODUCTO]) REFERENCES [PRODUCTOS] ([ID_PRODUCTO]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230125153611_FK_COMPONENTESCUANTITATIVOS_PRODUCTOS', N'7.0.1');
GO

COMMIT;
GO

