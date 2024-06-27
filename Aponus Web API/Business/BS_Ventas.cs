using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Ventas
    {
        internal static async Task<IActionResult> Guardar(DTOVentas Venta)
        {
            ICollection<VentasDetalles> NvaVtaDet = new List<VentasDetalles>();
            ICollection<PagosVentas> NvaVtaPagos = new List<PagosVentas>();
            ICollection<DTOCuotasVentas>  NvaVtaCuotas = await GenerarCuotasVenta(5);

            Ventas NuevaVenta = new Ventas()
            {
                IdCliente = Venta.IdCliente,
                FechaHora = Fechas.ObtenerFechaHora(),
                IdUsuario = Venta.IdUsuario,
                SaldoTotal = Venta.SaldoTotal,
                SaldoCancelado = Venta.SaldoCancelado,
            };


            foreach (var vta in Venta.DetallesVenta)
            {
                NvaVtaDet.Add(new VentasDetalles()
                {
                    IdProducto = vta.IdProducto,
                    Cantidad = vta.Cantidad,

                });
            }

            foreach (var vtaPagos in Venta.Pagos)
            {
                NvaVtaPagos.Add(new PagosVentas()
                {
                    IdMedioPago = vtaPagos.IdMedioPago,
                    Subtotal = vtaPagos.Subtotal,
                    Total = vtaPagos.Total,
                    SubtotalCancelado = vtaPagos.SubtotalCancelado,
                    CantidadCuotas = vtaPagos.CantidadCuotas,
                    CantidadCuotasCanceladas = vtaPagos.CantidadCuotasCanceladas
                });
            }


            foreach (var vtaCuotas in Venta.Cuotas)
            {
                for (int CuotaNumero =1; CuotaNumero <= (Venta.Pagos.Select(x=>x.CantidadCuotas).FirstOrDefault() ?? 0 ); CuotaNumero++)
                {

                }
            }


            return null;

        }


        public static async Task<ICollection<DTOCuotasVentas>> GenerarCuotasVenta (int TotalCuotas)
        {
            ICollection<CuotasVentas> NvaVtaCuotas = new List<CuotasVentas>();


            return null;
        }


    }
}
