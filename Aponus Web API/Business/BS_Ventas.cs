using Aponus_Web_API.Acceso_a_Datos.Ventas;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Aponus_Web_API.Support.Ventas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Business
{
    public class BS_Ventas
    {
        public static class Estados
        {
            internal static IActionResult Eliminar(int id)
            {
                try
                {
                    new ABM_Ventas().EliminarEstado(new EstadosVentas()
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

            internal static async Task<IActionResult> ValidarDatos(DTOEstadosVentas Estado)
            {
                try
                {

                    Estado.Descripcion = Regex.Replace(Estado.Descripcion ?? "", @"\s+", " ").Trim().ToUpper();

                    if (Estado.Descripcion.IsNullOrEmpty())
                        return new ContentResult()
                        {
                            Content = "El estado no puede estar vacío",
                            ContentType = "application/json",
                            StatusCode = 400
                        };

                    await new ABM_Ventas().GuardarEstado(Estado);
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

        internal static async Task<IActionResult> ProcesarDatosVenta(DTOVentas Venta)
        {
            decimal saldoPendiente = Venta.Total; 

            if (Venta.DetallesVenta == null || (Venta.Pagos == null && Venta.Cuotas != null) || Venta.Cuotas == null && Venta.Pagos == null)
            {
                return new ContentResult()
                {
                    Content="Faltan Datos",
                    ContentType = "application/json",
                    StatusCode = 400,
                };
            }
            else
            {
                Models.Ventas NuevaVenta = new Models.Ventas()
                {
                    IdCliente = Venta.IdCliente,
                    FechaHora = Fechas.ObtenerFechaHora(),
                    IdUsuario = Venta.IdUsuario,
                    IdEstadoVenta = Venta.IdEstadoVenta,
                    Total = Venta.Total,
                    
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
                            IdProductoNavigation = new Producto { IdProducto = vta.IdProducto}

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
                            Fecha = vtaPagos.FechaPago ?? Fechas.ObtenerFechaHora(),
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
                

                bool Resultado = await new Acceso_a_Datos.Ventas.ABM_Ventas().Guardar(NuevaVenta);


                return new ContentResult()
                {
                    Content = Resultado ? "Datos Guardados" : "Error interno, no se guardaron los datos",
                    ContentType = "Application/Json",
                    StatusCode = Resultado ? 200 : 500
                };
            }

            
        }
        public static async Task<ICollection<DTOCuotasVentas>> CalcularCuotas( ParametrosCalcularCuotas Parametros
            )
        {
            ICollection<CuotasVentas> NvaVtaCuotas = new List<CuotasVentas>();
            DateTime Vencimiento = Fechas.ObtenerFechaHora();

            decimal MontoCuota = (Parametros.MontoVenta + (Parametros.MontoVenta * Parametros.Interes)) / Parametros.CantidadCuotas;
            decimal Resto = Parametros.MontoVenta % Parametros.CantidadCuotas;

            for (int i = 1; i <= Parametros.CantidadCuotas; i++)
            {
                Vencimiento = i switch
                {
                    1 => Vencimiento,
                    _ => Vencimiento.AddDays(30)
                };

                NvaVtaCuotas.Add(new CuotasVentas()
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


            return null;
        }

        internal async static Task<IActionResult> Filtrar(FiltrosVentas? filtros)
        {
            try
            {

                IQueryable<Ventas> QueryVentas = new ABM_Ventas().ListarVentas();

                if (filtros?.IdCliente != null)
                    QueryVentas = QueryVentas.Where(x => x.IdCliente == filtros.IdCliente);
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
                    Total = x.Total,
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

                    Pagos = x.Pagos.Select(Pagos=> new DTOPagosVentas()
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
