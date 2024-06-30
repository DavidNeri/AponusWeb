using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Ventas
    {
        internal static async Task<IActionResult> Guardar(DTOVentas Venta)
        {
            Venta.Cuotas = await CalcularCuotas(5, Venta.Monto);

            Ventas NuevaVenta = new Ventas()
            {
                IdCliente = Venta.IdCliente,
                FechaHora = Fechas.ObtenerFechaHora(),
                IdUsuario = Venta.IdUsuario,
                SaldoTotal = Venta.Monto,
                SaldoCancelado = Venta.SaldoCancelado,

            };

            foreach (var vta in Venta.DetallesVenta)
            {               
                 NuevaVenta.DetallesVenta.Add(new VentasDetalles()
                {
                    IdProducto = vta.IdProducto,
                    Cantidad = vta.Cantidad,

                });
            }
            foreach (var vtaPagos in Venta.Pagos)
            {
                NuevaVenta.Pagos.Add(new PagosVentas()
                {
                    IdMedioPago = vtaPagos.IdMedioPago,
                    Subtotal = vtaPagos.Subtotal,
                    Total = vtaPagos.Total,
                    SubtotalCancelado = vtaPagos.SubtotalCancelado,
                    CantidadCuotas = vtaPagos.CantidadCuotas,
                    CantidadCuotasCanceladas = vtaPagos.CantidadCuotasCanceladas
                });
            }
            foreach (var Cuota in Venta.Cuotas)
            {
                NuevaVenta.Cuotas.Add(new CuotasVentas()
                {
                    NumeroCuota = Cuota.NumeroCuota,
                    Monto = Cuota.Monto,
                    FechaVencimiento = Cuota.FechaVencimiento,

                });
            }





            return null;

        }
        public static async Task<ICollection<DTOCuotasVentas>> CalcularCuotas( int TotalCuotas, decimal MontoVenta, decimal interes = 0)
        {
            ICollection<CuotasVentas> NvaVtaCuotas = new List<CuotasVentas>();
            DateTime Vencimiento = Fechas.ObtenerFechaHora();

            decimal MontoCuota = (MontoVenta + (MontoVenta * interes)) / TotalCuotas;
            decimal Resto = MontoVenta % TotalCuotas;

            for (int i = 1; i <= TotalCuotas; i++)
            {
                Vencimiento = i switch
                {
                    1 => Vencimiento,
                    _ => Vencimiento.AddDays(30)
                };

                NvaVtaCuotas.Add(new CuotasVentas()
                {
                    NumeroCuota = $"{i}/{TotalCuotas}",
                   
                    Monto = i switch
                    {
                        int n when n == TotalCuotas => MontoCuota + Resto,
                        _ => MontoCuota,
                    },

                    FechaVencimiento = Vencimiento

                });
            }


            return null;
        }


    }
}
