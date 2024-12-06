using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Negocio
{
    public class BS_Ventas
    {
        private readonly AD_Ventas AdVentas;
        public BS_Ventas(AD_Ventas adVentas)
        {
            AdVentas = adVentas;
        }

        public Estados EstadosVentas()
        {
            return new Estados(AdVentas);
        }
        public class Estados
        {
            private readonly AD_Ventas AdVentas;

            public Estados(AD_Ventas adVentas)
            {
                AdVentas = adVentas;
            }
            internal IActionResult Eliminar(int id)
            {
                try
                {
                    AdVentas.EliminarEstado(new EstadosVentas()
                    {
                        IdEstadoVenta = id
                    });
                    return new StatusCodeResult(200);
                }
                catch (Exception ex)
                {

                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 100
                    };
                }
            }
            internal async Task<IActionResult> ValidarDatos(DTOEstadosVentas Estado)
            {
                try
                {

                    Estado.Descripcion = Regex.Replace(Estado.Descripcion ?? "", @"\s+", " ").Trim().ToUpper();

                    if (string.IsNullOrEmpty(Estado.Descripcion))
                        return new ContentResult()
                        {
                            Content = "El estado no puede estar vacío",
                            ContentType = "application/json",
                            StatusCode = 400
                        };

                    await AdVentas.GuardarEstado(Estado);
                    return new StatusCodeResult(200);

                }
                catch (Exception ex)
                {

                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 400

                    };
                }
            }
        }
        internal async Task<IActionResult> ProcesarDatosVenta(DTOVentas Venta)
        {
            decimal saldoPendiente = Venta.MontoTotal;

            if (Venta.DetallesVenta == null || (Venta.Pagos == null && Venta.Cuotas != null) || Venta.Cuotas == null && Venta.Pagos == null)
            {
                return new ContentResult()
                {
                    Content = "Faltan Datos",
                    ContentType = "application/json",
                    StatusCode = 400,
                };
            }
            else
            {
                Ventas NuevaVenta = new()
                {
                    IdCliente = Venta.IdCliente,
                    FechaHora = UTL_Fechas.ObtenerFechaHora(),
                    IdUsuario = Venta.IdUsuario,
                    IdEstadoVenta = Venta.IdEstadoVenta,
                    MontoTotal = Venta.MontoTotal,

                };

                if (Venta.DetallesVenta != null)
                {
                    foreach (var vta in Venta.DetallesVenta)
                    {
                        NuevaVenta.DetallesVenta.Add(new VentasDetalles()
                        {
                            IdProducto = vta.IdProducto,
                            Cantidad = vta.Cantidad,
                            Precio = vta.Precio,
                            IdProductoNavigation = new Producto { IdProducto = vta.IdProducto }

                        });
                    }
                }
                if (Venta.Pagos != null)
                {
                    foreach (var vtaPagos in Venta.Pagos)
                    {
                        saldoPendiente = saldoPendiente - vtaPagos.Monto;

                        NuevaVenta.Pagos.Add(new PagosVentas()
                        {
                            Fecha = vtaPagos.Fecha ?? UTL_Fechas.ObtenerFechaHora(),
                            Monto = vtaPagos.Monto,
                            IdMedioPago = vtaPagos.IdMedioPago,

                        });
                    }

                    NuevaVenta.SaldoPendiente = saldoPendiente;
                }
                if (Venta.Cuotas != null)
                {
                    foreach (var Cuota in Venta.Cuotas)
                    {
                        NuevaVenta.Cuotas.Add(new CuotasVentas()
                        {
                            NumeroCuota = Cuota.NumeroCuota,
                            Monto = Cuota.Monto,
                            FechaVencimiento = Cuota.FechaVencimiento,
                            IdEstadoCuota = Cuota.IdEstadoCuota,

                        });
                    }
                }


                bool Resultado = await AdVentas.Guardar(NuevaVenta);


                return new ContentResult()
                {
                    Content = Resultado ? "Datos Guardados" : "Error interno, no se guardaron los datos",
                    ContentType = "Application/Json",
                    StatusCode = Resultado ? 200 : 500
                };
            }


        }
        public static ICollection<DTOCuotasVentas> CalcularCuotas(UTL_ParametrosCuotas Parametros)
        {
            ICollection<DTOCuotasVentas> NvaVtaCuotas = new List<DTOCuotasVentas>();
            DateTime Vencimiento = UTL_Fechas.ObtenerFechaHora();

            decimal MontoCuota = (Parametros.MontoVenta + (Parametros.MontoVenta * Parametros.Interes)) / Parametros.CantidadCuotas;
            decimal Resto = Parametros.MontoVenta % Parametros.CantidadCuotas;

            for (int i = 1; i <= Parametros.CantidadCuotas; i++)
            {
                Vencimiento = i switch
                {
                    1 => Vencimiento,
                    _ => Vencimiento.AddDays(30)
                };

                NvaVtaCuotas.Add(new DTOCuotasVentas()
                {
                    NumeroCuota = i,

                    Monto = i switch
                    {
                        int n when n == Parametros.CantidadCuotas => MontoCuota + Resto,
                        _ => MontoCuota,
                    },

                    FechaVencimiento = Vencimiento

                });
            }


            return NvaVtaCuotas;
        }
        internal IActionResult Filtrar(UTL_FiltrosComprasVentas? filtros)
        {
            try
            {

                IQueryable<Ventas> QueryVentas = AdVentas.ListarVentas();

                if (filtros?.IdEntidad != null)
                    QueryVentas = QueryVentas.Where(x => x.IdCliente == filtros.IdEntidad);
                if (filtros?.Desde != null)
                    QueryVentas = QueryVentas.Where(X => X.FechaHora >= filtros.Desde);
                if (filtros?.Hasta != null)
                    QueryVentas = QueryVentas.Where(X => X.FechaHora >= filtros.Hasta);

                List<DTOVentas> ListadoVentas = QueryVentas.Select(x => new DTOVentas()
                {
                    IdVenta = x.IdVenta,
                    IdCliente = x.IdCliente,
                    FechaHora = x.FechaHora,
                    IdUsuario = x.IdUsuario,
                    IdEstadoVenta = x.IdEstadoVenta,
                    MontoTotal = x.MontoTotal,
                    SaldoPendiente = x.SaldoPendiente,
                    DetallesVenta = x.DetallesVenta.Select(y => new DTOVentasDetalles()
                    {
                        Cantidad = y.Cantidad,
                        IdProducto = y.IdProducto,
                        IdVenta = y.IdVenta,
                    })
                    .ToList(),
                    Cuotas = x.Cuotas.Select(Cuotas => new DTOCuotasVentas()
                    {
                        FechaPago = Cuotas.FechaPago,
                        FechaVencimiento = Cuotas.FechaVencimiento,
                        NumeroCuota = Cuotas.NumeroCuota,
                        Monto = Cuotas.Monto,
                        EstadoCuota = new DTOEstadosCuotasVentas()
                        {
                            Descripcion = Cuotas.EstadoCuota.Descripcion,
                            IdEstado = Cuotas.EstadoCuota.IdEstado,
                        }
                    })
                    .ToList(),

                    Cliente = new DTOEntidades()
                    {
                        Nombre = x.Cliente.Nombre,
                        Apellido = x.Cliente.Apellido,
                        NombreClave = x.Cliente.NombreClave,
                        IdTipo = x.Cliente.IdTipo,
                        IdCategoria = x.Cliente.IdCategoria,
                    },

                    Pagos = x.Pagos.Select(Pagos => new DTOPagosVentas()
                    {
                        IdMedioPago = Pagos.IdMedioPago,
                        IdPago = Pagos.IdPago,
                        IdVenta = Pagos.IdVenta,
                        Monto = Pagos.Monto,
                        MedioPago = new DTOMediosPago()
                        {
                            Descripcion = Pagos.MedioPago.Descripcion,
                            IdMedioPago = Pagos.MedioPago.IdMedioPago,
                            CodigoMPago = Pagos.MedioPago.CodigoMPago,
                        }

                    }).ToList(),

                }).ToList();


                return new JsonResult(ListadoVentas);
            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }



        }
    }
}
