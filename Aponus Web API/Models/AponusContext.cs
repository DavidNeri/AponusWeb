using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Models;

public partial class AponusContext : DbContext
{
    public AponusContext()
    {
    }

    public AponusContext(DbContextOptions<AponusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComponentesCuantitativo> ComponentesCuantitativos { get; set; }

    public virtual DbSet<ComponentesDescripcion> ComponentesDescripcions { get; set; }

    public virtual DbSet<ComponentesMensurable> ComponentesMensurables { get; set; }

    public virtual DbSet<ComponentesPesable> ComponentesPesables { get; set; }

    public virtual DbSet<CuantitativosDetalle> CuantitativosDetalles { get; set; }

    public virtual DbSet<MensurablesDetalle> MensurablesDetalles { get; set; }

    public virtual DbSet<PesablesDetalle> PesablesDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductosDescripcion> ProductosDescripcions { get; set; }

    public virtual DbSet<ProductosTipo> ProductosTipos { get; set; }

    public virtual DbSet<StockCuantitativo> StockCuantitativos { get; set; }

    public virtual DbSet<StockMensurable> StockMensurables { get; set; }

    public virtual DbSet<StockPesable> StockPesables { get; set; }
    public virtual DbSet<ComponentesTipos> ComponentesTipos { get; set; }
         

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DAVID\\DATABASESERVER19; Database=Aponus;User Id=Administrador;Password=AponusIng;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        modelBuilder.Entity<ComponentesCuantitativo>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.IdComponente });

            entity.ToTable("COMPONENTES_CUANTITATIVOS");

            entity.Property(e => e.IdProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(18, 1)")
                .HasColumnName("CANTIDAD");

            entity.HasOne(d => d.IdComponenteNavigation).WithMany(p => p.ComponentesCuantitativos)
                .HasForeignKey(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)                
                .HasConstraintName("FK_COMPONENTES_CUANTITATIVOS_CUANTITATIVOS_DETALLE");

            entity.HasOne(d => d.IdComponente1).WithMany(p => p.ComponentesCuantitativos)
                .HasForeignKey(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPONENTES_CUANTITATIVOS_STOCK_CUANTITATIVOS");
        });

        modelBuilder.Entity<ComponentesTipos>(entity =>
        {
            entity.HasKey(e => e.IdDescripcionTipo);
            entity.ToTable("COMPONENTES_TIPOS");
            entity.Property(e => e.IdDescripcionTipo)
            .HasDefaultValueSql("((0))")
            .HasColumnName("ID_DESCRIPCION_TIPO")
            .IsUnicode(false);

            entity.Property(e=>e.DescripcionTipo)
            .HasDefaultValueSql("((0))")
            .HasColumnName("DESCRIPCION_TIPO")
            .IsUnicode(false);

           



        });

        modelBuilder.Entity<ComponentesDescripcion>(entity =>
        {
            entity.HasKey(e => e.IdDescripcion);

            entity.ToTable("COMPONENTES_DESCRIPCION");

            entity.Property(e => e.IdDescripcion)
                .HasDefaultValueSql("((-1))")
                .HasColumnName("ID_DESCRIPCION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

        });

        modelBuilder.Entity<ComponentesMensurable>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.IdComponente });

            entity.ToTable("COMPONENTES_MENSURABLES");

            entity.Property(e => e.IdProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.Altura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ALTURA");
            entity.Property(e => e.Largo)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("LARGO");

            entity.HasOne(d => d.IdComponenteNavigation).WithMany(p => p.ComponentesMensurables)
                .HasForeignKey(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPONENTES_MENSURABLES_MENSURABLES_DETALLE");

            entity.HasOne(d => d.IdComponente1).WithMany(p => p.ComponentesMensurables)
                .HasForeignKey(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPONENTES_MENSURABLES_STOCK_MENSURABLES");
        });

        modelBuilder.Entity<ComponentesPesable>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.IdComponente });

            entity.ToTable("COMPONENTES_PESABLES");

            entity.Property(e => e.IdProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.Peso)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PESO");

            entity.HasOne(d => d.IdComponenteNavigation).WithMany(p => p.ComponentesPesables)
                .HasForeignKey(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPONENTES_PESABLES_PESABLES_DETALLE1");

            entity.HasOne(d => d.IdComponente1).WithMany(p => p.ComponentesPesables)
                .HasForeignKey(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPONENTES_PESABLES_STOCK_PESABLES");
        });

        modelBuilder.Entity<CuantitativosDetalle>(entity =>
        {
            entity.HasKey(e => e.IdComponente);

            entity.ToTable("CUANTITATIVOS_DETALLE");

            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.Altura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ALTURA");
            entity.Property(e => e.Diametro)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DIAMETRO");

            entity.Property(e => e.Espesor)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ESPESOR");

            entity.Property(e => e.Perfil)
            .IsRequired(false)
            .HasDefaultValueSql("null")
            .HasColumnName("PERFIL");          


            entity.Property(e => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
            entity.Property(e => e.Perfil).HasColumnName("PERFIL");
            entity.Property(e => e.ToleranciaMaxima)
                .HasDefaultValueSql("((0))")
                .HasColumnName("TOLERANCIA_MAXIMA");
            entity.Property(e => e.ToleranciaMinima)
                .HasDefaultValueSql("((0))")
                .HasColumnName("TOLERANCIA_MINIMA");

            entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.CuantitativosDetalles)
                .HasForeignKey(d => d.IdDescripcion)
                .HasConstraintName("FK_CUANTITATIVOS_DETALLE_COMPONENTES_DESCRIPCION");
        });

        modelBuilder.Entity<MensurablesDetalle>(entity =>
        {
            entity.HasKey(e => e.IdComponente);

            entity.ToTable("MENSURABLES_DETALLE");

            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.Altura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ALTURA");
            entity.Property(e => e.Ancho)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ANCHO");
            entity.Property(e => e.Espesor)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ESPESOR");
            entity.Property(e => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
            entity.Property(e => e.Largo)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("LARGO");
            entity.Property(e => e.Perfil)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PERFIL");

            entity.HasOne(d => d.IdComponenteNavigation).WithOne(p => p.MensurablesDetalle)
                .HasForeignKey<MensurablesDetalle>(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MENSURABLES_DETALLE_STOCK_MENSURABLES");

            entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.MensurablesDetalles)
                .HasForeignKey(d => d.IdDescripcion)
                .HasConstraintName("FK_MENSURABLES_DETALLE_COMPONENTES_DESCRIPCION");
        });

        modelBuilder.Entity<PesablesDetalle>(entity =>
        {
            entity.HasKey(e => e.IdComponente);

            entity.ToTable("PESABLES_DETALLE");

            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.Altura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ALTURA");
            entity.Property(e => e.Diametro)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DIAMETRO");
            entity.Property(e => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");

            entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.PesablesDetalles)
                .HasForeignKey(d => d.IdDescripcion)
                .HasConstraintName("FK_PESABLES_DETALLE_COMPONENTES_DESCRIPCION");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.IdProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.DiametroNominal).HasColumnName("DIAMETRO_NOMINAL");
            entity.Property(e => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
            entity.Property(e => e.IdTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_TIPO");
            entity.Property(e => e.Precio)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money")
                .HasColumnName("PRECIO");
            entity.Property(e => e.ToleranciaMaxima).HasColumnName("TOLERANCIA_MAXIMA");
            entity.Property(e => e.ToleranciaMinima).HasColumnName("TOLERANCIA_MINIMA");

            entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.Productos)
                 
                .HasForeignKey(d=>d.IdDescripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");
        });

        modelBuilder.Entity<ProductosDescripcion>(entity =>
        {
            entity.HasKey(e => e.IdDescripcion);

            entity.ToTable("PRODUCTOS_DESCRIPCION");

            entity.Property(e => e.IdDescripcion)
                .ValueGeneratedNever()
                .HasColumnName("ID_DESCRIPCION");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<ProductosTipo>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK_Table_1");

            entity.ToTable("PRODUCTOS_TIPOS");

            entity.Property(e => e.IdTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_TIPO");
            entity.Property(e => e.DescripcionTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<StockCuantitativo>(entity =>
        {
            entity.HasKey(e => e.IdComponente);

            entity.ToTable("STOCK_CUANTITATIVOS");

            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.CantidadGranallado)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD_GRANALLADO");
            entity.Property(e => e.CantidadPintura)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD_PINTURA");
            entity.Property(e => e.CantidadProceso)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD_PROCESO");
            entity.Property(e => e.CantidadRecibido)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD_RECIBIDO");
            entity.Property(e => e.CantidadMoldeado)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD_MOLDEADO");



            entity.HasOne(d => d.IdComponenteNavigation).WithOne(p => p.StockCuantitativo)
                .HasForeignKey<StockCuantitativo>(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STOCK_CUANTITATIVOS_CUANTITATIVOS_DETALLE");
        });

        modelBuilder.Entity<StockMensurable>(entity =>
        {
            entity.HasKey(e => e.IdComponente);

            entity.ToTable("STOCK_MENSURABLES");

            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.CantidadProceso)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD_PROCESO");
            entity.Property(e => e.CantidadRecibido)
                .HasDefaultValueSql("((0))")
                .HasColumnName("CANTIDAD_RECIBIDO");
        });

        modelBuilder.Entity<StockPesable>(entity =>
        {
            entity.HasKey(e => e.IdComponente);

            entity.ToTable("STOCK_PESABLES");

            entity.Property(e => e.IdComponente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.CantidadPintura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANTIDAD_PINTURA");
            entity.Property(e => e.CantidadProceso)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANTIDAD_PROCESO");
            entity.Property(e => e.CantidadRecibido)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANTIDAD_RECIBIDO");

            entity.HasOne(d => d.IdComponenteNavigation).WithOne(p => p.StockPesable)
                .HasForeignKey<StockPesable>(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STOCK_PESABLES_PESABLES_DETALLE");
        });

        OnModelCreatingPartial(modelBuilder);

       
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
