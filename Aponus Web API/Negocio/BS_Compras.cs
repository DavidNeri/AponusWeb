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

                    Estado = new DTOEstadosCompras()
                    {
                        Descripcion = x.Estado.Descripcion,
                        IdEstadoCompra = x.Estado.IdEstadoCompra
                    },

                    DetallesCompra = x.DetallesCompra.Select(y => new DTOComprasDetalles()
                    {
                        IdCompra = y.IdCompra,
                        Cantidad = y.Cantidad,
                        IdInsumo = y.IdInsumo,

                    }).ToList(),

                    Pagos = x.Pagos.Select(y => new DTOPagosCompras()
                    {
                        IdCompra = y.IdCompra,
                        Fecha = y.Fecha,
                        IdMedioPago = y.IdMedioPago,
                        Monto = y.Monto,
                        IdPago = y.IdPago,
                        MedioPago = new DTOMediosPago()
                        {
                            CodigoMPago = y.MedioPago.CodigoMPago,
                            Descripcion = y.MedioPago.Descripcion,
                            IdMedioPago = y.MedioPago.IdMedioPago
                        },
                        EntidadesPago = new DTOEntidadesPago()
                        {
                            Descripcion = y.entidadPago.Descripcion,
                            Emisor = y.entidadPago.Emisor,
                            IdEntidad = y.entidadPago.IdEntidad,
                            Tipo = y.entidadPago.Tipo
                        }
                    }).ToList(),

                    Cuotas = x.CuotasCompra.Select(c => new DTOCuotasCompras()
                    {
                        IdCompra = c.IdCompra,
                        Monto = c.Monto,
                        FechaPago = c.FechaPago,
                        FechaVencimiento = c.FechaVencimiento,
                        IdEstadoCuota = c.IdEstadoCuota,
                        NumeroCuota = c.NumeroCuota,

                        EstadoCuota = new DTOEstadosCuotasCompras()
                        {
                            Descripcion = c.EstadoCuotaCompra.Descripcion,
                            IdEstadoCuota = c.EstadoCuotaCompra.IdEstadoCuota,
                            IdEstado = c.EstadoCuotaCompra.IdEstado,
                        },

                        Pagos = c.Pagos.Select(x => new DTOPagosCompras()
                        {
                            IdCompra = x.IdCompra,
                            Fecha = x.Fecha,
                            IdCuota = x.IdCuota,
                            Monto = x.Monto,
                            EntidadesPago = new DTOEntidadesPago()
                            {
                                Descripcion = x.entidadPago.Descripcion,
                                Emisor = x.entidadPago.Emisor,
                                IdEntidad = x.entidadPago.IdEntidad,
                                Tipo = x.entidadPago.Tipo
                            }
                        }).ToList(),

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
                        DetallesInsumo = new ComponentesDetalle { IdInsumo = dc.IdInsumo }

                    }).ToList(),

                    Pagos = Compra.Pagos.Select(p => new PagosCompras()
                    {
                        IdCompra = p.IdCompra,
                        Fecha = p.Fecha ?? UTL_Fechas.ObtenerFechaHora(),
                        IdMedioPago = p.IdMedioPago,
                        IdEntidadPago = p.IdEntidadPago,
                        MedioPago = new MediosPago() { IdMedioPago = p.IdMedioPago },
                        entidadPago = new EntidadesPago() { IdEntidad = p.IdEntidadPago },
                        IdPago = p.IdPago,
                        Monto = p.Monto,

                    }).ToList(),

                };

                if (Compra.Cuotas != null || Compra?.Cuotas?.Count > 0)
                {
                    List<CuotasCompras> cuotas = new List<CuotasCompras>();
                    var cuotasCompra = Compra.Cuotas;

                    foreach (var cuota in cuotasCompra)
                    {
                        cuotas.Add(new CuotasCompras()
                        {
                            IdCuota = cuota.IdCuota ?? 0,
                            FechaVencimiento = cuota.FechaVencimiento,
                            FechaPago = cuota.FechaPago,
                            IdEstadoCuota = cuota.FechaPago != null ? 2 : 1,
                            NumeroCuota = cuota.NumeroCuota,
                            Monto = cuota.Monto,
                            Pagos = cuota.Pagos.Select(x => new PagosCompras()
                            {
                                IdCuota = x.IdCuota ?? 0,
                                IdMedioPago = x.IdMedioPago,
                                Monto = x.Monto,
                                Fecha = x.Fecha,
                                IdEntidadPago = x.IdEntidadPago,
                                Compra = null,

                            }).ToList(),
                        });
                    }

                    compra.CuotasCompra = cuotas;

                }

                if (Compra?.IdCompra != null && Compra.IdCompra.HasValue)
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

        internal async Task<IActionResult> MapeoDTOPagosCompra(DTOPagosCompras pago)
        {
            PagosCompras Pago = new()
            {
                Fecha = UTL_Fechas.ObtenerFechaHora(),
                IdCuota = pago.IdCuota ?? null,
                IdEntidadPago = pago.IdEntidadPago,
                IdMedioPago = pago.IdMedioPago,
                IdCompra = pago.IdCompra,
                IdPago = pago.IdPago,
                Monto = pago.Monto,
            };

            var (Resultado, Error) = await AdCompras.GuardarPago(Pago);

            if (Error != null)
                return new ContentResult()
                {
                    Content = Error.InnerException?.Message ?? Error.Message,
                    ContentType = "application/json",
                    StatusCode = 500
                };

            return new StatusCodeResult((int)Resultado!);

        }
    }
}
