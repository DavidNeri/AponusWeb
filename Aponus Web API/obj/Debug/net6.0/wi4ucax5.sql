﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

CREATE TABLE [COMPONENTES_DESCRIPCION] (
    [ID_DESCRIPCION] int NOT NULL DEFAULT (((-1))),
    [DESCRIPCION] varchar(50) NULL,
    CONSTRAINT [PK_COMPONENTES_DESCRIPCION] PRIMARY KEY ([ID_DESCRIPCION])
);
GO

CREATE TABLE [PRODUCTOS_DESCRIPCION] (
    [ID_DESCRIPCION] int NOT NULL,
    [DESCRIPCION] varchar(50) NULL,
    CONSTRAINT [PK_PRODUCTOS_DESCRIPCION] PRIMARY KEY ([ID_DESCRIPCION])
);
GO

CREATE TABLE [PRODUCTOS_TIPOS] (
    [ID_TIPO] varchar(50) NOT NULL,
    [DESCRIPCION] varchar(100) NULL,
    CONSTRAINT [PK_Table_1] PRIMARY KEY ([ID_TIPO])
);
GO

CREATE TABLE [STOCK_MENSURABLES] (
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [CANTIDAD_RECIBIDO] int NULL DEFAULT (((0))),
    [CANTIDAD_PROCESO] int NULL DEFAULT (((0))),
    CONSTRAINT [PK_STOCK_MENSURABLES] PRIMARY KEY ([ID_COMPONENTE])
);
GO

CREATE TABLE [CUANTITATIVOS_DETALLE] (
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [ID_DESCRIPCION] int NULL,
    [DIAMETRO] decimal(18,2) NULL DEFAULT (((0))),
    [ALTURA] decimal(18,2) NULL DEFAULT (((0))),
    [TOLERANCIA_MINIMA] int NULL DEFAULT (((0))),
    [TOLERANCIA_MAXIMA] int NULL DEFAULT (((0))),
    CONSTRAINT [PK_CUANTITATIVOS_DETALLE] PRIMARY KEY ([ID_COMPONENTE]),
    CONSTRAINT [FK_CUANTITATIVOS_DETALLE_COMPONENTES_DESCRIPCION] FOREIGN KEY ([ID_DESCRIPCION]) REFERENCES [COMPONENTES_DESCRIPCION] ([ID_DESCRIPCION])
);
GO

CREATE TABLE [PESABLES_DETALLE] (
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [ID_DESCRIPCION] int NULL,
    [DIAMETRO] decimal(18,2) NULL DEFAULT (((0))),
    [ALTURA] decimal(18,2) NULL DEFAULT (((0))),
    CONSTRAINT [PK_PESABLES_DETALLE] PRIMARY KEY ([ID_COMPONENTE]),
    CONSTRAINT [FK_PESABLES_DETALLE_COMPONENTES_DESCRIPCION] FOREIGN KEY ([ID_DESCRIPCION]) REFERENCES [COMPONENTES_DESCRIPCION] ([ID_DESCRIPCION])
);
GO

CREATE TABLE [PRODUCTOS] (
    [ID_PRODUCTO] varchar(50) NOT NULL,
    [ID_DESCRIPCION] int NOT NULL,
    [ID_TIPO] varchar(50) NOT NULL,
    [DIAMETRO_NOMINAL] int NULL,
    [TOLERANCIA_MINIMA] int NULL,
    [TOLERANCIA_MAXIMA] int NULL,
    [CANTIDAD] int NULL DEFAULT (((0))),
    [PRECIO] money NULL DEFAULT (((0))),
    CONSTRAINT [PK_PRODUCTOS] PRIMARY KEY ([ID_PRODUCTO]),
    CONSTRAINT [FK_PRODUCTOS_PRODUCTOS_DESCRIPCION] FOREIGN KEY ([ID_DESCRIPCION]) REFERENCES [PRODUCTOS_DESCRIPCION] ([ID_DESCRIPCION]),
    CONSTRAINT [FK_PRODUCTOS_PRODUCTOS_TIPOS] FOREIGN KEY ([ID_TIPO]) REFERENCES [PRODUCTOS_TIPOS] ([ID_TIPO])
);
GO

CREATE TABLE [MENSURABLES_DETALLE] (
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [ID_DESCRIPCION] int NULL,
    [LARGO] decimal(18,2) NULL DEFAULT (((0))),
    [ANCHO] decimal(18,2) NULL DEFAULT (((0))),
    [ALTURA] decimal(18,2) NULL DEFAULT (((0))),
    [ESPESOR] decimal(18,2) NULL DEFAULT (((0))),
    [PERFIL] int NULL DEFAULT (((0))),
    CONSTRAINT [PK_MENSURABLES_DETALLE] PRIMARY KEY ([ID_COMPONENTE]),
    CONSTRAINT [FK_MENSURABLES_DETALLE_COMPONENTES_DESCRIPCION] FOREIGN KEY ([ID_DESCRIPCION]) REFERENCES [COMPONENTES_DESCRIPCION] ([ID_DESCRIPCION]),
    CONSTRAINT [FK_MENSURABLES_DETALLE_STOCK_MENSURABLES] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [STOCK_MENSURABLES] ([ID_COMPONENTE])
);
GO

CREATE TABLE [STOCK_CUANTITATIVOS] (
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [CANTIDAD_RECIBIDO] int NULL DEFAULT (((0))),
    [CANTIDAD_GRANALLADO] int NULL DEFAULT (((0))),
    [CANTIDAD_PINTURA] int NULL DEFAULT (((0))),
    [CANTIDAD_PROCESO] int NULL DEFAULT (((0))),
    CONSTRAINT [PK_STOCK_CUANTITATIVOS] PRIMARY KEY ([ID_COMPONENTE]),
    CONSTRAINT [FK_STOCK_CUANTITATIVOS_CUANTITATIVOS_DETALLE] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [CUANTITATIVOS_DETALLE] ([ID_COMPONENTE])
);
GO

CREATE TABLE [STOCK_PESABLES] (
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [CANTIDAD_RECIBIDO] decimal(18,2) NULL DEFAULT (((0))),
    [CANTIDAD_PINTURA] decimal(18,2) NULL DEFAULT (((0))),
    [CANTIDAD_PROCESO] decimal(18,2) NULL DEFAULT (((0))),
    CONSTRAINT [PK_STOCK_PESABLES] PRIMARY KEY ([ID_COMPONENTE]),
    CONSTRAINT [FK_STOCK_PESABLES_PESABLES_DETALLE] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [PESABLES_DETALLE] ([ID_COMPONENTE])
);
GO

CREATE TABLE [COMPONENTES_MENSURABLES] (
    [ID_PRODUCTO] varchar(50) NOT NULL,
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [LARGO] decimal(18,2) NULL DEFAULT (((0))),
    [ALTURA] decimal(18,2) NULL DEFAULT (((0))),
    CONSTRAINT [PK_COMPONENTES_MENSURABLES] PRIMARY KEY ([ID_PRODUCTO], [ID_COMPONENTE]),
    CONSTRAINT [FK_COMPONENTES_MENSURABLES_MENSURABLES_DETALLE] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [MENSURABLES_DETALLE] ([ID_COMPONENTE]),
    CONSTRAINT [FK_COMPONENTES_MENSURABLES_STOCK_MENSURABLES] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [STOCK_MENSURABLES] ([ID_COMPONENTE])
);
GO

CREATE TABLE [COMPONENTES_CUANTITATIVOS] (
    [ID_PRODUCTO] varchar(50) NOT NULL,
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [CANTIDAD] decimal(18,1) NOT NULL,
    CONSTRAINT [PK_COMPONENTES_CUANTITATIVOS] PRIMARY KEY ([ID_PRODUCTO], [ID_COMPONENTE]),
    CONSTRAINT [FK_COMPONENTES_CUANTITATIVOS_CUANTITATIVOS_DETALLE] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [CUANTITATIVOS_DETALLE] ([ID_COMPONENTE]),
    CONSTRAINT [FK_COMPONENTES_CUANTITATIVOS_STOCK_CUANTITATIVOS] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [STOCK_CUANTITATIVOS] ([ID_COMPONENTE])
);
GO

CREATE TABLE [COMPONENTES_PESABLES] (
    [ID_PRODUCTO] varchar(50) NOT NULL,
    [ID_COMPONENTE] varchar(50) NOT NULL,
    [PESO] decimal(18,2) NULL DEFAULT (((0))),
    CONSTRAINT [PK_COMPONENTES_PESABLES] PRIMARY KEY ([ID_PRODUCTO], [ID_COMPONENTE]),
    CONSTRAINT [FK_COMPONENTES_PESABLES_PESABLES_DETALLE1] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [PESABLES_DETALLE] ([ID_COMPONENTE]),
    CONSTRAINT [FK_COMPONENTES_PESABLES_STOCK_PESABLES] FOREIGN KEY ([ID_COMPONENTE]) REFERENCES [STOCK_PESABLES] ([ID_COMPONENTE])
);
GO

CREATE INDEX [IX_COMPONENTES_CUANTITATIVOS_ID_COMPONENTE] ON [COMPONENTES_CUANTITATIVOS] ([ID_COMPONENTE]);
GO

CREATE INDEX [IX_COMPONENTES_MENSURABLES_ID_COMPONENTE] ON [COMPONENTES_MENSURABLES] ([ID_COMPONENTE]);
GO

CREATE INDEX [IX_COMPONENTES_PESABLES_ID_COMPONENTE] ON [COMPONENTES_PESABLES] ([ID_COMPONENTE]);
GO

CREATE INDEX [IX_CUANTITATIVOS_DETALLE_ID_DESCRIPCION] ON [CUANTITATIVOS_DETALLE] ([ID_DESCRIPCION]);
GO

CREATE INDEX [IX_MENSURABLES_DETALLE_ID_DESCRIPCION] ON [MENSURABLES_DETALLE] ([ID_DESCRIPCION]);
GO

CREATE INDEX [IX_PESABLES_DETALLE_ID_DESCRIPCION] ON [PESABLES_DETALLE] ([ID_DESCRIPCION]);
GO

CREATE INDEX [IX_PRODUCTOS_ID_DESCRIPCION] ON [PRODUCTOS] ([ID_DESCRIPCION]);
GO

CREATE INDEX [IX_PRODUCTOS_ID_TIPO] ON [PRODUCTOS] ([ID_TIPO]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230109235917_Inicial', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [STOCK_CUANTITATIVOS] ADD [CantidadMoldeado] int NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110000111_Moldeado', N'7.0.1');
GO

COMMIT;
GO
