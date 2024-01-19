using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
    public virtual DbSet<ComponentesDetalle> ComponentesDetalles { get; set; }
    public virtual DbSet<Productos_Componentes> Componentes_Productos{ get; set; }
    public   virtual DbSet<Stock_Movimientos> Stock_Movimientos { get; set; }
    public virtual DbSet<ArchivosMovimientosStock> ArchivosStock { get; set; }
    public virtual DbSet<StockInsumos> stockInsumos { get; set; }
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
    public virtual DbSet<Productos_Tipos_Descripcion> Producto_Tipo_Descripcion { get; set; }
    public virtual DbSet<StockCuantitativo> StockCuantitativos { get; set; }
    public virtual DbSet<StockMensurable> StockMensurables { get; set; }
    public virtual DbSet<StockPesable> StockPesables { get; set; }
    public virtual DbSet<Usuarios> Usuarios { get; set; }
    public virtual DbSet<Proveedores> Proveedores { get; set; }
    public virtual DbSet<SuministrosMovimientosStock> SuministrosMovimientoStock { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder
            .UseSqlServer("Server=DAVID\\DATABASESERVER19; Database=Aponus;User Id=Administrador;Password=AponusIng;Trusted_Connection=True; TrustServerCertificate=True;")
            .EnableSensitiveDataLogging();


    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        modelBuilder.Entity<SuministrosMovimientosStock>(entity =>
        {
            entity.ToTable("SUMINISTROS_MOVIMIENTOS_STOCK");
            entity.HasKey(PK => new
            {
                PK.IdMovimiento,
                PK.IdSuministro
            });

            entity.Property(e => e.IdMovimiento)
            .HasColumnName("ID_MOVIMIENTO")
            .HasColumnType("int");

            entity.Property(e=>e.IdSuministro)
            .HasColumnName("ID_SUMINISTRO")
            .HasColumnType("nvarchar(50)");

            entity.Property(e => e.CampoStockOrigen)
            .HasColumnType("CAMPO_STOCK_ORIGEN")
            .HasColumnType("nvarchar(50)");

            entity.Property(e => e.CampoStockDestino)
           .HasColumnType("CAMPO_STOCK_DESTINO")
           .HasColumnType("nvarchar(50)");

            entity.Property(e => e.ValorAnteriorOrigen)
           .HasColumnType("VALOR_ANTERIOR_ORIGEN")
           .HasColumnType("decimal(18,2)");

            entity.Property(e => e.ValorAnteriorDestino)
            .HasColumnType("VALOR_ANTERIOR_DESTINO")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.ValorNuevoOrigen)
            .HasColumnType("VALOR_NUEVO_ORIGEN")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.ValorNuevoOrigen)
            .HasColumnType("VALOR_NUEVO_DESTINO")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Cantidad)
            .HasColumnName("CANTIDAD")
            .HasColumnType("decimal(18,2)");
        
            
        });



        modelBuilder.Entity<StockInsumos>(entity =>
        {
            entity.ToTable("STOCK_INSUMOS");

            entity.Property(e => e.IdInsumo)
            .HasColumnName("ID_INSUMO")
            .HasColumnType("varchar(50)");

            entity.HasKey(PK => PK.IdInsumo)
            .HasName("PK_STOCK_INSUMOS");

            entity.Property(e => e.CantidadRecibido)
           .HasColumnName("CANTIDAD_RECIBIDO")
           .HasColumnType("decimal");

            entity.Property(e => e.CantidadGranallado)
            .HasColumnName("CANTIDAD_GRANALLADO")
            .HasColumnType("decimal");

            entity.Property(e => e.CantidadPintura)
           .HasColumnName("CANTIDAD_PINTURA")
           .HasColumnType("decimal");


            entity.Property(e => e.CantidadProceso)
           .HasColumnName("CANTIDAD_PROCESO")
           .HasColumnType("decimal");

            entity.Property(e => e.CantidadMoldeado)
           .HasColumnName("CANTIDAD_MOLDEADO")
           .HasColumnType("decimal");

        });

        modelBuilder.Entity<Productos_Componentes>(entity => 
        {
            entity.ToTable("PRODUCTOS_COMPONENTES");

            entity.Property(e=>e.IdProducto)
            .HasColumnName("ID_PRODUCTO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.IdComponente)
           .HasColumnName("ID_COMPONENTE")
           .HasColumnType("varchar(50)");

            entity.HasKey(PK => new { PK.IdProducto, PK.IdComponente })
            .HasName("PK_PRODUCTOS_COMPONENTES");

            entity.Property(e => e.Cantidad)
            .HasColumnName("CANTIDAD")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Peso)
            .HasColumnName("PESO")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Longitud)
             .HasColumnName("LONGITUD")
             .HasColumnType("decimal(18,2)");

        });



        modelBuilder.Entity<ComponentesDetalle>(entity =>
        {
            entity.Property(e => e.IdInsumo)
            .HasColumnName("ID_INSUMO")
            .HasColumnType("varchar(50)");

            entity.HasKey(e=>e.IdInsumo)
            .HasName("PK_ID_INSUMO");

            entity.ToTable("COMPONENTES_DETALLE");

            entity.Property(e => e.IdDescripcion)
            .HasColumnName("ID_DESCRIPCION");

            entity.Property(e => e.Diametro)
            .HasColumnName("DIAMETRO")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.DiametroNominal)
           .HasColumnName("DIAMETRO_NOMINAL")
           .HasColumnType("int")
           .IsRequired(false)
           .HasDefaultValue(null);

            entity.Property(e => e.Espesor)
            .HasColumnName("ESPESOR")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Longitud)
          .HasColumnName("LONGITUD")
          .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Altura)
          .HasColumnName("ALTURA")
          .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Perfil)
          .HasColumnName("PERFIL");

            entity.Property(e => e.Tolerancia)
          .HasColumnName("TOLERANCIA")
          .HasColumnType("varchar(50)");

            entity.Property(e => e.Peso)
         .HasColumnName("PESO")
         .HasColumnType("decimal(18,3)");

            entity.Property(e => e.IdFraccionamiento)
                .HasColumnName("ID_FRACCIONAMIENTO")
                    .HasColumnType("nvarchar(50)");

        entity.Property(e => e.IdAlmacenamiento)
                     .HasColumnName("ID_ALMACENAMIENTO")
                     .HasColumnType("nvarchar(50)");



        });


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
                .HasColumnType("int")
                .HasDefaultValueSql("((0))")
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


        

        modelBuilder.Entity<ComponentesDescripcion>(entity =>
        {
            entity.HasKey(e => e.IdDescripcion);
            

            entity.ToTable("COMPONENTES_DESCRIPCION");

            entity.Property(e => e.IdDescripcion)
                .HasColumnName("ID_DESCRIPCION")
                .UseIdentityColumn(1, 1);

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
            entity.Property(e => e.Cantidad)
            .HasColumnName("CANTIDAD")
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValueSql("NULL");

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
            entity.Property(e => e.Tolerancia)
            .HasColumnName("TOLERANCIA");

           // entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.CuantitativosDetalles)
             //   .HasForeignKey(d => d.IdDescripcion)
               // .HasConstraintName("FK_CUANTITATIVOS_DETALLE_COMPONENTES_DESCRIPCION");
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

           // entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.MensurablesDetalles)
             //   .HasForeignKey(d => d.IdDescripcion)
               // .HasConstraintName("FK_MENSURABLES_DETALLE_COMPONENTES_DESCRIPCION");
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
                .HasColumnName("DIAMETRO");
            entity.Property(e => e.IdDescripcion).HasColumnName("ID_DESCRIPCION");

          //  entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.PesablesDetalles)
            //    .HasForeignKey(d => d.IdDescripcion)
              //  .HasConstraintName("FK_PESABLES_DETALLE_COMPONENTES_DESCRIPCION");
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
            entity.Property(e => e.PrecioLista)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money")
                .HasColumnName("PRECIO_LISTA");

            entity.Property(e => e.PrecioFinal)
            .HasColumnName("PRECIO_FINAL");

            entity.Property(e => e.PorcentajeGanancia)
            .HasColumnName("PORCENTAJE_GANANCIA");
            
            entity.Property(e => e.Tolerancia).HasColumnName("TOLERANCIA");

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
            entity.HasKey(e => e.IdDescripcion) ;

            entity.ToTable("PRODUCTOS_DESCRIPCION");

            entity.Property(e => e.IdDescripcion)
                .HasColumnName("ID_DESCRIPCION");

            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");


            /*entity.HasMany(e => e.Producto_Tipo_Descripcione)
            .WithOne(e => e.IdDescripcionNavigation)
            .HasForeignKey(e => e.IdDescripcion)
            .HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION");
            ;

            */

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

            /*entity.HasMany(e => e.Producto_Tipo_Descripcione)
            .WithOne(e => e.IdTipoNavigation)
            .HasForeignKey(e => e.IdTipo)
            .HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO");
            */


        });
        modelBuilder.Entity<Productos_Tipos_Descripcion>(entity =>
        {
            entity.ToTable("PRODUCTOS_TIPOS_DESCRIPCION");
            entity.Property(e=>e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e=>e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
            entity.HasKey(Key => new { Key.IdTipo, Key.IdDescripcion });

          /* entity.HasOne(e => e.IdTipoNavigation)
            .WithMany()
            .HasForeignKey(e=>e.IdTipo)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO")
            .IsRequired();
          */
            /*entity.HasOne(e => e.IdDescripcionNavigation)
            .WithMany()
            .HasForeignKey(e => e.IdDescripcion)
            .HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
          */

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

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Usuario);

            entity.Property(e => e.Usuario)
            .HasColumnName("USUARIO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.IdPerfil)
            .HasColumnName("ID_PERFIL")
            .HasColumnType("int");
            

            entity.Property(e => e.correo)
            .HasColumnName("CORREO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.Contraseña)
            .HasColumnName("CONTRASEÑA")
            .HasColumnType("varchar(50)");


        });

        modelBuilder.Entity<Stock_Movimientos>(entity =>
        {

            entity.HasKey(e=>
                e.IdMovimiento
            );


            entity.Property(e => e.IdMovimiento)
            .HasColumnName("ID_MOVIMIENTO")
            .HasColumnType("int");

            entity.Property(e => e.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("nvarchar(50)");

            entity.Property(e => e.FechaHora)
            .HasColumnName("FECHA_HORA")
            .HasColumnType("datetime2(7)");

            entity.Property(e => e.IdProveedorOrigen)
            .HasColumnName("ID_PROVEEDOR_ORIGEN")
            .HasColumnType("int");

            entity.Property(e => e.IdProveedorDestino)
            .HasColumnName("ID_PROVEEDOR_DESTINO")
            .HasColumnType("int");

            entity.HasOne(e => e.ProveedorOrigen)
            .WithMany(e => e.MovimientosOrigen)
            .HasForeignKey(e=>e.IdProveedorOrigen);

            entity.HasOne(e => e.ProveedorDestino)
            .WithMany(e => e.MovimientosDestino)
            .HasForeignKey(e => e.IdProveedorDestino);

        });


        modelBuilder.Entity<ArchivosMovimientosStock>(entity =>
        {
            entity.HasKey( e=> new{
                e.IdMovimiento,
                e.HashArchivo
            });

            entity.ToTable("ARCHIVOS_STOCK");
            entity.Property(e => e.IdMovimiento)
            .HasColumnName("ID_MOVIMIENTO");

            entity.Property(e => e.HashArchivo)
            .HasColumnName("HASH_ARCHIVO")
            .HasColumnType("varchar(255)");

            entity.Property(e => e.PathArchivo)
            .HasColumnName("PATH")
            .HasColumnType("varchar(MAX)");

            entity.HasOne(e => e.StockMovimiento).WithMany()
            .HasForeignKey(e => e.IdMovimiento)
            .HasPrincipalKey(p => p.IdMovimiento);


        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);
            entity.ToTable("PROVEEDORES");

            entity.Property(e => e.IdProveedor)
        .HasColumnName("ID_PROVEEDOR");

            entity.Property(e => e.NombreProveedor)
                .HasColumnName("NOMBRE_PROVEEDOR");

            entity.Property(e => e.Pais)
                .HasColumnName("PAIS");

           // entity.Property(e => e.Ciudad)
             //   .HasColumnName("CIUDAD");

            entity.Property(e => e.Localidad)
                .HasColumnName("LOCALIDAD");

            entity.Property(e => e.Calle)
                .HasColumnName("CALLE");

            entity.Property(e => e.Altura)
                .HasColumnName("ALTURA");

            entity.Property(e => e.CodigoPostal)
                .HasColumnName("CODIGO_POSTAL");

            entity.Property(e => e.Telefono1)
                .HasColumnName("TELEFONO_1");

            entity.Property(e => e.Telefono2)
                .HasColumnName("TELEFONO_2");

            entity.Property(e => e.Telefono3)
                .HasColumnName("TELEFONO_3");

            entity.Property(e => e.Email)
                .HasColumnName("EMAIL");

            entity.Property(e => e.IdFiscal)
                .HasColumnName("ID_FISCAL");

            entity.Property(e => e.FechaRegistro)
                .HasColumnName("FECHA_REGISTRO");

            entity.Property(e => e.Estado)
                .HasColumnName("ESTADO");







        });


        OnModelCreatingPartial(modelBuilder);

       
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
