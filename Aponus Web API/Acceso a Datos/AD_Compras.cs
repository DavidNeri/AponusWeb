using Aponus_Web_API.Modelos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Compras
    {
        private readonly AponusContext aponusContext;

        public AD_Compras(AponusContext _aponusContext)
        {
            aponusContext = _aponusContext;
        }

        internal async Task<Compras>? BuscarCompra(int IdCompra)
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
                    .Include(x => x.Pagos)
                    .Include(x => x.IdProveedorNavigation)
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
                        compras = compras.Where(x => x.IdCompra >= Filtros.IdCompraVenta);
                }
                return (compras, null);
            }
            catch (Exception Error)
            {
                return (null, Error);
            }




        }

        internal async Task<(StatusCodeResult? ResultadoOk, Exception? Error)> RegistrarPago(PagosCompras pago)
        {
            using var transaccion = await aponusContext.Database.BeginTransactionAsync();
            try
            {
                await aponusContext.PagosCompra.AddAsync(pago);
                await aponusContext.SaveChangesAsync();
                await transaccion.CommitAsync();
                return (new StatusCodeResult(200), null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
    }
}
