using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models;

public partial class AponusContext : DbContext
{
    public AponusContext(){}
    public AponusContext(DbContextOptions<AponusContext> options) : base(options) { }
    public virtual DbSet<ComponentesDetalle> ComponentesDetalles { get; set; }
    public virtual DbSet<Productos_Componentes> Componentes_Productos{ get; set; }
    public virtual DbSet<Stock_Movimientos> Stock_Movimientos { get; set; }
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
    public virtual DbSet<Clientes_Proveedores> Proveedores { get; set; }
    public virtual DbSet<SuministrosMovimientosStock> SuministrosMovimientoStock { get; set; }
    public virtual DbSet<EstadosProductos> EstadosProducto { get; set; }
    public virtual DbSet<EstadosProductosComponentes> EstadosProductosComponente { get; set; }
    public virtual DbSet<EstadosComponentesDetalles> EstadosComponentesDetalle { get; set; }
    public virtual DbSet<EstadosTiposProductos> EstadosTiposProducto { get; set; }
    public virtual DbSet<EstadosProductosDescripciones> EstadosProductosDescripcione { get; set; }
    public virtual DbSet<EstadosMovimientosStock> EstadoMovimientosStock { get; set; }
    public virtual DbSet<EstadosArchivosMovimientosStock> EstadoArchivosMovimientosStock { get; set; }
    public virtual DbSet<EstadosSuministrosMovimientosStock> EstadoSuministrosMovimientosStock { get; set; }
    public virtual DbSet<CategoriasClientes> CategoriasClientes { get; set; }
    public virtual DbSet<TiposClientes> tiposClientes { get; set; }
    public virtual DbSet<Compras> compras{ get; set; }
    public virtual DbSet<PagosCompras> PagosCompra { get; set; }
    public virtual DbSet<ComprasDetalles> ComprasDetalle { get; set; }
    public virtual DbSet<MediosPago> MediosPagos { get; set; }
    public virtual DbSet<Ventas> ventas { get; set; }
    public virtual DbSet<PagosVentas> pagosVentas { get; set; }
    public virtual DbSet<VentasDetalles> ventasDetalle { get; set; }
    public virtual DbSet<EstadosVentas> estadosVentas { get; set; }
    public virtual DbSet<CuotasVentas> cuotasVentas{ get; set; }
    public virtual DbSet<EstadosCuotasVentas> estadosCuotasVentas { get; set; }

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

        modelBuilder.Entity<EstadosCuotasVentas>(entity =>
        {
            entity.ToTable("ESTADOS_CUOTAS_VENTAS");

            entity.HasKey(pk => pk.IdEstadoCuota);

            entity.Property(p => p.IdEstadoCuota)
            .HasColumnType("int")
            .HasColumnName("ID_ESTADO_CUOTA")
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("varchar(MAX)");

            entity.Property(p => p.IdEstado)
            .HasColumnType("int")
            .HasColumnName("ID_ESTADO")
            .HasDefaultValueSql("1");

            entity.HasMany(p => p.IdEstadoCuotaNavigation)
            .WithOne(p => p.EstadoCuota)
            .HasPrincipalKey(p => p.IdEstadoCuota);


        });



        modelBuilder.Entity<CuotasVentas>(entity =>
        {
            entity.ToTable("CUOTAS_VENTAS");

            entity.HasKey(PK => PK.IdCuota);

            entity.Property(p => p.IdCuota)
            .HasColumnType("int")
            .HasColumnName("ID_CUOTA")
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(p => p.IdVenta)
            .HasColumnType("int")
            .HasColumnName("ID_VENTA");


            entity.Property(p => p.NumeroCuota)
            .HasColumnType("varchar(max)")
            .HasColumnName("NUMERO_CUOTA");

            entity.Property(p => p.Monto)
            .HasColumnName("MONTO")
            .HasColumnType("decimal(18,2)")
            .HasDefaultValueSql("0.00");

            entity.Property(p => p.FechaVencimiento)
            .HasColumnName("FECHA_VENCIMIENTO")
            .HasColumnType("datetime");

            entity.Property(p => p.IdEstadoCuota)
            .HasColumnName("ID_ESTADO_CUOTA")            
            .HasDefaultValueSql("0");

            entity.Property(p => p.FechaPago)
            .HasColumnName("FECHA_PAGO")
            .HasColumnType("datetime");        
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.ToTable("VENTAS");

            entity.HasKey(p => p.IdVenta);

            entity.Property(p => p.IdVenta)
            .HasColumnName("ID_VENTA")
            .HasColumnType("int")
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(p => p.IdCliente)
            .HasColumnName("ID_PROVEEDOR")
            .HasColumnType("int");

            entity.Property(p => p.FechaHora)
            .HasColumnName("FECHA_HORA")
            .HasColumnType("datetime");

            entity.Property(p => p.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("varchar(50)");

            entity.HasOne(p => p.Usuario)
            .WithMany(p => p.Ventas)
            .HasForeignKey(FK => FK.IdUsuario)
            .HasPrincipalKey(PK => PK.Usuario)
            .OnDelete(DeleteBehavior.NoAction);

            entity.Property(p => p.IdEstadoVenta)
            .HasColumnName("ID_ESTADO_VENTA")
            .HasColumnType("int");

            entity.Property(p => p.SaldoTotal)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("SALDO_TOTAL");

            entity.Property(p => p.SaldoCancelado)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("SALDO_CANCELADO");

            entity.HasOne(p => p.Estado)
            .WithMany(p => p.ventas)
            .HasForeignKey(FK => FK.IdEstadoVenta)
            .HasPrincipalKey(PK => PK.IdEstadoVenta);

            entity.HasOne(p => p.Cliente)
            .WithMany(p => p.ventas)
            .HasForeignKey(FK => FK.IdCliente)
            .HasPrincipalKey(PK => PK.IdEntidad)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(p => p.Pagos)
            .WithOne(p => p.Venta)
            .HasForeignKey(p => p.IdVenta);

            entity.HasMany(p => p.Cuotas)
            .WithOne(p => p.Venta)
            .HasPrincipalKey(P => P.IdVenta)
            .HasForeignKey(p => p.IdVenta);

        });

        modelBuilder.Entity<VentasDetalles>(entity =>
        {
            entity.ToTable("VENTAS_DETALLES");

            entity.HasKey(PK => new
            {
                PK.IdVenta,
                PK.IdProducto
            });

            entity.Property(p => p.IdVenta)
            .HasColumnType("int")
            .HasColumnName("ID_VENTA");

            entity.Property(p => p.IdProducto)
           .HasColumnType("varchar(50)")
           .HasColumnName("ID_PRODUCTO");

            entity.Property(p => p.Cantidad)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("CANTIDAD");

            entity.HasOne(p => p.Venta)
            .WithMany(p => p.DetallesVenta)
            .HasPrincipalKey(PK => PK.IdVenta)
            .HasForeignKey(FK => FK.IdVenta);

            entity.HasOne(p => p.IdProductoNavigation)
            .WithMany(p => p.Ventas)
            .HasForeignKey(FK => FK.IdProducto)
            .HasPrincipalKey(PK => PK.IdProducto);

        });

        modelBuilder.Entity<PagosVentas>(entity =>
        {
            entity.ToTable("PAGOS_VENTAS");

            entity.HasKey(PK => PK.IdPago);

            entity.Property(P => P.IdPago)
            .HasColumnName("ID_PAGO")
            .HasColumnType("int")
            .HasAnnotation("SqlServer:Identity", "1,1");

            entity.Property(p => p.IdVenta)
            .HasColumnType("int")
            .HasColumnName("ID_VENTA");

            entity.Property(p => p.IdMedioPago)
            .HasColumnName("ID_MEDIO_PAGO")
            .HasColumnType("int");

            entity.Property(p => p.CantidadCuotas)
           .HasColumnName("CANTIDAD_CUOTAS")
           .HasColumnType("int");

            entity.Property(p => p.CantidadCuotasCanceladas)
            .HasColumnName("CANTIDAD_CUOTAS_CANCELADAS")
            .HasColumnType("int");

            entity.Property(p => p.Subtotal)
            .HasColumnName("SUBTOTAL")
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Total)
            .HasColumnName("TOTAL")
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.SubtotalCancelado)
            .HasColumnName("SUBTOTAL_CANCELADO")
            .HasColumnType("decimal(18,2)");


            entity.HasOne(p => p.MedioPago)
            .WithMany(p => p.PagosVentasNavigation)
            .HasForeignKey(FK => FK.IdMedioPago)
            .HasPrincipalKey(PK => PK.IdMedioPago);

            entity.HasOne(p => p.Venta)
            .WithMany(p => p.Pagos)
            .HasPrincipalKey(PK => PK.IdVenta)
            .HasForeignKey(FK => FK.IdVenta);
        });

        modelBuilder.Entity<EstadosVentas>(entity =>
        {
            entity.ToTable("ESTADOS_VENTAS");

            entity.HasKey(PK => PK.IdEstadoVenta);

            entity.Property(P => P.IdEstadoVenta)
            .HasColumnName("ID_ESTADO_VENTA")
            .HasColumnType("int")
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(P => P.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int");

            entity.Property(P => P.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("nvarchar(max)");
        });




        modelBuilder.Entity<ComprasDetalles>(entity =>
        {
            entity.ToTable("COMPRAS_DETALLES");

            entity.HasKey(PK => new
            {
                PK.IdCompra,
                PK.IdInsumo
            });

            entity.Property(p => p.IdCompra)
            .HasColumnType("int")
            .HasColumnName("ID_COMPRA");

            entity.Property(p => p.IdInsumo)
           .HasColumnType("varchar(50)")
           .HasColumnName("ID_INSUMO");

            entity.Property(p => p.Cantidad)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("CANTIDAD");

            entity.HasOne(p => p.Compra)
            .WithMany(p => p.DetallesCompra)
            .HasPrincipalKey(PK=>PK.IdCompra)
            .HasForeignKey(FK=>FK.IdCompra);

            entity.HasOne(p => p.DetallesInsumo)
            .WithMany(p => p.ComprasNavigation)
            .HasForeignKey(FK => FK.IdInsumo)
            .HasPrincipalKey(PK => PK.IdInsumo);
        });

        modelBuilder.Entity<MediosPago>(entity =>
        {
            entity.ToTable("MEDIOS_PAGO");

            entity.HasKey(PK => PK.IdMedioPago);

            entity.Property(p => p.IdMedioPago)
            .HasColumnName("ID_MEDIO_PAGO")
            .HasColumnType("int")
            .HasAnnotation("SqlServer:Identity", "1,1");

            entity.Property(p => p.CodigoMPago)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("CODIGO_MPAGO");

            entity.Property(p => p.Descripcion)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("DESCRIPCION");

            entity.Property(p => p.IdEstado)
            .HasColumnType("int")
            .HasColumnName("ID_ESTADO");
        });

        modelBuilder.Entity<PagosCompras>(entity =>
        {
            entity.ToTable("PAGOS_COMPRAS");

            entity.HasKey(PK => PK.IdPago);

            entity.Property(P => P.IdPago)
            .HasColumnName("ID_PAGO")
            .HasColumnType("int")
            .HasAnnotation("SqlServer:Identity", "1,1");

            entity.Property(p => p.IdCompra)
            .HasColumnType("int")
            .HasColumnName("ID_COMPRA");

            entity.Property(p => p.IdMedioPago)
            .HasColumnName("ID_MEDIO_PAGO")
            .HasColumnType("int");

           entity.Property(p => p.CantidadCuotas)
          .HasColumnName("CANTIDAD_CUOTAS")
          .HasColumnType("int");

            entity.Property(p => p.CantidadCuotasCanceladas)
            .HasColumnName("CANTIDAD_CUOTAS_CANCELADAS")
            .HasColumnType("int");

            entity.Property(p => p.Subtotal)
            .HasColumnName("SUBTOTAL")
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Total)
            .HasColumnName("TOTAL")
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.SubtotalCancelado)
            .HasColumnName("SUBTOTAL_CANCELADO")
            .HasColumnType("decimal(18,2)");


            entity.HasOne(p=>p.MedioPago)
            .WithMany(p=>p.PagosComprasNavigation)
            .HasForeignKey(FK=>FK.IdMedioPago)
            .HasPrincipalKey(PK=>PK.IdMedioPago);

            entity.HasOne(p=>p.Compra)
            .WithMany(p=>p.Pagos)
            .HasPrincipalKey(PK=>PK.IdCompra)
            .HasForeignKey(FK=>FK.IdCompra);   


                
        });

        modelBuilder.Entity<EstadosCompras>(entity =>
        {
            entity.ToTable("ESTADOS_COMPRAS");

            entity.HasKey(PK => PK.IdEstadoCompra);

            entity.Property(P => P.IdEstadoCompra)
            .HasColumnName("ID_ESTADO_COMPRA")
            .HasColumnType("int")
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(P => P.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int");

            entity.Property(P => P.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("nvarchar(max)");

        });


        modelBuilder.Entity<Compras>(entity =>
        {
            entity.ToTable("COMPRAS");

            entity.HasKey(p=>p.IdCompra);

            entity.Property(p => p.IdCompra)
            .HasColumnName("ID_COMPRA")
            .HasColumnType("int")
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(p => p.IdProveedor)
            .HasColumnName("ID_PROVEEDOR")
            .HasColumnType("int");

            entity.Property(p => p.FechaHora)
            .HasColumnName("FECHA_HORA")
            .HasColumnType("datetime");

            entity.Property(p => p.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("varchar(50)");

            entity.HasOne(p => p.Usuario)
            .WithMany(p => p.Compras)
            .HasForeignKey(FK => FK.IdUsuario)
            .HasPrincipalKey(PK => PK.Usuario)
            .OnDelete(DeleteBehavior.NoAction);

            entity.Property(p => p.IdEstadoCompra)
            .HasColumnName("ID_ESTADO_COMPRA")
            .HasColumnType("int");

            entity.Property(p => p.SaldoTotal)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("SALDO_TOTAL");

            entity.Property(p => p.SaldoCancelado)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("SALDO_CANCELADO");

            entity.HasOne(p => p.Estado)
            .WithMany(p => p.compras)
            .HasForeignKey(FK => FK.IdEstadoCompra)
            .HasPrincipalKey(PK => PK.IdEstadoCompra);            

            entity.HasOne(p => p.Proveedor)
            .WithMany(p => p.compras)
            .HasForeignKey(FK => FK.IdProveedor)
            .HasPrincipalKey(PK => PK.IdEntidad)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(p => p.Pagos)
            .WithOne(p => p.Compra)
            .HasForeignKey(p => p.IdCompra);
        });
           
        modelBuilder.Entity<TiposClientes>(entity =>
        {
            entity.ToTable("CLIENTES_TIPOS");

            entity.HasKey(PK => PK.IdTipo);

            entity.Property(P => P.IdTipo)
            .HasColumnName("ID_TIPO")
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(P => P.IdEstado)
            .HasDefaultValueSql("1")
            .HasColumnType("varbinary(1)")
            .HasColumnName("ID_ESTADO");

            entity.Property(p => p.NombreTipo)
            .HasColumnName("NOMBRE")
            .HasColumnType("nvarchar(max)");

            entity.HasMany(p => p.Clientes)
            .WithOne(p => p.TipoCliente)
            .HasForeignKey(FK => FK.IdTipo);

        });

        modelBuilder.Entity<CategoriasClientes>(entity =>
        {
            entity.ToTable("CLIENTES_CATEGORIAS");

            entity.HasKey(PK => PK.IdCategoria);

            entity.Property(P => P.IdCategoria)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:Identity", "1, 1");

            entity.Property(P => P.IdEstado)
            .HasDefaultValueSql("1")
            .HasColumnType("varbinary(1)")
            .HasColumnName("ID_ESTADO");

            entity.Property(p => p.NombreCategoria)
            .HasColumnName("NOMBRE")
            .HasColumnType("nvarchar(max)");

            entity.HasMany(p => p.Clientes)
            .WithOne(p => p.CategoriaCliente)
            .HasForeignKey(FK => FK.IdCategoria);

        });


        modelBuilder.Entity<EstadosMovimientosStock>(entity =>
        {
            entity.ToTable("ESTADOS_MOVIMIENTOS_STOCK");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

            entity.Property(p => p.IdEstadoPropio)
            .HasColumnName("ID_ESTADO_PROPIO")
            .HasColumnType("varbinary(1)")
            .HasDefaultValueSql("1");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("nvarchar(max)");

            entity.HasMany(p => p.movimientosStock)
            .WithOne(p => p.estadoMovimiento)
            .HasForeignKey(p => p.IdEstado);
        });

        modelBuilder.Entity<EstadosArchivosMovimientosStock>(entity =>
        {
            entity.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("nvarchar(max)");           

            entity.HasMany(p => p.ArchivosMovimientoStock)
            .WithOne(p => p.ArchivosMovimientosStockNavigation)
            .HasForeignKey(p => p.IdEstado);
        });

        modelBuilder.Entity<EstadosSuministrosMovimientosStock>(entity =>
        {
            entity.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("nvarchar(max)");

            entity.HasMany(p => p.SuministrosMovimientoStock)
            .WithOne(p => p.EstadosSuministrosMovimientosStockNavigation)
            .HasForeignKey(p => p.IdEstado);
        });

        modelBuilder.Entity<EstadosProductosDescripciones>(entity =>
        {
            entity.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("nvarchar(max)");

            entity.HasMany(p => p.ProductosDescripcions)
            .WithOne(p => p.IdEstadoNavigation)
            .HasForeignKey(p => p.IdEstado);
        });

        modelBuilder.Entity<EstadosTiposProductos>(entity =>
        {
            entity.ToTable("ESTADOS_PRODUCTOS_TIPOS");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)");

            entity.Property(e => e.Descripcion)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("DESCRIPCION");

            entity.HasMany(e => e.ProductosTipos)
            .WithOne(e => e.IdEstadoNavigation)
            .HasForeignKey(e => e.IdEstado);
        });

        modelBuilder.Entity<EstadosComponentesDetalles>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)");

            entity.Property(e => e.Descripcion)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("DESCRIPCION");

            entity.HasMany(e => e.ComponentesDetalle)
            .WithOne(e => e.IdEstadoNavigation)
            .HasForeignKey(e => e.IdEstado);
        });

        modelBuilder.Entity<EstadosProductosComponentes>(entity =>
        {
            entity.HasKey(PK => PK.IdEstado);

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)");

            entity.Property(e => e.Descripcion)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("DESCRIPCION");

            entity.HasMany(e => e.ProductosComponentes)
            .WithOne(e => e.IdEstadoNavigation)
            .HasForeignKey(e => e.IdEstado);            
        });

        modelBuilder.Entity<EstadosProductos>(entity =>
        {
            entity.HasKey(PK => PK.IdEstado);

            entity.Property(entity => entity.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)");

            entity.Property(e => e.Descripcion)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("DESCRIPCION");

            entity.HasMany(e => e.Productos)
            .WithOne(e => e.IdEstadoNavigation)
            .HasForeignKey(e => e.IdEstado);
        });

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

            entity.Property(e => e.IdEstado)
           .HasColumnName("ID_ESTADO")
           .HasColumnType("Varbinary(1)")
           .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<StockInsumos>(entity =>
        {
            entity.ToTable("STOCK_INSUMOS");

            entity.Property(e => e.IdInsumo)
            .HasColumnName("ID_INSUMO")
            .HasColumnType("varchar(50)");

            entity.HasKey(PK => PK.IdInsumo)
            .HasName("PK_STOCK_INSUMOS");

            entity.Property(e => e.Recibido)
           .HasColumnName("RECIBIDO")
           .HasColumnType("decimal");

            entity.Property(e => e.Granallado)
            .HasColumnName("GRANALLADO")
            .HasColumnType("decimal");

            entity.Property(e => e.Pintura)
           .HasColumnName("PINTURA")
           .HasColumnType("decimal");


            entity.Property(e => e.Proceso)
           .HasColumnName("PROCESO")
           .HasColumnType("decimal");

            entity.Property(e => e.Moldeado)
           .HasColumnName("MOLDEADO")
           .HasColumnType("decimal");

            entity.Property(e => e.Pendiente)
          .HasColumnName("PENDIENTE")
          .HasColumnType("decimal(18,2)");
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

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)")
            .HasDefaultValueSql("1");
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

            entity.Property(e => e.IdEstado)
            .HasColumnType("varbinary(1)")
            .HasDefaultValueSql("1");

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

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)")
            .HasDefaultValueSql("1");

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

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)")
            .HasDefaultValueSql("1");
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

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("varbinary(1)")
            .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Productos_Tipos_Descripcion>(entity =>
        {
            entity.ToTable("PRODUCTOS_TIPOS_DESCRIPCION");
            entity.Property(e=>e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e=>e.IdDescripcion).HasColumnName("ID_DESCRIPCION");
            entity.HasKey(Key => new { Key.IdTipo, Key.IdDescripcion });

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

            entity.HasMany(e => e.IdUsuarioRegistroNavigation)
            .WithOne(u => u.UsuarioRegistro)
            .HasForeignKey(e => e.IdUsuarioRegistro);
        });

        modelBuilder.Entity<Stock_Movimientos>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento);

            entity.Property(e => e.IdMovimiento)
            .HasColumnName("ID_MOVIMIENTO")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

            entity.Property(e => e.CreadoUsuario)
            .HasColumnName("USUARIO_CREADO")
            .HasColumnType("nvarchar(50)");

            entity.Property(e => e.ModificadoUsuario)
            .HasColumnName("USUARIO_MODIFICA")
            .HasColumnType("nvarchar(50)");

            entity.Property(e => e.FechaHoraCreado)
            .HasColumnName("FECHA_HORA_CREADO")
            .HasColumnType("datetime2(7)");

            entity.Property(e => e.FechaHoraUltimaModificacion)
            .HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION")
            .HasColumnType("datetime2(7)");

            entity.Property(e => e.IdProveedorOrigen)
            .HasColumnName("ID_PROVEEDOR_ORIGEN")
            .HasColumnType("int");

            entity.Property(e => e.IdProveedorDestino)
            .HasColumnName("ID_PROVEEDOR_DESTINO")
            .HasColumnType("int");

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int")
            .HasDefaultValueSql("1");

            entity.Property(e => e.Origen)
            .HasColumnName("ORIGEN")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.Destino)
            .HasColumnName("DESTINO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.Tipo)
           .HasColumnName("TIPO")
           .HasColumnType("varchar(15)");

            entity.HasOne(e => e.ProveedorOrigen)
            .WithMany(e => e.MovimientosOrigen)
            .HasForeignKey(e=>e.IdProveedorOrigen);

            entity.HasOne(e => e.ProveedorDestino)
            .WithMany(e => e.MovimientosDestino)
            .HasForeignKey(e => e.IdProveedorDestino);

        });

        modelBuilder.Entity<ArchivosMovimientosStock>(entity =>
        {
            entity.HasKey( e => new
            {
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

            entity.Property(e => e.MimeType)
           .HasColumnName("MIME_TYPE")
           .HasColumnType("varchar(MAX)");

            entity.HasOne(e => e.StockMovimiento).WithMany()
            .HasForeignKey(e => e.IdMovimiento)
            .HasPrincipalKey(p => p.IdMovimiento);

            entity.Property(e => e.IdEstado)
           .HasColumnName("ID_ESTADO")
           .HasColumnType("Varbinary(1)")
           .HasDefaultValueSql("1");

        });

        modelBuilder.Entity<Clientes_Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdEntidad);
            entity.ToTable("CLIENTES_PROVEEDORES");

            entity.Property(e => e.IdEntidad)
                .HasColumnName("ID_ENTIDAD");

            entity.Property(e => e.NombreClave)
                .HasColumnName("NOMBRE_CLAVE");

            entity.Property(e => e.Nombre)
            .HasColumnName("NOMBRE")
            .HasColumnType("varchar(max)");

            entity.Property(e => e.Apellido)
            .HasColumnName("APELLIDO")
            .HasColumnType("varchar(max)");

            entity.Property(e => e.Pais)
                .HasColumnName("PAIS");

            entity.Property(e => e.Ciudad)
                .HasColumnName("CIUDAD");

            entity.Property(e => e.Localidad)
                .HasColumnName("LOCALIDAD")
                .HasColumnType("varchar(MAX)");

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

            entity.Property(e => e.IdUsuarioRegistro)
            .HasColumnName("ID_USUARIO_REGISTRO")
            .HasColumnType("varchar(50)")
            .IsRequired();

            entity.Property(x => x.Barrio)
            .HasColumnName("BARRIO")
            .HasColumnType("varchar(max)");

            entity.Property(x => x.IdTipo)
            .HasColumnName("ID_TIPO")
            .HasColumnType("int");

            entity.Property(x => x.IdCategoria)
            .HasColumnName("ID_CATEGORIA")
            .HasColumnType("int");

            entity.Property(e => e.IdEstado)
                .HasColumnName("ID_ESTADO")
                .HasColumnType("varbinary(1)")
                .HasDefaultValueSql("(1)");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
