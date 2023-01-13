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

