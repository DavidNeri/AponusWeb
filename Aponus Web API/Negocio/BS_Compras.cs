using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Negocio
{
    public class BS_Compras
    {
        private readonly AD_Compras AdCompras;

        public BS_Compras(AD_Compras _adCompras)
        {
            AdCompras = _adCompras;
        }

        internal async Task<IActionResult> Listar(UTL_FiltrosComprasVentas? Filtros)
        {
            var (QueryCompras, error) = AdCompras.ObtenerDatos(Filtros);

            if (error != null)
            {
                return new ContentResult()
                {
                    Content = error.InnerException?.Message ?? error.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
            else
            {
                ICollection<DTOCompras> Compras = await QueryCompras!
                .Select(x => new DTOCompras()
                {
                    FechaHora = x.FechaHora,
                    IdCompra = x.IdCompra,
                    IdProveedor = x.IdProveedor,
                    SaldoPendiente = x.SaldoPendiente,
                    MontoTotal = x.MontoTotal,
                    IdUsuario = x.IdUsuario,

                    DetallesCompra = x.DetallesCompra.Select(y=> new DTOComprasDetalles()
                    {
                        IdCompra = y.IdCompra,
                        Cantidad = y.Cantidad,
                        IdInsumo = y.IdInsumo,

                    }).ToList(),                   

                    Pagos = x.Pagos.Select(y=>new DTOPagosCompras()
                    {                        
                        IdCompra = y.IdCompra,
                        Fecha = y.Fecha,
                        IdMedioPago = y.IdMedioPago,
                        Monto = y.Monto,
                        IdPago = y.IdPago,
                        
                    }).ToList(),

                    Proveedor = new DTOEntidades()
                    {
                        IdEntidad = x.IdProveedorNavigation.IdEntidad,
                        Apellido = x.IdProveedorNavigation.Apellido,
                        Nombre = x.IdProveedorNavigation.Nombre,
                        NombreClave = x.IdProveedorNavigation.NombreClave,                        
                    }                    

                }).ToListAsync();

                return new JsonResult(Compras);

            }

        }

        internal async Task<IActionResult> ProcesarDatosCompra(DTOCompras Compra)
        {
            if (string.IsNullOrEmpty(Compra.IdUsuario) || Compra.DetallesCompra.Count == 0 || Compra.MontoTotal == 0)
            {
                return new ContentResult()
                {
                    Content = "Faltan Datos",
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
            else
            {
                if (Compra.Cuotas != null || Compra?.Cuotas?.Count > 0)
                {

                }

                Compras compra = new()
                {
                    IdProveedor = Compra.IdProveedor,
                    IdUsuario = Compra.IdUsuario,
                    FechaHora = UTL_Fechas.ObtenerFechaHora(),
                    IdProveedorNavigation = new Entidades { IdEntidad = Compra.IdProveedor },
                    Usuario = new Usuarios { Usuario = Compra.IdUsuario },
                    MontoTotal = Compra.MontoTotal ?? 0,
                    SaldoPendiente = Compra.SaldoPendiente ?? 0,
                    IdEstadoCompra = Compra.IdEstadoCompra ?? 1,

                    DetallesCompra = Compra.DetallesCompra.Select(dc => new ComprasDetalles()
                    {
                        Cantidad = dc.Cantidad,
                        IdInsumo = dc.IdInsumo,
                        IdCompra = dc.IdCompra,
                        DetallesInsumo = new ComponentesDetalle { IdInsumo = dc.IdInsumo}                        

                    }).ToList(),



                    Pagos = Compra.Pagos.Select(p => new PagosCompras()
                    {
                        IdCompra = p.IdCompra,
                        Fecha = p.Fecha ?? UTL_Fechas.ObtenerFechaHora(),
                        IdMedioPago = p.IdMedioPago,
                        IdEntidadPago = p.IdEntidadPago,
                        MedioPago = new MediosPago() { IdMedioPago = p.IdMedioPago },
                        entidadPago = new EntidadesPago() { IdEntidad= p.IdEntidadPago},
                        IdPago = p.IdPago,
                        Monto = p.Monto,

                    }).ToList(),
                   
                };

                if (Compra.IdCompra != null && Compra.IdCompra.HasValue)
                {
                    int IdCompra = Compra.IdCompra.Value;

                    Compras? _Compra = await AdCompras.BuscarCompra(IdCompra);

                    if (_Compra != null)
                    {
                        compra.IdCompra = _Compra.IdCompra;

                    }
                }

                bool resultado = await AdCompras.Guardar(compra);

                if (resultado)
                    return new StatusCodeResult(200);
                else
                    return new ContentResult()
                    {
                        Content = "Error interno, no se aplicaron los cambios",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
            }
        }

        internal async Task<IActionResult> RegistrarPago(DTOPagosCompras pago)
        {
            PagosCompras Pago = new()
            {
                IdCompra = pago.IdCompra,
                Compra = new Compras() { IdCompra = pago.IdCompra },
                Monto = pago.Monto,
                Fecha = UTL_Fechas.ObtenerFechaHora(),
                IdMedioPago = pago.IdMedioPago,
                MedioPago = new MediosPago { IdMedioPago = pago.IdMedioPago }
            };

            var (Resultado, Error) = await AdCompras.RegistrarPago(Pago);

            if (Error != null)
                return new ContentResult()
                {
                    Content = Error.InnerException?.Message ?? Error.Message,
                    ContentType = "application/json",
                    StatusCode = 500
                };

            return Resultado!;

        }
    }
}
