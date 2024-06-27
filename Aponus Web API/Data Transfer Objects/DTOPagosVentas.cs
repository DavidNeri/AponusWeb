using Aponus_Web_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOPagosVentas
    {
        public int IdPago { get; set; }
        public int IdVenta { get; set; }
        public int IdMedioPago { get; set; }
        public int? CantidadCuotas { get; set; }
        public int? CantidadCuotasCanceladas { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal? SubtotalCancelado { get; set; }
        public decimal SubtotalPendiente { get; set; }
        public decimal CantidadCuotasPendientes { get; set; }
        public MediosPago MedioPago { get; set; } = new();
        public Ventas Venta = new();
    }
}