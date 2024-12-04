using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Ventas
    {
        private readonly AponusContext AponusDBContext;
        private readonly AD_Stocks stocks;

        public AD_Ventas(AponusContext _aponusContext, AD_Stocks _stocks)
        {
            AponusDBContext = _aponusContext;
            stocks = _stocks;
        }

        public async Task<bool> Guardar(Modelos.Ventas Venta)
        {
            bool roolbackResult = false;
            using (var transaccion = AponusDBContext.Database.BeginTransaction())
            {
                Venta.Cliente = AponusDBContext.Entidades.Find(Venta.IdCliente) ?? new Modelos.Entidades();
                Venta.Usuario = AponusDBContext.Usuarios.Find(Venta.IdUsuario) ?? new Modelos.Usuarios();
                Venta.Estado = AponusDBContext.estadosVentas.Find(Venta.IdEstadoVenta) ?? new EstadosVentas();

                if (Venta.Pagos != null)
                    Venta.Pagos.ToList().ForEach(item => { item.MedioPago = AponusDBContext.MediosPagos.Find(item.IdMedioPago) ?? new MediosPago(); });
                if (Venta.DetallesVenta != null)
                    Venta.DetallesVenta.ToList().ForEach(item => { item.IdProductoNavigation = AponusDBContext.Productos.Find(item.IdProducto) ?? new Producto(); });
                if (Venta.Cuotas != null)
                    Venta.Cuotas.ToList().ForEach(item => { item.EstadoCuota = AponusDBContext.estadosCuotasVentas.Find(item.IdEstadoCuota) ?? new EstadosCuotasVentas(); });

                await AponusDBContext.ventas.AddAsync(Venta);

                foreach (VentasDetalles item in Venta.DetallesVenta ?? Enumerable.Empty<VentasDetalles>())
                {
                    roolbackResult = stocks.DisminuirStockProducto(new DTOStockUpdate()
                    {
                        IdExistencia = item.IdProducto,
                        Cantidad = item.Cantidad,
                    }, AponusDBContext);
                }

                if (roolbackResult)
                {
                    await AponusDBContext.SaveChangesAsync();
                    await transaccion.CommitAsync();
                    await AponusDBContext.DisposeAsync();
                    return true;

                }
                else
                {
                    transaccion.Rollback();
                    await AponusDBContext.DisposeAsync();
                    return false;
                }
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
                .AsQueryable();
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

        internal async Task<IActionResult> GuardarEstado(DTOEstadosVentas NuevoEstado)
        {
            if (NuevoEstado.IdEstadoVenta != null)
            {
                EstadosVentas? Estado = await AponusDBContext.estadosVentas.FirstOrDefaultAsync(x => x.IdEstadoVenta == NuevoEstado.IdEstado && x.IdEstado != 0);
                if (Estado != null)
                {
                    Estado.Descripcion = NuevoEstado.Descripcion ?? Estado.Descripcion;
                    Estado.IdEstado = NuevoEstado.IdEstado ?? Estado.IdEstado;
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
    }
}
