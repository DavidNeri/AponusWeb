using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aponus_Web_API.Modelos;

public partial class AponusContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AponusContext(DbContextOptions<AponusContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;

    }
    //public AponusContext() { }
    public virtual DbSet<ComponentesDetalle> ComponentesDetalles { get; set; }
    public virtual DbSet<Productos_Componentes> Componentes_Productos { get; set; }
    public virtual DbSet<Stock_Movimientos> Stock_Movimientos { get; set; }
    public virtual DbSet<ArchivosMovimientosStock> ArchivosStock { get; set; }
    public virtual DbSet<StockInsumos> stockInsumos { get; set; }
    public virtual DbSet<ComponentesDescripcion> ComponentesDescripcions { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<ProductosDescripcion> ProductosDescripcions { get; set; }
    public virtual DbSet<ProductosTipo> ProductosTipos { get; set; }
    public virtual DbSet<Productos_Tipos_Descripcion> Producto_Tipo_Descripcion { get; set; }
    public virtual DbSet<Usuarios> Usuarios { get; set; }
    public virtual DbSet<Entidades> Entidades { get; set; }
    public virtual DbSet<SuministrosMovimientosStock> SuministrosMovimientoStock { get; set; }
    public virtual DbSet<EstadosProductos> EstadosProducto { get; set; }
    public virtual DbSet<EstadosProductosComponentes> EstadosProductosComponente { get; set; }
    public virtual DbSet<EstadosComponentesDetalles> EstadosComponentesDetalle { get; set; }
    public virtual DbSet<EstadosTiposProductos> EstadosTiposProducto { get; set; }
    public virtual DbSet<EstadosProductosDescripciones> EstadosProductosDescripcione { get; set; }
    public virtual DbSet<EstadosMovimientosStock> EstadoMovimientosStock { get; set; }
    public virtual DbSet<EstadosArchivosMovimientosStock> EstadoArchivosMovimientosStock { get; set; }
    public virtual DbSet<EstadosSuministrosMovimientosStock> EstadoSuministrosMovimientosStock { get; set; }
    public virtual DbSet<EntidadesCategorias> CategoriasEntidades { get; set; }
    public virtual DbSet<EntidadesTipos> TiposEntidades { get; set; }
    public virtual DbSet<EntidadesTiposCategorias> EntidadeTiposCategorias { get; set; }
    public virtual DbSet<Compras> Compra { get; set; }
    public virtual DbSet<PagosCompras> PagosCompra { get; set; }
    public virtual DbSet<ComprasDetalles> ComprasDetalle { get; set; }
    public virtual DbSet<EstadosCompras> EstadosCompra { get; set; }
    public virtual DbSet<CuotasCompras> CuotasCompra { get; set; }
    public virtual DbSet<EstadosCuotasCompras> EstadosCuotasCompra { get; set; }
    public virtual DbSet<MediosPago> MediosPagos { get; set; }
    public virtual DbSet<Ventas> ventas { get; set; }
    public virtual DbSet<PagosVentas> pagosVentas { get; set; }
    public virtual DbSet<VentasDetalles> ventasDetalle { get; set; }
    public virtual DbSet<EstadosVentas> estadosVentas { get; set; }
    public virtual DbSet<CuotasVentas> cuotasVentas { get; set; }
    public virtual DbSet<EstadosCuotasVentas> estadosCuotasVentas { get; set; }
    public virtual DbSet<RolesUsuarios> rolesUsuarios { get; set; }
    public virtual DbSet<Auditorias> Auditorias { get; set; }
    public virtual DbSet<AsignacionPermisosRoles> asignacionRoles { get; set; }
    public virtual DbSet<EntidadesPago> entidadespago { get; set; }
    public virtual DbSet<ArchivosVentas> ArchivosVentas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


    }
    public override int SaveChanges()
    {
        RegistrarAuditoria();
        return base.SaveChanges();
    }
    public override async Task<int> SaveChangesAsync(CancellationToken TokenCancelacion = default)
    {
        RegistrarAuditoria();
        return await base.SaveChangesAsync(TokenCancelacion);
    }
    private void RegistrarAuditoria()
    {
        var auditorias = new List<Auditorias>();

        var Cambios = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

        foreach (var cambio in Cambios)
        {
            var Tabla = cambio.Entity.GetType().Name;
            var IdRegistro = ObtenerClavePrimaria(cambio);
           
            var usuario = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Usuario Desconocido";

            Auditorias auditoria = new()
            {
                Tabla = Tabla,
                IdRegistro = IdRegistro,
                Usuario = usuario,
                Fecha = UTL_Fechas.ObtenerFechaHora()
            };

            switch (cambio.State)
            {
                case EntityState.Added:
                    auditoria.Accion = "CREACION";
                    auditoria.ValoresPrevios = "";
                    auditoria.ValoresNuevos = JsonConvert.SerializeObject(cambio.CurrentValues.ToObject());
                    break;

                case EntityState.Modified:
                    auditoria.Accion = "ACTUALIZACION";
                    auditoria.ValoresPrevios = JsonConvert.SerializeObject(cambio.OriginalValues.ToObject());
                    auditoria.ValoresNuevos = JsonConvert.SerializeObject(cambio.CurrentValues.ToObject());
                    break;

                case EntityState.Deleted:
                    auditoria.Accion = "ELIMINACION";
                    auditoria.ValoresPrevios = JsonConvert.SerializeObject(cambio.OriginalValues.ToObject());
                    auditoria.ValoresNuevos = null;
                    break;

            }

            auditorias.Add(auditoria);            
        }
        Auditorias.AddRange(auditorias);
    }
    private string ObtenerClavePrimaria(EntityEntry Entrada)
    {
        var PK = Entrada.Metadata.FindPrimaryKey();

        if (PK == null) return "0";

        var NombrePropPK = PK.Properties.FirstOrDefault();

        if (NombrePropPK == null) return "0";
        
        return Entrada?.Property(NombrePropPK.Name)?.CurrentValue?.ToString() ?? "0";
       
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        modelBuilder.Entity<ArchivosVentas>(entity =>
        {
            entity.ToTable("ARCHIVOS_VENTAS");

            entity.HasKey(p => p.IdArchivo)
            .HasName("PK_ARCHIVOS_VENTAS_ID_ARCHIVO");  
            
            entity.HasIndex(p => p.IdArchivo)
            .HasDatabaseName("IX_ARCHIVOS_VENTAS_ID_ARCHIVO");

            entity.Property(p => p.IdVenta)
            .HasColumnName("ID_VENTA")
            .HasColumnType("int");

            entity.Property(p => p.IdArchivo)
            .HasColumnName("ID_ARCHIVO")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

            entity.Property(p => p.HashArchivo)
            .HasColumnName("HASH_ARCHIVO")
            .HasColumnType("text");

            entity.Property(p => p.PathArchivo)
            .HasColumnName("PATH_ARCHIVO")
            .HasColumnType("text");

            entity.Property(p => p.MimeType)
            .HasColumnName("MIME_TYPE")
            .HasColumnType("text");

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int");

            entity.HasOne(p => p.VentasNavigation)
            .WithMany(p => p.Archivos)
            .HasPrincipalKey(p => p.IdVenta)
            .HasForeignKey(p => p.IdVenta)
            .HasConstraintName("FK_ARCHIVOS_VENTAS_VENTAS_ID_VENTA");


        });


        modelBuilder.Entity<EntidadesPago>(entity =>
        {
            entity.ToTable("ENTIDADES_PAGO");

            entity.HasKey(p => p.IdEntidad);

            entity.Property(p => p.IdEntidad)
            .HasColumnName("ID_ENTIDAD")
            .ValueGeneratedOnAdd()
            .IsRequired();

            entity.Property(p => p.Tipo)
            .HasColumnName("TIPO")
            .HasColumnType("text")
            .IsRequired(false);

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text")
            .IsRequired(false);

            entity.Property(p => p.Emisor)
           .HasColumnName("EMISOR")
           .HasColumnType("text")
           .IsRequired(false);

        });

        modelBuilder.Entity<AsignacionPermisosRoles>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("role_table_grants", "information_schema");
            
            entity.Property(p =>p.Otorgante)
            .HasColumnName("grantor");

            entity.Property(p => p.Beneficiario)
            .HasColumnName("grantee");

            entity.Property(p => p.CatalogoTabla)
            .HasColumnName("table_catalog");

            entity.Property(p => p.EsquemaTabla)
            .HasColumnName("table_schema");

            entity.Property(p => p.NombreTabla)
            .HasColumnName("table_name");

            entity.Property(p => p.Atributo)
            .HasColumnName("privilege_type");

            entity.Property(p => p.EsOtorgable)
            .HasColumnName("is_grantable");

        });

        modelBuilder.Entity<Auditorias>(entity =>
        {
            entity.ToTable("AUDITORIAS");

            entity.HasKey(p => p.IdAuditoria);

            entity.Property(p => p.IdAuditoria)
            .UseIdentityColumn();

            entity.Property(p => p.Tabla)
            .HasColumnName("TABLA")
            .HasColumnType("text");

            entity.Property(p => p.IdRegistro)
            .HasColumnName("ID_REGISTRO")
            .HasColumnType("text");
           
            entity.Property(p => p.Accion)
           .HasColumnName("ACCION")
           .HasColumnType("text");

            entity.Property(p => p.Usuario)
           .HasColumnName("USUARIO")
           .HasColumnType("text");

            entity.Property(p => p.Fecha)
           .HasColumnName("FECHA")
           .HasColumnType("timestamp");

            entity.Property(p => p.ValoresPrevios)
           .HasColumnName("VALORES_PREVIOS")
           .HasColumnType("text");

            entity.Property(p => p.ValoresNuevos)
           .HasColumnName("VALORES_NUEVOS")
           .HasColumnType("text");

        });


        modelBuilder.Entity<CuotasCompras>(entity =>
        {
            entity.ToTable("CUOTAS_COMPRAS");

            entity.HasKey(p => p.IdCuota);

            entity.Property(p => p.IdCompra)
            .HasColumnName("ID_COMPRA");

            entity.Property(p => p.Monto)
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.FechaVencimiento)
            .HasColumnType("timestamp");

            entity.Property(p => p.IdEstadoCuota)
            .HasColumnName("ID_ESTADO_CUOTA");


            entity.Property(p => p.FechaPago)
            .HasColumnType("timestamp");

            entity.HasOne(p => p.CompraNavigation)
            .WithMany(p => p.CuotasCompra)
            .HasPrincipalKey(PK => PK.IdCompra)
            .HasForeignKey(FK => FK.IdCompra)
            .HasConstraintName("FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA");

            entity.HasOne(p => p.EstadoCuotaCompra)
            .WithMany(p => p.IdEstadoCuotaNavigation)
            .HasPrincipalKey(p => p.IdEstadoCuota)
            .HasForeignKey(p => p.IdEstadoCuota)
            .HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");

            entity.HasOne(p => p.EstadoCuotaCompra)
            .WithMany(p => p.IdEstadoCuotaNavigation)
            .HasPrincipalKey(pk => pk.IdEstadoCuota)
            .HasForeignKey(fk => fk.IdEstadoCuota)
            .HasConstraintName("FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA");
            

          


        });

        modelBuilder.Entity<EstadosCuotasCompras>(entity =>
        {
            entity.ToTable("ESTADOS_CUOTAS_COMPRAS");

            entity.HasKey(p => p.IdEstadoCuota);


            entity.Property(p => p.IdEstadoCuota)
            .HasColumnName("ID_ESTADO_CUOTA");

            entity.Property(p => p.Descripcion)
            .HasColumnType("text");

            entity.Property(p => p.IdEstado)
            .HasDefaultValueSql("1");

        });

        modelBuilder.Entity<RolesUsuarios>(entity =>
        {
            entity.ToTable("USUARIOS_ROLES");

            entity.HasKey(PK => PK.IdRol);

            entity.Property(p => p.IdRol)
            .HasColumnName("ID_ROL")
            .HasColumnType("integer")
            .UseIdentityColumn();

            entity.Property(p => p.NombreRol)
            .HasColumnType("varchar(100)")
            .HasColumnName("NOMBRE_ROL");

            entity.Property(p => p.Descripcion)
            .HasColumnType("varchar(100)")
            .HasColumnName("DESCRIPCION");

       




        });

        modelBuilder.Entity<EntidadesTiposCategorias>(entity =>
        {
            entity.ToTable("ENTIDADES_TIPOS_CATEGORIAS");
            entity.HasKey(PK => new
            {
                PK.idTipoEntidad,
                PK.IdCategoriaEntidad
            });

            entity.Property(p => p.idTipoEntidad)
            .HasColumnName("ID_TIPO")
            .HasColumnType("int");

            entity.Property(p => p.IdCategoriaEntidad)
            .HasColumnName("ID_CATEGORIA")
            .HasColumnType("int");
        });

        modelBuilder.Entity<EstadosCuotasVentas>(entity =>
        {
            entity.ToTable("ESTADOS_CUOTAS_VENTAS");

            entity.HasKey(pk => pk.IdEstadoCuota);

            entity.Property(p => p.IdEstadoCuota)
            .HasColumnType("int")
            .HasColumnName("ID_ESTADO_CUOTA")
            .UseIdentityColumn();

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text");

            entity.Property(p => p.IdEstado)
            .HasColumnType("int")
            .HasColumnName("ID_ESTADO")
            .HasDefaultValueSql("1");

            entity.HasMany(p => p.IdEstadoCuotaNavigation)
            .WithOne(p => p.EstadoCuota)
            .HasPrincipalKey(p => p.IdEstadoCuota)
            .HasForeignKey(FK => FK.IdEstadoCuota);

        });

        modelBuilder.Entity<CuotasVentas>(entity =>
        {
            entity.ToTable("CUOTAS_VENTAS");

            entity.HasKey(PK => PK.IdCuota);

            entity.Property(p => p.IdCuota)
            .HasColumnType("int")
            .HasColumnName("ID_CUOTA")
            .UseIdentityColumn();

            entity.Property(p => p.IdVenta)
            .HasColumnType("int")
            .HasColumnName("ID_VENTA");


            entity.Property(p => p.NumeroCuota)
            .HasColumnType("int")
            .HasColumnName("NUMERO_CUOTA");

            entity.Property(p => p.Monto)
            .HasColumnName("MONTO")
            .HasColumnType("decimal(18,2)")
            .HasDefaultValueSql("0.00");

            entity.Property(p => p.FechaVencimiento)
            .HasColumnName("FECHA_VENCIMIENTO")
            .HasColumnType("timestamp");

            entity.Property(p => p.IdEstadoCuota)
            .HasColumnName("ID_ESTADO_CUOTA")
            .HasDefaultValueSql("1");

            entity.Property(p => p.FechaPago)
            .HasColumnName("FECHA_PAGO")
            .HasColumnType("timestamp");
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.ToTable("VENTAS");

            entity.HasKey(p => p.IdVenta);

            entity.Property(p => p.IdVenta)
            .HasColumnName("ID_VENTA")
            .HasColumnType("int")
            .UseIdentityColumn();

            entity.Property(p => p.IdCliente)
            .HasColumnName("ID_CLIENTE")
            .HasColumnType("int");

            entity.Property(p => p.FechaHora)
            .HasColumnName("FECHA_HORA")
            .HasColumnType("timestamp");

            entity.Property(p => p.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("varchar(50)");

            entity.Property(p => p.MontoTotal)
            .HasColumnName("MONTO_TOTAL")
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.IdEstadoVenta)
            .HasColumnName("ID_ESTADO_VENTA")
            .HasColumnType("int");

            entity.Property(p => p.SaldoPendiente)
            .HasColumnName("SALDO_PENDIENTE");

            entity.HasOne(p => p.Usuario)
            .WithMany(p => p.Ventas)
            .HasForeignKey(FK => FK.IdUsuario)
            .HasPrincipalKey(PK => PK.Usuario)
            .OnDelete(DeleteBehavior.NoAction);

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

            entity.Property(p => p.Precio)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("PRECIO");

            entity.HasOne(p => p.Venta)
            .WithMany(p => p.DetallesVenta)
            .HasPrincipalKey(PK => PK.IdVenta)
            .HasForeignKey(FK => FK.IdVenta);

            entity.HasOne(p => p.IdProductoNavigation)
            .WithMany(p => p.Ventas)
            .HasForeignKey(FK => FK.IdProducto)
            .HasPrincipalKey(PK => PK.IdProducto)
            .HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");

        });

        modelBuilder.Entity<PagosVentas>(entity =>
        {
            entity.ToTable("PAGOS_VENTAS");

            entity.HasKey(PK => PK.IdPago);

            entity.Property(P => P.IdPago)
            .HasColumnName("ID_PAGO")
            .HasColumnType("int")
            .UseIdentityColumn();

            entity.Property(p => p.IdVenta)
            .HasColumnType("int")
            .HasColumnName("ID_VENTA");

            entity.Property(p => p.IdMedioPago)
            .HasColumnName("ID_MEDIO_PAGO")
            .HasColumnType("int");

            entity.Property(p => p.IdEntidadPago)
           .HasColumnName("ID_ENTIDAD_PAGO")
           .HasColumnType("int");

            entity.Property(p => p.Monto)
            .HasColumnName("MONTO")
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Fecha)
            .HasColumnName("FECHA")
            .HasColumnType("timestamp");

            entity.Property(p => p.IdCuota)
            .HasColumnName("ID_CUOTA")
            .HasColumnType("integer")
            .IsRequired(false)
            .HasDefaultValue(null);

            entity.HasOne(p => p.MedioPago)
            .WithMany(p => p.PagosVentasNavigation)
            .HasForeignKey(FK => FK.IdMedioPago)
            .HasPrincipalKey(PK => PK.IdMedioPago);

            entity.HasOne(p => p.Venta)
            .WithMany(p => p.Pagos)
            .HasPrincipalKey(PK => PK.IdVenta)
            .HasForeignKey(FK => FK.IdVenta);

            entity.HasOne(p => p.EntidadPago)
            .WithMany(p => p.pagosVentas)
            .HasPrincipalKey(PK => PK.IdEntidad)
            .HasForeignKey(FK => FK.IdEntidadPago)
            .HasConstraintName("FK_PAGOS_VENTAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO");

            entity.HasOne(p => p.Cuota)
            .WithMany(c => c.Pagos)
           .HasForeignKey(p => p.IdCuota)
           .HasPrincipalKey(P => P.IdCuota)
           .HasConstraintName("FK_PAGOS_VENTAS_CUOTAS_VENTAS_ID_CUOTA")
           .IsRequired(false);

        });

        modelBuilder.Entity<EstadosVentas>(entity =>
        {
            entity.ToTable("ESTADOS_VENTAS");

            entity.HasKey(PK => PK.IdEstadoVenta);

            entity.Property(P => P.IdEstadoVenta)
            .HasColumnName("ID_ESTADO_VENTA")
            .HasColumnType("int")
            .UseIdentityColumn();

            entity.Property(P => P.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int")
            .HasDefaultValue("1");

            entity.Property(P => P.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text");
        });



        modelBuilder.Entity<ComprasDetalles>(entity =>
        {
            entity.ToTable("COMPRAS_DETALLE");

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
            .HasPrincipalKey(PK => PK.IdCompra)
            .HasForeignKey(FK => FK.IdCompra);


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
            .UseIdentityColumn();

            entity.Property(p => p.CodigoMPago)
            .HasColumnType("text")
            .HasColumnName("CODIGO_MPAGO");

            entity.Property(p => p.Descripcion)
            .HasColumnType("text")
            .HasColumnName("DESCRIPCION");

            entity.Property(p => p.IdEstado)
            .HasColumnType("int")
            .HasColumnName("ID_ESTADO")
            .HasDefaultValue("1");
        });

        modelBuilder.Entity<PagosCompras>(entity =>
        {
            entity.ToTable("PAGOS_COMPRAS");

            entity.HasKey(PK => PK.IdPago);

            entity.Property(P => P.IdPago)
            .HasColumnName("ID_PAGO")
            .HasColumnType("int")
            .UseIdentityColumn();

            entity.Property(p => p.IdCompra)
            .HasColumnType("int")
            .HasColumnName("ID_COMPRA");

            entity.Property(p => p.IdMedioPago)
            .HasColumnName("ID_MEDIO_PAGO")
            .HasColumnType("int");

            entity.Property(p => p.IdEntidadPago)
            .HasColumnName("ID_ENTIDAD_PAGO")
            .HasColumnType("int");

            entity.Property(p => p.Monto)
            .HasColumnName("SUBTOTAL")
            .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Fecha)
            .HasColumnType("timestamp");

            entity.Property(p => p.IdCuota)
           .HasColumnName("ID_CUOTA")
           .HasColumnType("integer")
           .IsRequired(false)           
           .HasDefaultValue(null);

            entity.HasOne(p => p.MedioPago)
            .WithMany(p => p.PagosComprasNavigation)
            .HasForeignKey(FK => FK.IdMedioPago)
            .HasPrincipalKey(PK => PK.IdMedioPago);

            entity.HasOne(p => p.Compra)
            .WithMany(p => p.Pagos)
            .HasPrincipalKey(PK => PK.IdCompra)
            .HasForeignKey(FK => FK.IdCompra);

            entity.HasOne(p => p.entidadPago)
           .WithMany(p => p.pagosCompras)
           .HasPrincipalKey(PK => PK.IdEntidad)
           .HasForeignKey(FK => FK.IdEntidadPago)
           .HasConstraintName("FK_PAGOS_COMPRAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO");

            
            entity.HasOne(p => p.Cuota)
            .WithMany(c => c.Pagos)
            .HasForeignKey(p => p.IdCuota)
            .HasPrincipalKey(P=>P.IdCuota)
            .HasConstraintName("FK_PAGOS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA")
            .IsRequired(false); 


        });

        modelBuilder.Entity<EstadosCompras>(entity =>
        {
            entity.ToTable("ESTADOS_COMPRAS");

            entity.HasKey(PK => PK.IdEstadoCompra);

            entity.Property(P => P.IdEstadoCompra)
            .HasColumnName("ID_ESTADO_COMPRA")
            .HasColumnType("int")
            .UseIdentityColumn();

            entity.Property(P => P.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int");

            entity.Property(P => P.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text");

        });


        modelBuilder.Entity<Compras>(entity =>
        {
            entity.ToTable("COMPRAS");

            entity.HasKey(p => p.IdCompra);

            entity.Property(p => p.IdCompra)
            .HasColumnName("ID_COMPRA")
            .HasColumnType("int")
            .UseIdentityColumn();

            entity.Property(p => p.IdProveedor)
            .HasColumnName("ID_PROVEEDOR")
            .HasColumnType("int");

            entity.Property(p => p.FechaHora)
            .HasColumnName("FECHA_HORA")
            .HasColumnType("timestamp");

            entity.Property(p => p.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("varchar(50)");        

            entity.Property(p => p.IdEstadoCompra)
            .HasColumnName("ID_ESTADO_COMPRA")
            .HasColumnType("int");

            entity.Property(p => p.MontoTotal)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("MONTO_TOTAL");

            entity.Property(p => p.SaldoPendiente)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("SALDO_PENDIENTE");

            entity.HasOne(p => p.Estado)
            .WithMany(p => p.compras)
            .HasPrincipalKey(PK => PK.IdEstadoCompra)
            .HasForeignKey(FK => FK.IdEstadoCompra)
            .HasConstraintName("FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA");

            entity.HasOne(p => p.Usuario)
            .WithMany(p => p.Compras)
            .HasPrincipalKey(PK => PK.Usuario)
            .HasForeignKey(FK => FK.IdUsuario)
            .HasConstraintName("FK_COMPRAS_USUARIOS_IDUSUARIO");

            entity.HasOne(p => p.IdProveedorNavigation)
            .WithMany(p => p.compras)
            .HasForeignKey(p => p.IdProveedor)
            .HasPrincipalKey(p => p.IdEntidad)
            .OnDelete(DeleteBehavior.NoAction);
            
            entity.HasMany(p => p.Pagos)
            .WithOne(p => p.Compra)
            .HasForeignKey(p => p.IdCompra);

        });

        modelBuilder.Entity<EntidadesTipos>(entity =>
        {
            entity.ToTable("ENTIDADES_TIPOS");

            entity.HasKey(PK => PK.IdTipo);

            entity.Property(P => P.IdTipo)
            .HasColumnName("ID_TIPO")
            .UseIdentityColumn();

            entity.Property(P => P.IdEstado)
            .HasDefaultValueSql("1")
            .HasColumnName("ID_ESTADO");

            entity.Property(p => p.NombreTipo)
            .HasColumnName("NOMBRE")
            .HasColumnType("text");

            entity.HasMany(p => p.Entidades)
            .WithOne(p => p.TipoEntidad)
            .HasForeignKey(FK => FK.IdTipo);

            entity.HasMany(p => p.TiposCategoriasNavigation)
            .WithOne(p => p.TipoEntidad)
            .HasPrincipalKey(PK => PK.IdTipo)
            .HasForeignKey(FK => FK.idTipoEntidad);


        });

        modelBuilder.Entity<EntidadesCategorias>(entity =>
        {
            entity.ToTable("ENTIDADES_CATEGORIAS");

            entity.HasKey(PK => PK.IdCategoria);

            entity.Property(P => P.IdCategoria)
            .HasColumnName("ID_CATEGORIA")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            entity.Property(P => P.IdEstado)
            .HasDefaultValueSql("1")
            .HasColumnName("ID_ESTADO");

            entity.Property(p => p.NombreCategoria)
            .HasColumnName("NOMBRE_CATEGORIA")
            .HasColumnType("text");

            entity.HasMany(p => p.Entidades)
            .WithOne(p => p.CategoriaEntidad)
            .HasForeignKey(FK => FK.IdCategoria);

            entity.HasMany(p => p.TiposCategoriasNavigation)
            .WithOne(p => p.CategoriaEntidad)
            .HasPrincipalKey(PK => PK.IdCategoria)
            .HasForeignKey(FK => FK.IdCategoriaEntidad);

        });


        modelBuilder.Entity<EstadosMovimientosStock>(entity =>
        {
            entity.ToTable("ESTADOS_MOVIMIENTOS_STOCK");

            entity.HasKey(PK => PK.IdEstadoMovimiento);

            entity.Property(p => p.IdEstadoMovimiento)
            .HasColumnName("ID_ESTADO_MOVIMIENTO")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasDefaultValueSql("1");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text");

            entity.HasMany(p => p.movimientosStock)
            .WithOne(p => p.estadoMovimiento)
            .HasForeignKey(p => p.IdEstadoMovimiento);
        });

        modelBuilder.Entity<EstadosArchivosMovimientosStock>(entity =>
        {
            entity.ToTable("ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .UseIdentityColumn();

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text");

            entity.HasMany(p => p.ArchivosMovimientoStock)
            .WithOne(p => p.ArchivosMovimientosStockNavigation)
            .HasForeignKey(p => p.IdEstado);
        });

        modelBuilder.Entity<EstadosSuministrosMovimientosStock>(entity =>
        {
            entity.ToTable("ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text");

            entity.HasMany(p => p.SuministrosMovimientoStock)
            .WithOne(p => p.EstadosSuministrosMovimientosStockNavigation)
            .HasForeignKey(p => p.IdEstado)
            .HasConstraintName("FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO");
        });

        modelBuilder.Entity<EstadosProductosDescripciones>(entity =>
        {
            entity.ToTable("ESTADOS_PRODUCTOS_DESCRIPCIONES");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(p => p.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasDefaultValueSql("1");

            entity.Property(p => p.Descripcion)
            .HasColumnName("DESCRIPCION")
            .HasColumnType("text");

            entity.HasMany(p => p.ProductosDescripcions)
            .WithOne(p => p.IdEstadoNavigation)
            .HasForeignKey(p => p.IdEstado);
        });

        modelBuilder.Entity<EstadosTiposProductos>(entity =>
        {
            entity.ToTable("ESTADOS_PRODUCTOS_TIPOS");

            entity.HasKey(PK => PK.IdEstado);

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO");

            entity.Property(e => e.Descripcion)
            .HasColumnType("text")
            .HasColumnName("DESCRIPCION");

            entity.HasMany(e => e.ProductosTipos)
            .WithOne(e => e.IdEstadoNavigation)
            .HasForeignKey(e => e.IdEstado);
        });

        modelBuilder.Entity<EstadosComponentesDetalles>(entity =>
        {
            entity.ToTable("ESTADOS_COMPONENTES_DETALLES");
            entity.HasKey(e => e.IdEstado);

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO");

            entity.Property(e => e.Descripcion)
            .HasColumnType("text")
            .HasColumnName("DESCRIPCION");
   
        });

        modelBuilder.Entity<EstadosProductosComponentes>(entity =>
        {
            entity.ToTable("ESTADOS_PRODUCTOS_COMPONENTES");
            entity.HasKey(PK => PK.IdEstado);

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO");

            entity.Property(e => e.Descripcion)
            .HasColumnType("text")
            .HasColumnName("DESCRIPCION");
            
        });

        modelBuilder.Entity<EstadosProductos>(entity =>
        {
            entity.ToTable("ESTADOS_PRODUCTOS");
            entity.HasKey(PK => PK.IdEstado);

            entity.Property(entity => entity.IdEstado)
            .HasColumnName("ID_ESTADO");

            entity.Property(e => e.Descripcion)
            .HasColumnType("text")
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

            entity.Property(e => e.IdSuministro)
            .HasColumnName("ID_SUMINISTRO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.Cantidad)
            .HasColumnName("CANTIDAD")
            .HasColumnType("decimal(18,2)");

            entity.Property(e => e.IdEstado)
           .HasColumnName("ID_ESTADO")
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

            entity.Property(e => e.IdProducto)
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
            .HasDefaultValueSql("1");

            entity.HasOne(e => e.IdEstadoNavigation)
            .WithMany(e => e.ProductosComponentes)
            .HasForeignKey(e => e.IdEstado)
            .HasPrincipalKey(PK => PK.IdEstado)
            .HasForeignKey(FK => FK.IdEstado)
            .HasConstraintName("FK_PRODUCTOS_COMPONENTES_ESTADOS_PRODUCTOS_COMPONENTES_ID_ESTAD")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();


        });



        modelBuilder.Entity<ComponentesDetalle>(entity =>
        {
            entity.Property(e => e.IdInsumo)
            .HasColumnName("ID_INSUMO")
            .HasColumnType("varchar(50)");

            entity.HasKey(e => e.IdInsumo)
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
            .HasDefaultValueSql("1")
            .HasColumnName("ID_ESTADO")
            .HasColumnType("int");

            entity.Property(e => e.IdFraccionamiento)
            .HasColumnName("ID_FRACCIONAMIENTO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.IdAlmacenamiento)
            .HasColumnName("ID_ALMACENAMIENTO")
            .HasColumnType("varchar(50)");

            entity.HasOne(p => p.IdEstadoNavigation)
            .WithMany(p => p.ComponentesDetalle)
            .HasPrincipalKey(pk => pk.IdEstado)
            .HasForeignKey(p => p.IdEstado)
            .HasConstraintName("FK_COMPONENTES_DETALLE_ESTADOS_COMPONENTES_DETALLES_ID_ESTADO");
            

        });

        modelBuilder.Entity<ComponentesDescripcion>(entity =>
        {
            entity.HasKey(e => e.IdDescripcion);

            entity.ToTable("COMPONENTES_DESCRIPCION");

            entity.Property(e => e.IdDescripcion)
                .HasColumnName("ID_DESCRIPCION")
                .UseIdentityColumn();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

            entity.Property(p => p.IdAlmacenamiento)
            .HasColumnType("varchar(50)")
            .HasColumnName("ID_ALMACENAMIENTO")
            .IsRequired();

            entity.Property(p => p.IdFraccionamiento)
            .HasColumnName("ID_FRACCIONAMIENTO")
            .HasColumnType("varchar(50)");
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
            .HasDefaultValueSql("1");

            entity.HasOne(d => d.IdDescripcionNavigation).WithMany(p => p.Productos)

                .HasForeignKey(d => d.IdDescripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOS_PRODUCTOS_DESCRIPCION");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOS_PRODUCTOS_TIPOS");

            entity.HasMany(p => p.Ventas).WithOne(p => p.IdProductoNavigation)
            .HasForeignKey(FK => FK.IdProducto)
            .HasPrincipalKey(PK => PK.IdProducto)
            .HasConstraintName("FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO");


        });

        modelBuilder.Entity<ProductosDescripcion>(entity =>
        {
            entity.HasKey(e => e.IdDescripcion);

            entity.ToTable("PRODUCTOS_DESCRIPCION");

            entity.Property(e => e.IdDescripcion)
                .HasColumnName("ID_DESCRIPCION")
                .UseIdentityColumn();

            entity.Property(e => e.DescripcionProducto)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("DESCRIPCION");

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<ProductosTipo>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK_PRODUCTOS_TIPOS");

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
            .UseIdentityColumn()
            .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Productos_Tipos_Descripcion>(entity =>
        {
            entity.ToTable("PRODUCTOS_TIPOS_DESCRIPCION");
            entity.HasKey(Key => new { Key.IdTipo, Key.IdDescripcion });

            entity.Property(e => e.IdTipo)
            .HasColumnName("ID_TIPO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.IdDescripcion)
            .HasColumnName("ID_DESCRIPCION");


            entity.HasOne(p => p.IdTipoNavigation)
            .WithMany(p => p.Producto_Tipo_Descripcione)
            .HasForeignKey(FK => FK.IdTipo)
            .HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO")
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.IdDescripcionNavigation)
            .WithMany(p => p.Producto_Tipo_Descripcione)
            .HasForeignKey(FK => FK.IdDescripcion)
            .HasConstraintName("FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION")
            .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.ToTable("USUARIOS");
            entity.HasKey(e => e.Usuario);

            entity.Property(e => e.Usuario)
            .HasColumnName("USUARIO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.IdRol)
            .HasColumnName("ID_ROL")
            .HasColumnType("int");

            entity.Property(e => e.Correo)
            .HasColumnName("CORREO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.HashContraseña)
            .HasColumnName("HASH_CONTRASEÑA")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.Sal)
            .HasColumnName("SAL")
            .HasColumnType("text");

            entity.HasMany(e => e.IdUsuarioRegistroNavigation)
            .WithOne(u => u.UsuarioRegistro)
            .HasForeignKey(e => e.IdUsuarioRegistro);

            entity.HasOne(p => p.Rol)
            .WithMany(p => p.RolesUsuariosNavigation)
            .HasConstraintName("FK_USUARIOS_ROLES_USUARIOS_ID_ROL")
            .HasPrincipalKey(PK => PK.IdRol)
            .HasForeignKey(FK => FK.IdRol);

        });

        modelBuilder.Entity<Stock_Movimientos>(entity =>
        {
            entity.ToTable("STOCK_MOVIMIENTOS");

            entity.HasKey(e => e.IdMovimiento);

            entity.Property(e => e.IdMovimiento)
            .HasColumnName("ID_MOVIMIENTO")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

            entity.Property(e => e.CreadoUsuario)
            .HasColumnName("USUARIO_CREADO")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.ModificadoUsuario)
            .HasColumnName("USUARIO_MODIFICA")
            .HasColumnType("varchar(50)");

            entity.Property(e => e.FechaHoraCreado)
            .HasColumnName("FECHA_HORA_CREADO")
            .HasColumnType("timestamp");

            entity.Property(e => e.FechaHoraUltimaModificacion)
            .HasColumnName("FECHA_HORA_ULTIMA_MODIFICACION")
            .HasColumnType("timestamp");      

            entity.Property(e => e.IdProveedor)
            .HasColumnName("ID_PROVEEDOR")
            .HasColumnType("int");

            entity.Property(e => e.IdEstadoMovimiento)
            .HasColumnName("ID_ESTADO_MOVIMIENTO")
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

            entity.HasOne(e => e.Proveeedor)
            .WithMany(e => e.Movimientos)
            .HasForeignKey(e => e.IdProveedor)
            .HasPrincipalKey(PK => PK.IdEntidad)
            .HasForeignKey(FK => FK.IdProveedor)
            .HasConstraintName("FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO");

        });

        modelBuilder.Entity<ArchivosMovimientosStock>(entity =>
        {
            entity.HasKey(e => new
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
            .HasColumnType("text");

            entity.Property(e => e.MimeType)
           .HasColumnName("MIME_TYPE")
           .HasColumnType("text");

            entity.HasOne(e => e.StockMovimiento).WithMany()
            .HasForeignKey(e => e.IdMovimiento)
            .HasPrincipalKey(p => p.IdMovimiento)
            .HasConstraintName("FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO");

            entity.Property(e => e.IdEstado)
           .HasColumnName("ID_ESTADO")
           .HasDefaultValueSql("1");

        });

        modelBuilder.Entity<Entidades>(entity =>
        {
            entity.HasKey(e => e.IdEntidad);

            entity.ToTable("ENTIDADES");

            entity.Property(e => e.IdEntidad)
            .HasColumnName("ID_ENTIDAD");

            entity.Property(e => e.NombreClave)
            .HasColumnName("NOMBRE_CLAVE");

            entity.Property(e => e.Nombre)
            .HasColumnName("NOMBRE")
            .HasColumnType("text");

            entity.Property(e => e.Apellido)
            .HasColumnName("APELLIDO")
            .HasColumnType("text");

            entity.Property(e => e.Pais)
            .HasColumnName("PAIS");

            entity.Property(e => e.Ciudad)
            .HasColumnName("CIUDAD");

            entity.Property(e => e.Localidad)
            .HasColumnName("LOCALIDAD")
            .HasColumnType("text");

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
            .HasColumnName("FECHA_REGISTRO")
            .HasColumnType("timestamp");

            entity.Property(e => e.IdUsuarioRegistro)
            .HasColumnName("ID_USUARIO_REGISTRO")
            .HasColumnType("varchar(50)")
            .IsRequired();

            entity.Property(x => x.Barrio)
            .HasColumnName("BARRIO")
            .HasColumnType("text");

            entity.Property(x => x.IdTipo)
            .HasColumnName("ID_TIPO")
            .HasColumnType("int");

            entity.Property(x => x.IdCategoria)
            .HasColumnName("ID_CATEGORIA")
            .HasColumnType("int");

            entity.Property(e => e.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasDefaultValueSql("1");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
