using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Z.EntityFramework.Plus;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Ventas
    {
        private readonly AponusContext AponusDBContext;
        private readonly AD_Stocks AdStocks;
        private readonly IHttpContextAccessor Context;

        public AD_Ventas(AponusContext _aponusContext, AD_Stocks adStocks, IHttpContextAccessor _context)
        {
            AponusDBContext = _aponusContext;
            AdStocks = adStocks;
            Context = _context;
        }

        public async Task<int?> Guardar(Ventas Venta)
        {
            var roolbackResult = false;
            using var transaccion = AponusDBContext.Database.BeginTransaction();
            var ProductosVenta = Venta.DetallesVenta;

            var pagosVenta = Venta.Pagos;
            var CuotasVenta = Venta.Cuotas;

            //Venta.Pagos = null;
            //Venta.Cuotas= null;

            var estadoVenta = AponusDBContext.estadosVentas.First(x => x.IdEstado == Venta.IdEstadoVenta) ?? new EstadosVentas();

            Venta.Estado = estadoVenta;

            var UsuarioHttpContext = Context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Venta.Usuario = AponusDBContext.Usuarios.First(x => x.Usuario.Equals(UsuarioHttpContext)) ?? new Usuarios();
            Venta.Cliente = AponusDBContext.Entidades.First(x => x.IdEntidad == Venta.IdCliente) ?? new Entidades();


            if (Venta?.IdVenta != null && Venta?.IdVenta != 0)
            {
                var VentaAnterior = BuscarVenta(Venta!.IdVenta);

                var ProductosVentaAnterior = Venta.DetallesVenta;

                foreach (var Prod in ProductosVentaAnterior)
                {
                    roolbackResult = AdStocks.IncrementarStockProducto(new DTOStockUpdate()
                    {
                        IdExistencia = Prod.IdProducto,
                        Cantidad = Prod.Cantidad,
                    });
                }
            }

            foreach (var item in ProductosVenta)
            {
                item.IdProductoNavigation = AponusDBContext.Productos.First(x => x.IdProducto == item.IdProducto);
                roolbackResult = AdStocks.DisminuirStockProducto(new DTOStockUpdate()
                {
                    IdExistencia = item.IdProducto,
                    Cantidad = item.Cantidad,
                }, AponusDBContext);
            }

            await AponusDBContext.ventas.AddAsync(Venta);
            await AponusDBContext.SaveChangesAsync();

            foreach (var pago in pagosVenta)
            {
                pago.IdVenta = Venta.IdVenta;
                var EntidadPago = AponusDBContext.entidadespago.First(X => X.IdEntidad == pago.IdEntidadPago);
                var medioPago = AponusDBContext.MediosPagos.First(X => X.IdMedioPago == pago.IdMedioPago);
                pago.EntidadPago = EntidadPago;
                pago.MedioPago = medioPago;
                pago.Venta = AponusDBContext.ventas.Single(x => x.IdVenta == Venta.IdVenta);
                await AponusDBContext.pagosVentas.AddAsync(pago);
            }

            if (CuotasVenta != null || CuotasVenta?.Count > 0)
            {
                foreach (var Cuota in CuotasVenta)
                {
                    Cuota.EstadoCuota = await AponusDBContext.estadosCuotasVentas.SingleAsync(x => x.IdEstadoCuota == Cuota.IdEstadoCuota);
                    Cuota.Venta = AponusDBContext.ventas.Single(x => x.IdVenta == Venta.IdVenta);

                    foreach (var PagoCuotaVenta in Cuota.Pagos)
                    {
                        PagoCuotaVenta.MedioPago = AponusDBContext.MediosPagos.Single(x => x.IdMedioPago == PagoCuotaVenta.IdMedioPago);
                        PagoCuotaVenta.EntidadPago = AponusDBContext.entidadespago.Single(x => x.IdEntidad == PagoCuotaVenta.IdEntidadPago);
                        PagoCuotaVenta.IdVenta = Venta.IdVenta;
                    }
                }

                await AponusDBContext.AddRangeAsync(CuotasVenta);
            }

            if (roolbackResult)
            {
                await AponusDBContext.SaveChangesAsync();
                await transaccion.CommitAsync();
                await AponusDBContext.DisposeAsync();
                return Venta.IdVenta;

            }
            else
            {
                transaccion.Rollback();
                await AponusDBContext.DisposeAsync();
                return null;
            }

        }

        public IQueryable<Modelos.Ventas> ListarVentas()
        {
            return AponusDBContext.ventas
                .Where(Estado => Estado.IdEstadoVenta != 0)
                .Include(x => x.DetallesVenta)
                .Include(x => x.Cuotas)
                .Include(x => x.Pagos)
                .Include(Cli => Cli.Cliente)
                .Include(x => x.Archivos)
                .Include(x => x.Estado)
                .AsQueryable();
        }

        internal async Task<Ventas?> BuscarVenta(int idVenta)
        {
            Ventas? venta = await AponusDBContext.ventas
               .Include(x => x.DetallesVenta)
               .Include(x => x.Cliente)
               .Include(x => x.Pagos)
               .Include(x => x.Archivos)
               .FirstOrDefaultAsync(x => x.IdVenta == idVenta);

            return venta;
        }

        internal void EliminarEstado(EstadosVentas EstadoVenta)
        {
            var Estado = AponusDBContext.estadosVentas.Find(typeof(EstadosVentas), EstadoVenta.IdEstadoVenta);

            if (Estado != null)
            {
                Estado.IdEstado = 0;
                AponusDBContext.SaveChanges();

            }
        }

        internal async Task<(int? Resultado, Exception? error)> GuardarArchivos(List<ArchivosVentas> archivosVentas)
        {
            using var Transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                var idVenta = archivosVentas.Select(x => x.IdVenta).First();
                var Venta = AponusDBContext.ventas.Find(idVenta);

                archivosVentas.ForEach(x => x.VentasNavigation = Venta ?? new Ventas());
                await AponusDBContext.ArchivosVentas.AddRangeAsync(archivosVentas);
                await AponusDBContext.SaveChangesAsync();
                await Transaccion.CommitAsync();
                await AponusDBContext.DisposeAsync();

                return (StatusCodes.Status200OK, null);

            }
            catch (Exception ex)
            {
                await Transaccion.RollbackAsync();
                await AponusDBContext.DisposeAsync();
                return (null, ex);
            }
        }

        internal async Task<IActionResult> GuardarEstado(DTOEstadosVentas NuevoEstado)
        {
            if (NuevoEstado.IdEstadoVenta != null)
            {
                EstadosVentas? Estado = await AponusDBContext.estadosVentas.FirstOrDefaultAsync(x => x.IdEstadoVenta == NuevoEstado.IdEstadoVenta);
                if (Estado != null)
                {
                    Estado.Descripcion = NuevoEstado.Descripcion ?? Estado.Descripcion;
                    Estado.IdEstado = 1;
                    await AponusDBContext.SaveChangesAsync();
                }
                else
                {
                    await AponusDBContext.estadosVentas.AddAsync(new EstadosVentas()
                    {
                        Descripcion = NuevoEstado?.Descripcion ?? ""
                    });
                }
                return new StatusCodeResult(200);
            }
            else
            {
                var Existe = AponusDBContext.estadosVentas.FirstOrDefault(x => x.Descripcion.Equals(NuevoEstado.Descripcion) && x.IdEstado != 0);
                if (Existe != null)
                    return new ContentResult()
                    {
                        Content = "Nombre de Estado Existente. No se aplicarion los cambios",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                else
                {
                    await AponusDBContext.estadosVentas.AddAsync(new EstadosVentas()
                    {
                        Descripcion = NuevoEstado?.Descripcion ?? ""
                    });
                    return new StatusCodeResult(200);
                }
            }
        }

        internal async Task<(int? Resultado, Exception? ex)> GuardarPago(PagosVentas pago)
        {
            using var transaccion = AponusDBContext.Database.BeginTransaction();

            try
            {
                if (pago.IdCuota != null && pago.IdCuota != 0)
                {
                    pago.Cuota = AponusDBContext.cuotasVentas.First(x => x.IdCuota == pago.IdCuota);
                }

                pago.EntidadPago = AponusDBContext.entidadespago.First(x => x.IdEntidad == pago.IdEntidadPago);
                pago.MedioPago = AponusDBContext.MediosPagos.First(x => x.IdMedioPago == pago.IdMedioPago);
                pago.Venta = AponusDBContext.ventas.First(x => x.IdVenta == pago.IdVenta);

                if (pago?.IdPago != null && pago.IdPago != 0)
                {
                    AponusDBContext.pagosVentas.Update(pago);
                    AponusDBContext.SaveChanges();
                }
                else
                {
                    AponusDBContext.pagosVentas.Add(pago!);
                }

                AponusDBContext.SaveChanges();
                transaccion.Commit();

                return (StatusCodes.Status200OK, null);

            }
            catch (Exception ex)
            {
                transaccion.Rollback();

                return (null, ex);
            }

        }
    }
}
