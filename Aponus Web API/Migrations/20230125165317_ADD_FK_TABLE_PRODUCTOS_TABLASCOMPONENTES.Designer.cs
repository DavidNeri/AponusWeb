﻿// <auto-generated />
using System;
using Aponus_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AponusWebAPI.Migrations
{
    [DbContext(typeof(AponusContext))]
    [Migration("20230125165317_ADD_FK_TABLE_PRODUCTOS_TABLASCOMPONENTES")]
    partial class ADDFKTABLEPRODUCTOSTABLASCOMPONENTES
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AI")
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesCuantitativo", b =>
                {
                    b.Property<string>("IdProducto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_PRODUCTO");

                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 1)")
                        .HasColumnName("CANTIDAD");

                    b.HasKey("IdProducto", "IdComponente");

                    b.HasIndex("IdComponente");

                    b.ToTable("COMPONENTES_CUANTITATIVOS", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesDescripcion", b =>
                {
                    b.Property<int>("IdDescripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_DESCRIPCION")
                        .HasDefaultValueSql("((-1))");

                    b.Property<int?>("ComponentesDescripcionIdDescripcion")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DESCRIPCION");

                    b.Property<int?>("IdDescripcionTipo")
                        .HasColumnType("int");

                    b.HasKey("IdDescripcion");

                    b.HasIndex("ComponentesDescripcionIdDescripcion");

                    b.ToTable("COMPONENTES_DESCRIPCION", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesMensurable", b =>
                {
                    b.Property<string>("IdProducto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_PRODUCTO");

                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<decimal?>("Altura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ALTURA")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("Largo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("LARGO")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdProducto", "IdComponente");

                    b.HasIndex("IdComponente");

                    b.ToTable("COMPONENTES_MENSURABLES", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesPesable", b =>
                {
                    b.Property<string>("IdProducto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_PRODUCTO");

                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<decimal?>("Peso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PESO")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdProducto", "IdComponente");

                    b.HasIndex("IdComponente");

                    b.ToTable("COMPONENTES_PESABLES", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.CuantitativosDetalle", b =>
                {
                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<decimal?>("Altura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ALTURA")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("Diametro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("DIAMETRO")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("Espesor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ESPESOR")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("IdDescripcion")
                        .HasColumnType("int")
                        .HasColumnName("ID_DESCRIPCION");

                    b.Property<int?>("Perfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PERFIL")
                        .HasDefaultValueSql("null");

                    b.Property<int?>("ToleranciaMaxima")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TOLERANCIA_MAXIMA")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("ToleranciaMinima")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TOLERANCIA_MINIMA")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdComponente");

                    b.HasIndex("IdDescripcion");

                    b.ToTable("CUANTITATIVOS_DETALLE", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.MensurablesDetalle", b =>
                {
                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<decimal?>("Altura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ALTURA")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("Ancho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ANCHO")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("Espesor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ESPESOR")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("IdDescripcion")
                        .HasColumnType("int")
                        .HasColumnName("ID_DESCRIPCION");

                    b.Property<decimal?>("Largo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("LARGO")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Perfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PERFIL")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdComponente");

                    b.HasIndex("IdDescripcion");

                    b.ToTable("MENSURABLES_DETALLE", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.PesablesDetalle", b =>
                {
                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<decimal?>("Altura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("ALTURA")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("Diametro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("DIAMETRO")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("IdDescripcion")
                        .HasColumnType("int")
                        .HasColumnName("ID_DESCRIPCION");

                    b.HasKey("IdComponente");

                    b.HasIndex("IdDescripcion");

                    b.ToTable("PESABLES_DETALLE", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.Producto", b =>
                {
                    b.Property<string>("IdProducto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_PRODUCTO");

                    b.Property<int?>("Cantidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("DiametroNominal")
                        .HasColumnType("int")
                        .HasColumnName("DIAMETRO_NOMINAL");

                    b.Property<int>("IdDescripcion")
                        .HasColumnType("int")
                        .HasColumnName("ID_DESCRIPCION");

                    b.Property<string>("IdTipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_TIPO");

                    b.Property<decimal?>("Precio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasColumnName("PRECIO")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("ToleranciaMaxima")
                        .HasColumnType("int")
                        .HasColumnName("TOLERANCIA_MAXIMA");

                    b.Property<int?>("ToleranciaMinima")
                        .HasColumnType("int")
                        .HasColumnName("TOLERANCIA_MINIMA");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdDescripcion");

                    b.HasIndex("IdTipo");

                    b.ToTable("PRODUCTOS", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ProductosDescripcion", b =>
                {
                    b.Property<int>("IdDescripcion")
                        .HasColumnType("int")
                        .HasColumnName("ID_DESCRIPCION");

                    b.Property<string>("DescripcionProducto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DESCRIPCION");

                    b.HasKey("IdDescripcion");

                    b.ToTable("PRODUCTOS_DESCRIPCION", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ProductosTipo", b =>
                {
                    b.Property<string>("IdTipo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_TIPO");

                    b.Property<string>("DescripcionTipo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DESCRIPCION");

                    b.HasKey("IdTipo")
                        .HasName("PK_Table_1");

                    b.ToTable("PRODUCTOS_TIPOS", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockCuantitativo", b =>
                {
                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<int?>("CantidadGranallado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD_GRANALLADO")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("CantidadMoldeado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD_MOLDEADO")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("CantidadPintura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD_PINTURA")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("CantidadProceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD_PROCESO")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("CantidadRecibido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD_RECIBIDO")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdComponente");

                    b.ToTable("STOCK_CUANTITATIVOS", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockMensurable", b =>
                {
                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<int?>("CantidadProceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD_PROCESO")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("CantidadRecibido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD_RECIBIDO")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdComponente");

                    b.ToTable("STOCK_MENSURABLES", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockPesable", b =>
                {
                    b.Property<string>("IdComponente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID_COMPONENTE");

                    b.Property<decimal?>("CantidadPintura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("CANTIDAD_PINTURA")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("CantidadProceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("CANTIDAD_PROCESO")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("CantidadRecibido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("CANTIDAD_RECIBIDO")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdComponente");

                    b.ToTable("STOCK_PESABLES", (string)null);
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesCuantitativo", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.CuantitativosDetalle", "IdComponenteNavigation")
                        .WithMany("ComponentesCuantitativos")
                        .HasForeignKey("IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_COMPONENTES_CUANTITATIVOS_CUANTITATIVOS_DETALLE");

                    b.HasOne("Aponus_Web_API.Models.StockCuantitativo", "IdComponente1")
                        .WithMany("ComponentesCuantitativos")
                        .HasForeignKey("IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_COMPONENTES_CUANTITATIVOS_STOCK_CUANTITATIVOS");

                    b.HasOne("Aponus_Web_API.Models.Producto", null)
                        .WithMany("ComponentesCuantitativos")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdComponente1");

                    b.Navigation("IdComponenteNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesDescripcion", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.ComponentesDescripcion", null)
                        .WithMany("ComponentesDescripcions")
                        .HasForeignKey("ComponentesDescripcionIdDescripcion");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesMensurable", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.MensurablesDetalle", "IdComponenteNavigation")
                        .WithMany("ComponentesMensurables")
                        .HasForeignKey("IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_COMPONENTES_MENSURABLES_MENSURABLES_DETALLE");

                    b.HasOne("Aponus_Web_API.Models.StockMensurable", "IdComponente1")
                        .WithMany("ComponentesMensurables")
                        .HasForeignKey("IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_COMPONENTES_MENSURABLES_STOCK_MENSURABLES");

                    b.Navigation("IdComponente1");

                    b.Navigation("IdComponenteNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesPesable", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.PesablesDetalle", "IdComponenteNavigation")
                        .WithMany("ComponentesPesables")
                        .HasForeignKey("IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_COMPONENTES_PESABLES_PESABLES_DETALLE1");

                    b.HasOne("Aponus_Web_API.Models.StockPesable", "IdComponente1")
                        .WithMany("ComponentesPesables")
                        .HasForeignKey("IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_COMPONENTES_PESABLES_STOCK_PESABLES");

                    b.Navigation("IdComponente1");

                    b.Navigation("IdComponenteNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.CuantitativosDetalle", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.ComponentesDescripcion", "IdDescripcionNavigation")
                        .WithMany("CuantitativosDetalles")
                        .HasForeignKey("IdDescripcion")
                        .HasConstraintName("FK_CUANTITATIVOS_DETALLE_COMPONENTES_DESCRIPCION");

                    b.Navigation("IdDescripcionNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.MensurablesDetalle", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.StockMensurable", "IdComponenteNavigation")
                        .WithOne("MensurablesDetalle")
                        .HasForeignKey("Aponus_Web_API.Models.MensurablesDetalle", "IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_MENSURABLES_DETALLE_STOCK_MENSURABLES");

                    b.HasOne("Aponus_Web_API.Models.ComponentesDescripcion", "IdDescripcionNavigation")
                        .WithMany("MensurablesDetalles")
                        .HasForeignKey("IdDescripcion")
                        .HasConstraintName("FK_MENSURABLES_DETALLE_COMPONENTES_DESCRIPCION");

                    b.Navigation("IdComponenteNavigation");

                    b.Navigation("IdDescripcionNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.PesablesDetalle", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.ComponentesDescripcion", "IdDescripcionNavigation")
                        .WithMany("PesablesDetalles")
                        .HasForeignKey("IdDescripcion")
                        .HasConstraintName("FK_PESABLES_DETALLE_COMPONENTES_DESCRIPCION");

                    b.Navigation("IdDescripcionNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.Producto", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.ProductosDescripcion", "IdDescripcionNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdDescripcion")
                        .IsRequired()
                        .HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");

                    b.HasOne("Aponus_Web_API.Models.ProductosTipo", "IdTipoNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdTipo")
                        .IsRequired()
                        .HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");

                    b.Navigation("IdDescripcionNavigation");

                    b.Navigation("IdTipoNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockCuantitativo", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.CuantitativosDetalle", "IdComponenteNavigation")
                        .WithOne("StockCuantitativo")
                        .HasForeignKey("Aponus_Web_API.Models.StockCuantitativo", "IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_STOCK_CUANTITATIVOS_CUANTITATIVOS_DETALLE");

                    b.Navigation("IdComponenteNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockPesable", b =>
                {
                    b.HasOne("Aponus_Web_API.Models.PesablesDetalle", "IdComponenteNavigation")
                        .WithOne("StockPesable")
                        .HasForeignKey("Aponus_Web_API.Models.StockPesable", "IdComponente")
                        .IsRequired()
                        .HasConstraintName("FK_STOCK_PESABLES_PESABLES_DETALLE");

                    b.Navigation("IdComponenteNavigation");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ComponentesDescripcion", b =>
                {
                    b.Navigation("ComponentesDescripcions");

                    b.Navigation("CuantitativosDetalles");

                    b.Navigation("MensurablesDetalles");

                    b.Navigation("PesablesDetalles");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.CuantitativosDetalle", b =>
                {
                    b.Navigation("ComponentesCuantitativos");

                    b.Navigation("StockCuantitativo");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.MensurablesDetalle", b =>
                {
                    b.Navigation("ComponentesMensurables");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.PesablesDetalle", b =>
                {
                    b.Navigation("ComponentesPesables");

                    b.Navigation("StockPesable");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.Producto", b =>
                {
                    b.Navigation("ComponentesCuantitativos");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ProductosDescripcion", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.ProductosTipo", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockCuantitativo", b =>
                {
                    b.Navigation("ComponentesCuantitativos");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockMensurable", b =>
                {
                    b.Navigation("ComponentesMensurables");

                    b.Navigation("MensurablesDetalle");
                });

            modelBuilder.Entity("Aponus_Web_API.Models.StockPesable", b =>
                {
                    b.Navigation("ComponentesPesables");
                });
#pragma warning restore 612, 618
        }
    }
}