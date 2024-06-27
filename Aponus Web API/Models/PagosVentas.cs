using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class PagosVentas
    {

        [Key, Column("ID_PAGO", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }

        [ForeignKey("ID_VENTA")]
        public int IdVenta{ get; set; }

        [ForeignKey("ID_MEDIO_PAGO")]
        public int IdMedioPago { get; set; }

        [Column("CANTIDAD_CUOTAS")]
        public int? CantidadCuotas { get; set; }

        [Column("CANTIDAD_CUOTAS_CANCELADAS")]
        public int? CantidadCuotasCanceladas { get; set; }

        [Column("SUBTOTAL")]
        public decimal Subtotal { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }

        [Column("SUBTOTAL_CANCELADO")]
        public decimal? SubtotalCancelado { get; set; }

        [NotMapped]
        public decimal SubtotalPendiente => Subtotal - (SubtotalCancelado ?? 0);

        [NotMapped]
        public decimal CantidadCuotasPendientes => (CantidadCuotas ?? 0) - (CantidadCuotasCanceladas ?? 0);
        public virtual MediosPago MedioPago { get; set; } = new();
        public  Ventas Venta = new Ventas();
    }
}
