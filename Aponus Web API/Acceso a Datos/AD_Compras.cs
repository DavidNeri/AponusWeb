using Aponus_Web_API.Modelos;
using Aponus_Web_API.Utilidades;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Z.EntityFramework.Plus;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Compras
    {
        private readonly AponusContext aponusContext;
        private readonly IHttpContextAccessor Context;

        public AD_Compras(AponusContext _aponusContext, IHttpContextAccessor context)
        {
            aponusContext = _aponusContext;
            Context = context;
        }

        internal async Task<Compras?> BuscarCompra(int IdCompra)
        {
            Compras? Compra = await aponusContext.Compra
                .Include(x => x.DetallesCompra)
                .Include(x => x.IdProveedorNavigation)
                .Include(x => x.Pagos)
                .FirstOrDefaultAsync(x => x.IdCompra == IdCompra);

            return Compra;
        }

        internal async Task<bool> Guardar(Compras compra)
        {
            using var transaccion = aponusContext.Database.BeginTransaction();
            var DetallesInsumosCompras = compra.DetallesCompra;

            var pagosCompra = compra.Pagos;
            var CuotasCompra = compra.CuotasCompra;

            compra.Pagos = null;
            compra.CuotasCompra = null;
            var estadoCompra = aponusContext.EstadosCompra.First(x => x.IdEstado == compra.IdEstadoCompra) ?? new EstadosCompras();
            compra.Estado = estadoCompra;
            var UsuarioContext = Context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            compra.Usuario = aponusContext.Usuarios.First(x => x.Usuario.Equals(UsuarioContext)) ?? new Usuarios();
            compra.IdProveedorNavigation = aponusContext.Entidades.First(x => x.IdEntidad == compra.IdProveedor) ?? new Entidades();

            foreach (var item in compra.DetallesCompra)
            {
                item.DetallesInsumo.IdEstado = 1;
                item.DetallesInsumo.IdEstadoNavigation = await aponusContext.EstadosComponentesDetalle.FirstAsync(x => x.IdEstado == 1);
            }

            foreach (var item in DetallesInsumosCompras)
            {
                var Insumo = aponusContext.ComponentesDetalles.First(x => x.IdInsumo.Equals(item.IdInsumo));

                item.DetallesInsumo = aponusContext.ComponentesDetalles.Where(x => x.IdInsumo.Equals(item.IdInsumo)).First();
                item.DetallesInsumo.IdEstado = Insumo.IdEstado;
                item.DetallesInsumo.IdEstadoNavigation = Insumo.IdEstadoNavigation;
            }



            try
            {
                var CompraExistente = aponusContext.Compra.Find(compra.IdCompra);

                if (CompraExistente == null)
                {
                    await aponusContext.Compra.AddAsync(compra);
                }
                else
                {
                    aponusContext.Entry(CompraExistente).CurrentValues.SetValues(compra);
                    aponusContext.Entry(CompraExistente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                await aponusContext.SaveChangesAsync();

                foreach (var pago in pagosCompra)
                {
                    pago.IdCompra = compra.IdCompra;
                    var EntidadPago = aponusContext.entidadespago.First(X => X.IdEntidad == pago.IdEntidadPago);
                    var medioPago = aponusContext.MediosPagos.First(X => X.IdMedioPago == pago.IdMedioPago);
                    pago.entidadPago = EntidadPago;
                    pago.MedioPago = medioPago;
                    pago.Compra = aponusContext.Compra.Single(x => x.IdCompra == compra.IdCompra);
                    await aponusContext.PagosCompra.AddAsync(pago);
                }

                if (CuotasCompra != null || CuotasCompra?.Count > 0)
                {
                    foreach (var cuota in CuotasCompra)
                    {
                        cuota.EstadoCuotaCompra = await aponusContext.EstadosCuotasCompra.SingleAsync(x => x.IdEstadoCuota == cuota.IdEstadoCuota);
                        cuota.CompraNavigation = aponusContext.Compra.Single(x => x.IdCompra == compra.IdCompra);
                        foreach (var PagoCuotaCompra in cuota.Pagos)
                        {
                            PagoCuotaCompra.MedioPago = aponusContext.MediosPagos.Single(x => x.IdMedioPago == PagoCuotaCompra.IdMedioPago);
                            PagoCuotaCompra.entidadPago = aponusContext.entidadespago.Single(x => x.IdEntidad == PagoCuotaCompra.IdEntidadPago);
                            PagoCuotaCompra.IdCompra = compra.IdCompra;
                        }
                    }

                    await aponusContext.AddRangeAsync(CuotasCompra);
                }


                await aponusContext.SaveChangesAsync();

                await transaccion.CommitAsync();
                return true;

            }
            catch (Exception)
            {
                transaccion.Rollback();
                return false;
            }
        }

        internal (IQueryable<Compras>? QuyeryCompras, Exception? Error) ObtenerDatos(UTL_FiltrosComprasVentas? Filtros)
        {
            try
            {
                IQueryable<Compras> compras = aponusContext.Compra
                    .Include(x => x.DetallesCompra)
                    .Include(x => x.Pagos).ThenInclude(x => x.MedioPago)
                    .Include(x => x.IdProveedorNavigation)
                    .Include(c => c.CuotasCompra).ThenInclude(x => x.Pagos)
                    .AsQueryable();

                if (Filtros != null)
                {
                    if (Filtros.Desde != null)
                        compras = compras.Where(x => x.FechaHora >= Filtros.Desde);
                    if (Filtros.Hasta != null)
                        compras = compras.Where(x => x.FechaHora <= Filtros.Desde);
                    if (Filtros.IdEntidad != null)
                        compras = compras.Where(x => x.IdProveedor == Filtros.IdEntidad);
                    if (Filtros.IdCompraVenta != null)
                        compras = compras.Where(x => x.IdCompra == Filtros.IdCompraVenta);
                }
                return (compras, null);
            }
            catch (Exception Error)
            {
                return (null, Error);
            }
        }

        internal async Task<(int? Resultado, Exception? Error)> GuardarPago(PagosCompras pago)
        {
            using var transaccion = await aponusContext.Database.BeginTransactionAsync();

            try
            {
                if (pago.IdCuota != null && pago.IdCuota != 0)
                {
                    pago.Cuota = aponusContext.CuotasCompra.First(x => x.IdCuota == pago.IdCuota);
                }

                pago.entidadPago = await aponusContext.entidadespago.FirstAsync(x => x.IdEntidad == pago.IdEntidadPago);
                pago.MedioPago = await aponusContext.MediosPagos.FirstAsync(x => x.IdMedioPago == pago.IdMedioPago);
                pago.Compra = await aponusContext.Compra.FirstAsync(x => x.IdCompra == pago.IdCompra);

                if (pago?.IdPago != null && pago.IdPago != 0)
                {
                    aponusContext.PagosCompra.Update(pago);
                    await aponusContext.SaveChangesAsync();
                }
                else
                {
                    aponusContext.PagosCompra.Add(pago!);
                }

                await aponusContext.SaveChangesAsync();
                await transaccion.CommitAsync();

                return (StatusCodes.Status200OK, null);

            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync();

                return (null, ex);
            }
        }
    }
}
